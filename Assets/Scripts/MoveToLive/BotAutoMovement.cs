using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class BotAutoMovement : MonoBehaviour
{
    public float moveSpeed = 4f; // Tốc độ di chuyển
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
    float distance;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //moveDirection = new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)).normalized;
        moveDirection = targets[Random.Range(0, targets.Count)].position.normalized;
        moveDirection.y = 0;
        diemdich =  Random.Range(0, targets.Count);
             

    }

    void FixedUpdate()
    {

        distance = Vector3.Distance(transform.position, targets[diemdich].position);
        if (!isStopped)
        {
           
            if (isMoving)
            {
                if (moveTimer >= 10)
                {

                    moveDirection = targets[diemdich].position - transform.position;
                    moveDirection.y = 0;
                    moveDirection = moveDirection.normalized;

                }
                if (transform.position == targets[diemdich].position)
                {
                    Debug.Log(" ổn ");
                    isStopped = true;
                }
                moveTimer += Time.deltaTime;
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                tfbot.rotation = targetRotation;

                rb.MovePosition(transform.position + moveDirection * moveSpeed * slowFactor * Time.deltaTime);

                if (moveTimer >= 14 ||  distance <= 1f) { 
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
        moveDirection = new Vector3(Random.Range(-10, 10), 0f, Random.Range(-10, 10)).normalized;
        diemdich = Random.Range(0, targets.Count);
        OnDrawGizmos();
    }
    IEnumerator StopForTrick()
    {
        isStopped = true;
        yield return null;
       
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
            float avoidDirection = Random.Range(-90f, 90f);

          
           
        }
        if (other.gameObject.CompareTag("Bots"))
        {

            //moveDirection = Random.Range(-90f, 90f);

            // moveDirection = Random.insideUnitSphere;
            moveDirection.y = 0f;

            /*transform.Rotate(moveDirection * 30f * Time.deltaTime);*/
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
         /*   moveDirection = - moveDirection;
           // moveDirection = Random.insideUnitSphere;
            moveDirection.y = 0f;*/

/*            transform.Rotate(moveDirection * 45f * Time.deltaTime);
*/        
        }
    }
  
}