using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.PlayerLoop;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;

public class BotAuto : MonoBehaviour
{
    
    [SerializeField] private List<Transform> posLeft;
    [SerializeField] private List<Transform> posRight;
    [SerializeField] public int delaytime;
    [SerializeField] private GameManager gameManager;
    Dictionary<int, bool> luuOdung = new Dictionary<int, bool>();
    public Rigidbody rb;
    
    public Transform tfrmbot;

 
    public Button buttonL, buttonR;
    private bool isPlayerAtTarget = false;

    private void Awake()
    {
        tfrmbot = GetComponent<Transform>();
     //   jumpCoroutine = StartCoroutine(JumpRoutine());
       
    }


    Coroutine jumpCoroutine;
   
 
    private int index;

    public void Jump()
    {
        index = BotManager.instance.currentIndex;
        if (tfrmbot.position.y < 10)
        {
            
            return;
        }        
        // int i = Random.Range(0, 2);
        int i = 0;
        i=Random.Range(0, 2);
        //gameManager.breckwin[]
        //i == 0 L i== 1 R
        if (BotManager.instance.check)
        {
            i = BotManager.instance.direction;
        }
        else
        {
            if (!BotManager.instance.listSai.Contains(posLeft[index].name))
            {
                
               
                BotManager.instance.check = true;
                BotManager.instance.direction = 0;
                luuOdung.Add(index, true);
            }
            
            if (!BotManager.instance.listSai.Contains(posRight[index].name))
            {


                luuOdung.Add(index, true);
                BotManager.instance.check = true;
                BotManager.instance.direction = 1;
            }
               

        }
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
            
      
            isPlayerAtTarget = true;
          //  jumpCoroutine = StartCoroutine(JumpRoutine());
        }
       
    }
    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1f);
        isPlayerAtTarget = false;
    }


}

    
