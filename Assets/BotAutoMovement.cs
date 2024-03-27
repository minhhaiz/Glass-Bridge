using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAutoMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float changeDirectionInterval = 1f; // Th?i gian gi?a các l?n thay ??i h??ng di chuy?n

    private float timer; // ??m th?i gian
    private Vector3 randomDirection; // H??ng di chuy?n ng?u nhiên

    void Start()
    {
        // Kh?i t?o th?i gian ban ??u
        timer = changeDirectionInterval;

        // Kh?i t?o h??ng di chuy?n ban ??u
        GenerateRandomDirection();
    }

    void Update()
    {
        // Gi?m b?t th?i gian ??m
        timer -= Time.deltaTime;

        // N?u ?ã ??n lúc thay ??i h??ng di chuy?n
        if (timer <= 0)
        {
            // T?o h??ng di chuy?n m?i
            GenerateRandomDirection();

            // Reset timer
            timer = changeDirectionInterval;
        }

        // Di chuy?n bot theo h??ng di chuy?n ng?u nhiên
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }

    void GenerateRandomDirection()
    {
        // T?o m?t h??ng di chuy?n ng?u nhiên
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
