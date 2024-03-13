using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    public static BotManager instance;
    public List<string>listDung=new List<string>(); 
    public List<string> listSai = new List<string>();
    public List<BotAuto> listBot;
    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(IJump());
    }
    [Header("Bien chung")]
    public bool check = false;
    public int direction = 0;
    public int currentIndex = 0;
    public bool kiemtraNhayHet=true;
    //Nhay lan luot tung o
    IEnumerator IQLBot()
    {
        check = false;
        Debug.Log("xxxx");
        kiemtraNhayHet = false;
        for(int i=0;i<listBot.Count;i++)
        {
            yield return new WaitForSeconds(2f);
            listBot[i].Jump();
           
        }
        yield return null;
        kiemtraNhayHet = true;
        currentIndex++;
    }
    IEnumerator IJump()
    {
        while (currentIndex < listSai.Count)
        {
            if (kiemtraNhayHet == true)
            {
                StartCoroutine(IQLBot());
            }
            yield return null;
        }
        yield return null;
    }
}
