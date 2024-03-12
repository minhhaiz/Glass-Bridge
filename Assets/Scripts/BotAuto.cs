using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.PlayerLoop;

public class Bot : MonoBehaviour
{
    
    [SerializeField] private List<Transform> posLeft;
    [SerializeField] private List<Transform> posRight;
    [SerializeField] public int delaytime;
    public Rigidbody rb;
    
    public Transform tfrmbot;

 
    public Button buttonL, buttonR;
    private bool isPlayerAtTarget = false;

    private void Awake()
    {
        tfrmbot = GetComponent<Transform>();
        jumpCoroutine = StartCoroutine(JumpRoutine());
       
    }


    Coroutine jumpCoroutine;
    IEnumerator JumpRoutine()
    {
                yield return new WaitForSeconds(delaytime);
                Jump();
    }
 
    private int index;

    void Jump()
    {
       if(tfrmbot.position.y < 10)
        {
            return;
        }

        int i = Random.Range(0, 2);

        //i==0 L i==1 R
        if (isPlayerAtTarget == false)
        {
            
            if (i == 0)
            {

                tfrmbot.DOMove(posLeft[index].position, 0.3f).OnComplete(() =>
                {
                    isPlayerAtTarget = false;
                });

            }
            else
            {

                tfrmbot.DOMove(posRight[index].position, 0.3f).OnComplete(() =>
                {
                    isPlayerAtTarget = false;
                });
            }
            index += 1;
            StopCoroutine(jumpCoroutine);
            isPlayerAtTarget = true;
            jumpCoroutine = StartCoroutine(JumpRoutine());
        }
       
    }
    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1f);
        isPlayerAtTarget = false;
    }


}

    
