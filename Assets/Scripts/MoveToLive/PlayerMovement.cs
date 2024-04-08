using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace minhai
{
    public class PlayerMovement : MonoBehaviour
    {
        public GameObject player, panelLose, round;
        bool isDrag;
        Rigidbody rigidbody;
        float moveSpeed = 5;
        Vector3 moveDirection = Vector3.zero;
        public FloatingJoystick fj;


        void Start()
        {
            rigidbody = player.GetComponent<Rigidbody>();
            DOTween.SetTweensCapacity(200, 125);
        }

        void Update()
        {

            //rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            if (Input.GetMouseButtonDown(0))
            {
                isDrag = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDrag = false;
            }
            if (isDrag == true)
            {
                moveDirection.x = fj.Direction.x;
                moveDirection.z = fj.Direction.y;

                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                player.transform.rotation = targetRotation;
                rigidbody.MovePosition(player.transform.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
            }


            if (player.transform.position.y < -3)
            {
                panelLose.SetActive(true);
                round.SetActive(false);
            }

        }

    }
}

