using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotAutoMovement : MonoBehaviour
{
    float moveSpeed = 40;
    public float moveDuration = 1f; // Thời gian di chuyển (giây)
    public float restDuration = 2f; // Thời gian nghỉ (giây)
    public float speeder;

    private Vector3 randomDirection; // Hướng di chuyển ngẫu nhiên
    private Rigidbody rb; // Rigidbody của nhân vật

    void Start()
    {
        // Lấy Rigidbody của nhân vật
        rb = GetComponent<Rigidbody>();
        GenerateRandomDirection();
        // Bắt đầu coroutine để di chuyển bot
    }

    private void Update()
    {
        speeder = rb.velocity.magnitude;
        if (speeder < 2 )
        {
            rb.AddForce(randomDirection * moveSpeed, ForceMode.Force);
        }

        
    }

    void GenerateRandomDirection()
    {
        // Tạo một hướng di chuyển ngẫu nhiên
        randomDirection = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)).normalized;
    }
}