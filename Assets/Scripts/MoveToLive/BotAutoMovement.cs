using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class BotAutoMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    public List<Transform> targets;
    public float raycastDistance = 2f; // Khoảng cách của raycast
    public Transform tfbot;
    public float slowFactor = 0.1f; // Hệ số chậm hơn
    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isMoving = false;
    private bool isStopped = false;
    private float moveTimer = 0f;
    int diemdich;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //moveDirection = new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)).normalized;
        moveDirection = targets[Random.Range(0, targets.Count)].position.normalized;
        diemdich =  Random.Range(0, targets.Count);
             

    }

    void FixedUpdate()
    {

        
        if (!isStopped)
        {
           
            if (isMoving)
            {
                if (moveTimer >= 12)
                {
                    
                    moveDirection = targets[diemdich].position - transform.position;
                    moveDirection.y = 0;
                    moveDirection = moveDirection.normalized;
               
                }
                moveTimer += Time.deltaTime;
                rb.MovePosition(transform.position + moveDirection * moveSpeed * slowFactor * Time.deltaTime);
               

                if (moveTimer >= 15 || (targets[diemdich].position - transform.position).magnitude < 1) { 
                    isMoving = false;
                    Debug.Log("páu");
                    StartCoroutine(StopForBot());
                }
            }
            else
            {
                
                isMoving = true;
            }

        }


    }
    IEnumerator StopForBot()
    {
        isStopped = true;
        yield return new WaitForSeconds(3f);
        moveTimer = 0f;
        isStopped = false;
        moveDirection = targets[Random.Range(0, targets.Count)].position.normalized;
        diemdich = Random.Range(0, targets.Count);
        OnDrawGizmos();
    }
    IEnumerator StopForTrick()
    {
        isStopped = true;
        yield return new WaitForSeconds(1f);
       
        isStopped = false;
        moveDirection = new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)).normalized;
        diemdich = Random.Range(0, targets.Count);

    }
    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, targets[diemdich].position, Color.red);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {

           // moveDirection = targets[Random.Range(0, targets.Count)].position.normalized;
            moveDirection = new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)).normalized;
        }
        if ( other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StopForTrick());
           
        }
        if (other.gameObject.CompareTag("Bots"))
        {
            moveDirection = new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)).normalized;
        }

    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
           // moveDirection = targets[Random.Range(0, targets.Count)].position.normalized;
            moveDirection = new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)).normalized;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine (StopForTrick());
        }
        if (other.gameObject.CompareTag("Bots"))
        {
            moveDirection = new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)).normalized;
        }
    }
  
}