using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ItemMixManager : MonoBehaviour
{
    public Inventory inventory;
    private ItemMixRecipe recipe;
    private ItemMixList mixList;
    public CraftItemUI craftButton;
    public int needRecipeIdx;
    public TextMeshProUGUI popUpText;
    private bool isCrafting;
    private SceneManagerEx sceneManager;
    private static ItemMixManager instance;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
    }
    private void Start()
    {
        if (IsSceneAllowed())
        {
            
            if (inventory == null)
            {
                inventory = FindObjectOfType<Inventory>();
            }
            mixList = GetComponent<ItemMixList>();
            if (needRecipeIdx < mixList.itemMixRecipes.Count)
            {
                recipe = mixList.itemMixRecipes[needRecipeIdx];
                craftButton.UpdateUI(recipe);
            }
            else
            {
                ShowPopUp("Clear");
            }
            recipe = mixList.itemMixRecipes[needRecipeIdx];
            craftButton.UpdateUI(recipe);
            HidePopUp();
        }
        else
        {
            this.enabled = false;
        }
    }
   
    private bool IsSceneAllowed()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string[] allowedScenes = { "Intro","6_Island_1", "7_Island_2", "8_Bridge", "9_Home_1" };
        return System.Array.Exists(allowedScenes, name => name == currentSceneName);
    }
    public bool CanCraft()
    {
        List<ItemData> playerInventory = inventory.bagItems;

        for (int i = 0; i < recipe.requiredItems.Count; i++)
        {
            int requiredAmount = recipe.requiredQuantity[i];
            int itemCount = 0;

            foreach (var item in playerInventory)
            {
                if (item.itemName == recipe.requiredItems[i].itemName)
                {
                    itemCount += item.quantity; 
                }
            }
            if (itemCount < requiredAmount)
            {
                int missingAmount = requiredAmount - itemCount;
                ShowPopUp(recipe.requiredItems[i].itemName + "아이템이 " + missingAmount + "개 더 필요합니다.");
                return false;
            }
        }
        return true;
    }
    public void CraftItem()
    {
        if (isCrafting) return;
        if (CanCraft())
        {
            isCrafting = true;
            List<ItemData> playerInventory = inventory.missionItems;
            for (int i = 0; i < recipe.requiredItems.Count; i++)
            {
                int requiredAmount = recipe.requiredQuantity[i];
                for (int j = 0; j < playerInventory.Count; j++)
                {
                    if (playerInventory[j].itemName == recipe.requiredItems[i].itemName)
                    {
                        if (playerInventory[j].quantity >= requiredAmount)
                        {
                            playerInventory[j].quantity -= requiredAmount;
                            
                            break;
                        }
                    }
                }
            }
            inventory.AddToInfo(recipe.resultItem);
            ShowPopUp("미션 성공");
            Invoke("LoadNextScene", 3f);

            InventoryManager.instance.ResetInventoryUI();
        }
    }
    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        NextMission();
        inventory.inventoryUI.UpdateBagPanel(inventory.bagItems);
    }
    private void ShowPopUp(string message)
    {
        popUpText.text = message; 
        popUpText.gameObject.SetActive(true);
        Invoke("HidePopUp", 2f);
        
    }
    public void NextMission()
    {
        needRecipeIdx++;
        if (needRecipeIdx < mixList.itemMixRecipes.Count)
        {
            recipe = mixList.itemMixRecipes[needRecipeIdx];
            craftButton.UpdateUI(recipe);
            isCrafting = false;
        }
        else
        {
            ShowPopUp("Clear");
        }
    }
    private void HidePopUp()
    {
        popUpText.gameObject.SetActive(false);
    }
}