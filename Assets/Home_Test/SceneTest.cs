using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;  
public class SceneTest : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

