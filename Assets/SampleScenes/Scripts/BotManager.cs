using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;


public class BotManager : MonoBehaviour
{
    public List<Transform> posLeft;
    public List<Transform> posRight;
    public static BotManager instance;
    public List<string> listDung = new List<string>();
    public List<string> listSai = new List<string>();
    List<GameObject> listBotRandom = new List<GameObject>();
    public List<GameObject> listBot;
    public GameObject player;
    public Transform tfrmbot;
    int indexLimit, index;
    public Text yourTurrn;
    float time;
    public TextMeshProUGUI tb;

   public void RandomOrder()
    {
        tb.gameObject.SetActive(false);
        while (listBot.Count != 0)
        {
            int random = Random.Range(0, listBot.Count);
            Debug.Log("random" + random);
            listBotRandom.Add(listBot[random]);
            listBot.RemoveAt(random);
        }
        GameManager.isStart = false;
        for (int i = 0; i < listBotRandom.Count; i++)
        {
            Debug.LogError(listBotRandom[i]);
            if (listBotRandom[i] == player)
            {
                yourTurrn.gameObject.SetActive(true);
                yourTurrn.text = "YourTurn : " + (i+1).ToString();
            }
        }
        StartGame();
    }

    public void NextTurn()
    {
        Debug.Log("ashjdgashjdgashjdgahsdahjsd");
        if(listBotRandom.Count != 0)
        {
            if (listBotRandom[index].name == player.name)
            {
                
                DOVirtual.DelayedCall(2f, delegate
                {
                    GameManager.isStart = true;
                    index++;
                    MoveText();
                });
            }
            else
            {

                int randomLimit = Random.Range(1, 3);
                indexLimit += randomLimit;
                DOVirtual.DelayedCall(2, () =>
                {
                    listBotRandom[index].GetComponent<BotHandler>().Play(indexLimit);
                    index++;
                    NextTurn();
                });
            }
        }
    }

    void StartGame()
    {
        NextTurn();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //StartCoroutine(IJump());
        //StartCoroutine(TesBot());
       // DOVirtual.DelayedCall(6f, RandomOrder);
    }
    
    void MoveText()
    {
        tb.gameObject.SetActive(true);
        // Vector3 oldPosition = tb.rectTransform.position;
        //Vector3 newPosition = new Vector3(oldPosition.x + 00f, oldPosition.y , oldPosition.z);

        // tb.rectTransform.DOMoveX(newPosition.x, 1f).SetEase(Ease.Linear).OnComplete(RetractText);
        StartCoroutine(RetractText());
    }
    IEnumerator RetractText()
    {
        //Vector3 oldPosition = tb.rectTransform.position;

        //tb.rectTransform.DOMoveX(oldPosition.x, 1f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);

        tb.gameObject.SetActive(false);
    }
}
