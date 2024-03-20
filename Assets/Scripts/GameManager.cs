using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public List<GameObject> window1, window2, window3, window4, window5, window6, window7;
    public GameObject panelwin, panellose, buttL, buttR, finishPl, player, cam, panelPause, LV,TimeCount,Coins, butpause;
    public BreakableWindow breakableWindow = new BreakableWindow();
    Color redColor = Color.red;
    public List<GameObject> breckwin = new List<GameObject>();
    Dictionary<Renderer, Color> initialColor = new Dictionary<Renderer, Color>();
    public static bool[] listGlass = new bool[7];
    public static bool isStart;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        StartGame();
    }
    void Start()
    {
        isStart = false;
    }
    void StartGame()
    {
        cam.transform.DOMoveX(25, 2f);
        cam.transform.DORotate(new Vector3(40, -90, 0), 2f);
        cam.GetComponent<Camera>().DOOrthoSize(10, 2f).OnComplete(() =>
        {
            CreateGlass();
            luuColor();
        }
        );


    }
    private void Update()
    {
      if(player.transform.position.y < 19)
        {
            butpause.SetActive(false);
        }
    }

    void CreateGlass()
    {
        int indexGlass = -1;
        buttL.SetActive(false);
        buttR.SetActive(false);


        int inRan = Random.Range(0, 2);


        window1[inRan].AddComponent<BreakableWindow>();
        window1[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
        window1[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
        window1[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
        window1[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
        breckwin.Add(window1[inRan]);
        listGlass[++indexGlass] = inRan == 0 ? false : true;
        BotManager.instance.listSai.Add(window1[inRan].name);

        inRan = Random.Range(0, 2);
        window2[inRan].AddComponent<BreakableWindow>();
        window2[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
        window2[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
        window2[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
        window2[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
        breckwin.Add(window2[inRan]);
        listGlass[++indexGlass] = inRan == 0 ? false : true;

        BotManager.instance.listSai.Add(window2[inRan].name);

        inRan = Random.Range(0, 2);
        window3[inRan].AddComponent<BreakableWindow>();
        window3[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
        window3[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
        window3[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
        window3[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
        breckwin.Add(window3[inRan]);
        listGlass[++indexGlass] = inRan == 0 ? false : true;
        BotManager.instance.listSai.Add(window3[inRan].name);

        inRan = Random.Range(0, 2);
        window4[inRan].AddComponent<BreakableWindow>();
        window4[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
        window4[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
        window4[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
        window4[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
        window4[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
        breckwin.Add(window4[inRan]);
        listGlass[++indexGlass] = inRan == 0 ? false : true;
        BotManager.instance.listSai.Add(window4[inRan].name);

        inRan = Random.Range(0, 2);
        window5[inRan].AddComponent<BreakableWindow>();
        window5[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
        window5[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
        window5[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
        window5[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
        breckwin.Add(window5[inRan]);
        listGlass[++indexGlass] = inRan == 0 ? false : true;
        BotManager.instance.listSai.Add(window5[inRan].name);

        inRan = Random.Range(0, 2);
        window6[inRan].AddComponent<BreakableWindow>();
        window6[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
        window6[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
        window6[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
        window6[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
        breckwin.Add(window6[inRan]);
        listGlass[++indexGlass] = inRan == 0 ? false : true;
        BotManager.instance.listSai.Add(window6[inRan].name);

        inRan = Random.Range(0, 2);
        window7[inRan].AddComponent<BreakableWindow>();
        window7[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
        window7[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
        window7[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
        window7[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
        breckwin.Add(window7[inRan]);
        listGlass[++indexGlass] = inRan == 0 ? false : true;
        BotManager.instance.listSai.Add(window7[inRan].name);
        BotManager.instance.listSai.Add(finishPl.name);
    }
    // Update is called once per frame
    void luuColor()
    {
        foreach (GameObject obj in breckwin)
        {
            if (obj != null)
            {
                MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    initialColor[renderer] = renderer.material.color;
                }
            }
        }
        StartCoroutine(BlinkBreckGlass());
        DOVirtual.DelayedCall(4.2f, delegate
        {
            isStart = true;
            Debug.Log("asdyuatsdyuastdyuastdyuastdyastudytasudt " + isStart);
        });
    }


    IEnumerator BlinkBreckGlass()
    {
        float timeElapsed = 0f;
        while (timeElapsed < 1f)
        {
            foreach (GameObject obj in breckwin)
            {
                if (obj != null)
                {
                    Renderer renderer = obj.GetComponent<Renderer>();

                    renderer.material.color = (renderer.material.color == redColor) ? initialColor[renderer] : redColor;
                   // obj.SetActive(false);
                    yield return new WaitForSeconds(0.6f);
                    renderer.material.color = initialColor[renderer];

                }
            }
           // yield return new WaitForSeconds(1f);
            timeElapsed += 1f;
        }
        foreach (GameObject obj in breckwin)
        {
            if (obj != null)
            {
                Renderer renderer = obj.GetComponent<Renderer>();

                renderer.material.color = initialColor[renderer];
               // obj.SetActive(true);
                
            }
        }
        
         // buttL.SetActive(true);



         // buttR.SetActive(true);
    }
   
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Pause()
    {
        CountDown.isWin = true;
        Coins.SetActive(false);
        panelPause.SetActive(true);
        panellose.SetActive(false);
        panelwin.SetActive(false);
        DOTween.PauseAll();
        TimeCount.SetActive(false);
        buttL.SetActive(false);
        buttR.SetActive(false);


    }
    public void Resume()
    {
        Coins.SetActive(true);
        CountDown.isWin = false;
        Time.timeScale = 1f;
        panelPause.SetActive(false);
        panellose.SetActive(false);
        panelwin.SetActive(false);
        TimeCount.SetActive(true);
        DOTween.PlayAll();
        //buttL.SetActive(true);
        //buttR.SetActive(true);

    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}
