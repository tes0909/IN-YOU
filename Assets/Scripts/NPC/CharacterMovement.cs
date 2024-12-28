using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform targetPointA;
    [SerializeField] private Transform targetPointB;

    [SerializeField] private GameObject speechBubble;
    
    [SerializeField] private float speed = 75f;
    [SerializeField] private float idleTime = 2f;
    
    private bool isMovingRight = true;
    private Animator animator;
    public TextMeshProUGUI speechText;
    private readonly string[] messages = { "안녕하세요!", "반가워요", "여기 어때요?" };

    private readonly int idleHash = Animator.StringToHash("Idle");
    private readonly int walkHash = Animator.StringToHash("Walk");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger(walkHash);
        speechBubble.SetActive(false);
    }

    void Update()
    {
        if(speed > 0) CharacterMove();
    }
    
    void CharacterMove()
    {
        if (speed <= 0) return;
        if (isMovingRight) //오른쪽 이동중일경우
        {
            // 우측 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPointB.position, speed * Time.deltaTime);
            
            if (transform.position.x >= targetPointB.position.x)
            {
                isMovingRight = false;
                
                StartCoroutine(CharacterIdle());
            }
        }
        else // 왼쪽이동일경우
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPointA.position, speed * Time.deltaTime);
            
            if (transform.position.x <= targetPointA.position.x)
            {
                isMovingRight = true;
                StartCoroutine(CharacterIdle()); // 이동 멈춤
            }
        }
        transform.localScale = isMovingRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1); // 오른쪽, 왼쪽방향
        // text 참조해서 flip 고정 MATHF.ABS
        //speechText.transform.localScale = isMovingRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);

        Mathf.Abs(speechText.transform.localScale.x);
        Vector3 scale = speechText.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (isMovingRight ? 1 : -1);
        speechText.transform.localScale = scale;
        
        Debug.Log($"이건 그냥 트랜스폼 localScale: {transform.localScale.x}");
        Debug.Log($"이건 그냥 speechText localScale: {speechText.transform.localScale.x}");
    }
    
  
    
    IEnumerator CharacterIdle()
    {
        speed = 0;
        animator.SetTrigger(idleHash);
        string randomMessage = messages[Random.Range(0, messages.Length)];
        speechText.text = randomMessage;
        speechBubble.SetActive(true);
        
        yield return new WaitForSeconds(idleTime);
        
        speechBubble.SetActive(false);
        speed = 75f;
        animator.SetTrigger(walkHash);
    }
}
