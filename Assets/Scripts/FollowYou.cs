using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowYou : MonoBehaviour
{
    public Transform playerTransform; // Tham chi?u t?i nhân v?t

    void Update()
    {

        transform.position = playerTransform.position;
        transform.Translate(Vector3.up * 0.2f, Space.World);
    }
}
