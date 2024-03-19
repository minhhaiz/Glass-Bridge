using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;


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
        index = 0;
        tfrm=GetComponent<Transform>();
        CreateWindowK();
    }
   

    [SerializeField] public List<Transform> posLeft;
    [SerializeField] public List<Transform> posRight;
    public static int index;
   
    public void Jump(int i)
    {
        if(tfrm.position.y < 19)
        {
            return;
        }
       //i==0 L i==1 R
        if(isPlayerAtTarget==false)
        {
            isPlayerAtTarget = true;
            if (i == 0)
            {
                // listPos[index]
                //tfrm.position = posLeft[index].position;
                // rb.transform.DOMove(posLeft[index].position, 0.8f);
                /*    Vector3[] path = new Vector3[]
                 {
                     tfrm.position,
                new Vector3(posLeft[index].position.x - 1f , transform.position.y + 1f, posLeft[index].position.z), // Điểm cao nhất của nhảy
                        posLeft[index].transform.position
                    };

                    tfrm.DOPath(path, 0.3f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        isPlayerAtTarget = false;
                    }); ;*/
                tfrm.DOMove(posLeft[index].position, 0.3f).OnComplete(() =>
                {
                    isPlayerAtTarget = false;
                   
                    
                });

            }
            else
            {
                //tfrm.position = posRight[index].position;
                //rb.transform.DOMove(posLeft[index].position, 0.8f);
                /*      Vector3[] path = new Vector3[]
             {
                       tfrm.position,
                  new Vector3(posRight[index].position.x - 1f , transform.position.y + 1f, posRight[index].position.z), // Điểm cao nhất của nhảy
                          posRight[index].transform.position
                };

                      tfrm.DOPath(path, 0.3f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
                      {
                          isPlayerAtTarget = false;
                      }); ;*/

                tfrm.DOMove(posRight[index].position, 0.3f).OnComplete(() =>
                {
                    isPlayerAtTarget = false;
                });
            }
            index ++;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra xem có va chạm với platform hay không
        if (collision.gameObject.CompareTag("8"))
        {
            transform.DORotate(new Vector3(0, 90, 0), 0.5f);
            transform.GetComponent<Animator>().SetBool("isWin", true);

            Win();
        }
    }
    void Win()
    {
        panelwin.SetActive(true);
        buttL.SetActive(false);
        buttR.SetActive(false);
    }
    

    void CreateWindowK()
    {
        foreach(Transform target in posLeft)
        {
            Collider collider = target.GetComponent<Collider>();
            if(collider != null)
            {
                collider.gameObject.AddComponent<PathPointClickHandler>().pathIndex  = 0;
            }
        }

        foreach (Transform target in posRight)
        {
            Collider collider = target.GetComponent<Collider>();
            if (collider != null)
            {
                collider.gameObject.AddComponent<PathPointClickHandler>().pathIndex = 1;
            }
        }
    }
    




}


