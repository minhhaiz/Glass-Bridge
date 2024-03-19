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

    Dictionary<int, bool> luuOdung = new Dictionary<int, bool>();
    public Rigidbody rb;
    
    public Transform tfrmbot;

 
  
    private bool isPlayerAtTarget = false;

    private void Awake()
    {
        tfrmbot = GetComponent<Transform>();
        StartCoroutine(Run());
    }

    Coroutine jumpCoroutine;
   
    IEnumerator Run()
    {
        
        yield return new WaitForSeconds(15f);
        for (int i = 0; i < posLeft.Count; i++) 
        {
            Jump();
            yield return new WaitForSeconds(2f);
        }
     
    }
    private int index;

    public void Jump()
    {
        if (tfrmbot.position.y < 19)
        {
            return;
        }
        //i==0 L i==1 R
        int i = Random.Range(0, 2);
        if (isPlayerAtTarget == false)
        {
            isPlayerAtTarget = true;
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
            index++;
        }
    }
    /*public void Jump()
    {
        index = BotManager.instance.currentIndex;
        if (tfrmbot.position.y < 19)
        {
            return;
        }        
        // int i = Random.Range(0, 2);
        int i = 0;
        i = Random.Range(0, 2);
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

                Vector3[] path = new Vector3[]
                {
                 tfrmbot.position,
            new Vector3(posLeft[index].position.x + 2f , transform.position.y + 1f, posLeft[index].position.z ), // ?i?m cao nh?t c?a nh?y
                    posLeft[index].transform.position
                 };

                tfrmbot.DOPath(path, 0.3f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
                {
                    isPlayerAtTarget = false;
                }); ;

            }
            else
            {

                Vector3[] path = new Vector3[]
            {
                 tfrmbot.position,
            new Vector3(posRight[index].position.x + 2f , transform.position.y + 1f, posRight[index].position.z ), // ?i?m cao nh?t c?a nh?y
                    posRight[index].transform.position
               };

                tfrmbot.DOPath(path, 0.3f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
                {
                    isPlayerAtTarget = false;
                }); ;
            }
            
      
            isPlayerAtTarget = true;
          
        }
       
    }*/



}

    
