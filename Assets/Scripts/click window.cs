using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathPointClickHandler : MonoBehaviour
{
    public int pathIndex; // Ch? s? c?a ???ng ?i
    private bool hasBeenVisited = false; // Tr?ng thái c?a ô: true n?u ?ã ???c ?i qua, false n?u ch?a
    bool canClick = true;

    void OnMouseDown()
    {

       /* Debug.LogError(int.Parse(gameObject.tag));
        Debug.LogError("index player " + Player.index);*/
            if (Player.index + 1 == int.Parse(gameObject.tag) && canClick)
            {
                Player playerMoveScript = FindObjectOfType<Player>();
                if (playerMoveScript != null)
                {
                    playerMoveScript.Jump(pathIndex);
                    StartCoroutine(WaitForNextClick());
                }
            }


    }
    IEnumerator WaitForNextClick()
    {
        // ??t canClick thành false ?? ng?n ch?n vi?c ?n trong khi ?ang ch?
        canClick = false;

        // Ch? 1 giây tr??c khi cho phép ?n ti?p theo
        yield return new WaitForSeconds(1f);

        // Sau khi ch? xong, ??t l?i canClick thành true ?? cho phép ?n
        canClick = true;
    }


}

