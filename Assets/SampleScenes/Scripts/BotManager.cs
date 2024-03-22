using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
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
    public Transform tfrmbot;
    int indexLimit;
    float time;

   public void RandomOrder()
    {
        while (listBot.Count != 0)
        {
            int random = Random.Range(0, listBot.Count);
            listBotRandom.Add(listBot[random]);
            listBot.RemoveAt(random);
        }
        StartGame();
    }

    void StartGame()
    {
        float time = Random.Range(3, 4);
        int randomLimit = Random.Range(1, 4);
        indexLimit += randomLimit;
        DOVirtual.DelayedCall(time, () =>
        {
            listBotRandom[0].GetComponent<BotHandler>().Play(indexLimit);
        }).OnComplete(() =>
        {
            time = Random.Range(2, 5);
            randomLimit = Random.Range(1, 4);
            indexLimit += randomLimit;
            DOVirtual.DelayedCall(time, () =>
            {
                listBotRandom[1].GetComponent<BotHandler>().Play(indexLimit);
            }).OnComplete(() =>
            {
                time = Random.Range(2, 5);
                randomLimit = Random.Range(1, 4);
                indexLimit += randomLimit;
                DOVirtual.DelayedCall(time, () =>
                {
                    listBotRandom[2].GetComponent<BotHandler>().Play(indexLimit);
                }).OnComplete(() =>
                {
                    time = Random.Range(2, 5);
                    randomLimit = Random.Range(1, 4);
                    indexLimit += randomLimit;
                    DOVirtual.DelayedCall(time, () =>
                    {
                        listBotRandom[3].GetComponent<BotHandler>().Play(indexLimit);
                    });
                });
            });
        });
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
    /*[Header("Bien chung")]
    public bool check = false;
    public int direction = 0;
    public int currentIndex = 0;
    public bool kiemtraNhayHet = true;
    //Nhay lan luot tung o
    IEnumerator IQLBot()
    {

        check = false;
        kiemtraNhayHet = false;
        float timedelay = 0.5f;
        for (int i = 0; i < listBot.Count; i++)
        {
            yield return new WaitForSeconds(timedelay);
            listBot[i].Jump();

        }
        yield return null;
        kiemtraNhayHet = true;
        currentIndex++;
    }
    IEnumerator TesBot()
    {
        yield return new WaitForSeconds(4f);
        while (currentIndex < listSai.Count)
        {
            check = false;
            //kiemtraNhayHet = false;
            float timedelay = 0.5f;
            for (int i = 0; i < listBot.Count; i++)
            {
                yield return new WaitForSeconds(timedelay);
                listBot[i].Jump();

            }
            yield return null;
            kiemtraNhayHet = true;
            currentIndex++;
        }
    }

    IEnumerator IJump()
    {
        yield return new WaitForSeconds(4f);
        while (currentIndex < listSai.Count)
        {
            if (kiemtraNhayHet == true)
            {
                StartCoroutine(IQLBot());

            }
            yield return null;
        }
        yield return null;
    }*/
}
