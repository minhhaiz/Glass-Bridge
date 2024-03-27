using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 startPos; // Bi?n l?u v? tr� b?t ??u c?a c? ch? vu?t

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ki?m tra n?u c� �t nh?t m?t c? ch? vu?t tr�n m�n h�nh
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Ki?m tra n?u c? ch? l� c? ch? m?i (b?t ??u vu?t)
            if (touch.phase == TouchPhase.Began)
            {
                // L?u v? tr� b?t ??u c?a c? ch?
                startPos = touch.position;
            }
            // Ki?m tra n?u c? ch? ?� k?t th�c (k?t th�c vu?t)
            else if (touch.phase == TouchPhase.Ended)
            {
                // T�nh to�n vector di chuy?n t? v? tr� b?t ??u ??n v? tr� k?t th�c c?a c? ch?
                Vector2 swipeVector = touch.position - startPos;

                // T�nh to�n h??ng di chuy?n t? vector di chuy?n
                Vector3 moveDirection = new Vector3(swipeVector.x, 0f, swipeVector.y).normalized;

                // �p d?ng l?c di chuy?n cho nh�n v?t
                rb.AddForce(moveDirection * moveSpeed, ForceMode.VelocityChange);
            }
        }
    }
}
