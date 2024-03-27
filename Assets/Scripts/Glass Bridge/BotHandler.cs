using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHandler : MonoBehaviour
{
    public BotManager botManager;
    int indexGlass;
    public Transform Dichk;
    public void Play(int indexLimit)
    {
        
        Jump(indexLimit);
    }

    void Jump(int indexLimit)
    {
     

        float duration = Random.Range(1.5f, 2f);
        DOVirtual.DelayedCall(duration, () =>
        {
            if (indexGlass == 7)
            {
                transform.DOMove(Dichk.position, 0.5f).OnComplete(() =>
                {
                    transform.DORotate(new Vector3(0, 90, 0), 0.5f);
                    transform.GetComponent<Animator>().SetBool("isWin", true);
                });
            }
            else if (indexGlass < indexLimit)
            {
                if (GameManager.listGlass[indexGlass] == true)
                {
                 //   Debug.Log("pos left " + botManager.posLeft[indexGlass].position);

                    transform.DOMove(botManager.posLeft[indexGlass].position, 0.5f);
                }
                else if (GameManager.listGlass[indexGlass] == false)
                {
                   // Debug.Log("pos right " + botManager.posLeft[indexGlass].position);

                    transform.DOMove(botManager.posRight[indexGlass].position, 0.5f);
                }
                indexGlass++;
                Jump(indexLimit);
            }
            else
            {
              //  Debug.Log("--------------- " + indexGlass);
                if (GameManager.listGlass[indexGlass] == true)
                {
                    transform.DOMove(botManager.posRight[indexGlass].position, 0.5f);
                }
                else if (GameManager.listGlass[indexGlass] == false)
                {
                    transform.DOMove(botManager.posLeft[indexGlass].position, 0.5f);
                }
            }
        });
    }
}
