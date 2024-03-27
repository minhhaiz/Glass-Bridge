using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector2 startPos; // Bi?n l?u v? trí b?t ??u c?a c? ch? vu?t

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ki?m tra n?u có ít nh?t m?t c? ch? vu?t trên màn hình
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Ki?m tra n?u c? ch? là c? ch? m?i (b?t ??u vu?t)
            if (touch.phase == TouchPhase.Began)
            {
                // L?u v? trí b?t ??u c?a c? ch?
                startPos = touch.position;
            }
            // Ki?m tra n?u c? ch? ?ã k?t thúc (k?t thúc vu?t)
            else if (touch.phase == TouchPhase.Ended)
            {
                // Tính toán vector di chuy?n t? v? trí b?t ??u ??n v? trí k?t thúc c?a c? ch?
                Vector2 swipeVector = touch.position - startPos;

                // Tính toán h??ng di chuy?n t? vector di chuy?n
                Vector3 moveDirection = new Vector3(swipeVector.x, 0f, swipeVector.y).normalized;

                // Áp d?ng l?c di chuy?n cho nhân v?t
                rb.AddForce(moveDirection * moveSpeed, ForceMode.VelocityChange);
            }
        }
    }
}
