using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TestB : MonoBehaviour
{
    public List<Transform> targetPositions; // List các vị trí GameObject mà bot sẽ di chuyển đến
    public float moveSpeed = 2f; // Tốc độ di chuyển của bot
    private bool isMoving = false; // Trạng thái di chuyển của bot
    private Rigidbody rb; // Reference tới Rigidbody của bot
    int randomIndex,diem;
    Transform randomPosition;
    private float moveTimer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Lấy reference tới Rigidbody của bot

        MoveToRandomPosition();
        randomIndex = Random.Range(0, targetPositions.Count);
        diem = Random.Range(0, targetPositions.Count);
    }

    void FixedUpdate()
    {
        // Kiểm tra nếu bot không di chuyển
        if (!isMoving && transform.position.y >= 0)
        {
            MoveToRandomPosition();
        }
        
    }

    void MoveToRandomPosition()
    {
        
        randomPosition = targetPositions[randomIndex];

        Vector3 direction = (randomPosition.position - transform.position);
        direction.y = 0f;
        
       
        transform.rotation = Quaternion.LookRotation(direction);

        rb.MovePosition( rb.transform.position +  direction  * 0.5f * Time.fixedDeltaTime);
        moveTimer += Time.deltaTime;
        Debug.Log(Vector3.Distance(transform.position, targetPositions[randomIndex].position));
        if (Vector3.Distance(transform.position, targetPositions[randomIndex].position) <= 2f)
        {
        
            randomIndex = Random.Range(0, targetPositions.Count);
        }

        if (moveTimer >= 11)
        {

            randomIndex = diem;
            
        }
        if(moveTimer > 14f) {

           
            StartCoroutine(DelayBeforeNextMove());
        }
    }

    IEnumerator DelayBeforeNextMove()
    {

        isMoving = true;
        yield return new WaitForSeconds(3f);
        moveTimer = 0f;
        isMoving = false;
        diem = Random.Range(0, targetPositions.Count);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("lodđ");
            MoveToRandomPosition();
        }
        if (other.gameObject.CompareTag("Bots"))
        {
            MoveToRandomPosition();
        }
    }
}
