using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{

    public Rigidbody rb;
    public float jumpForce = 15f;
    public Transform tfrm;

    public Button buttonL, buttonR;
    private bool isPlayerAtTarget = false;
    public GameObject panelwin, buttL, buttR;
    private void Awake()
    {
        tfrm=GetComponent<Transform>();
    }
    private void Update()
    {

       
    }


    [SerializeField] private List<Transform> posLeft;
    [SerializeField] private List<Transform> posRight;
    private int index;
   
    public void Jump(int i)
    {

       //i==0 L i==1 R
        if(isPlayerAtTarget==false)
        {
            isPlayerAtTarget = true;
            if (i == 0)
            {
                // listPos[index]
                //tfrm.position = posLeft[index].position;
                // rb.transform.DOMove(posLeft[index].position, 0.8f);
              
                
                tfrm.DOMove(posLeft[index].position, 0.3f).OnComplete(() =>
                {
                    isPlayerAtTarget = false;
                });

            }
            else
            {
                //tfrm.position = posRight[index].position;
                //rb.transform.DOMove(posLeft[index].position, 0.8f);
                tfrm.DOMove(posRight[index].position, 0.3f).OnComplete(() =>
                {
                    isPlayerAtTarget = false;
                });
            }
            index += 1;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra xem có va chạm với platform hay không
        if (collision.gameObject.CompareTag("Target"))
        {
            Win();
        }
    }
    void Win()
    {
        panelwin.SetActive(true);
        buttL.SetActive(false);
        buttR.SetActive(false);
    }
    

}

