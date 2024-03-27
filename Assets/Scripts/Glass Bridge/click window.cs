using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathPointClickHandler : MonoBehaviour
{
    public int pathIndex; // Ch? s? c?a ???ng ?i
    private bool hasBeenVisited = false; // Tr?ng th�i c?a �: true n?u ?� ???c ?i qua, false n?u ch?a
    bool canClick = true;
    static bool isNextTurn;
    public BotManager botManager;


    private void Start()
    {
        isNextTurn = false;
        GameObject obj = GameObject.Find("BotManager");
        if (obj != null)
        {
            botManager = obj.GetComponent<BotManager>();

        }
    }
    void OnMouseDown()
    {

        /*Debug.LogError("is start"+ GameManager.isStart.ToString());
        Debug.LogError("is win"+ CountDown.isWin.ToString());*/
        //Debug.LogError("index player " + Player.index );
        //Debug.Log("t "+GameManager.isStart + " xxxxxxxxxxxxxxxx " + canClick + "cou "+ CountDown.isWin);
        if (Player.index + 1 == int.Parse(gameObject.tag) && canClick && GameManager.isStart == true && CountDown.isWin == false)
            {
            if(isNextTurn == false)
            {
                isNextTurn = true;
                botManager.NextTurn();
            }
                Player playerMoveScript = FindObjectOfType<Player>();
                if (playerMoveScript != null)
                {
                    playerMoveScript.Jump(pathIndex);
                if(canClick )
                {
                    StartCoroutine(WaitForNextClick());
                }                 
                }
            }


    }
    IEnumerator WaitForNextClick()
    {
        // ??t canClick th�nh false ?? ng?n ch?n vi?c ?n trong khi ?ang ch?
        canClick = false;

        // Ch? 1 gi�y tr??c khi cho ph�p ?n ti?p theo
        yield return new WaitForSeconds(1f);

        // Sau khi ch? xong, ??t l?i canClick th�nh true ?? cho ph�p ?n
        canClick = true;
    }


}

