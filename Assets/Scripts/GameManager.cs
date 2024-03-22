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
    public GameObject panelwin, panellose, buttL, buttR, finishPl, player, cam, panelPause, LV,TimeCount,Coins, butpause, drone;
    public BreakableWindow breakableWindow = new BreakableWindow();
    Color redColor = Color.red;
    public List<GameObject> breckwin = new List<GameObject>();
    BotManager bot;
    Dictionary<Renderer, Color> initialColor = new Dictionary<Renderer, Color>();
    public static bool[] listGlass = new bool[7];
    public static bool isStart;
    public bool nhay = false;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        TimeCount.SetActive(false);
       //StartGame();
    }
    void Start()
    {
        isStart = false;
    }
    public void StartGame()
    {
        cam.transform.DOMoveX(25, 2f);
        cam.transform.DORotate(new Vector3(40, -90, 0), 2f);
        cam.GetComponent<Camera>().DOOrthoSize(10, 2f).OnComplete(() =>
        {
            CreateGlass();
            if (bot == null)
            {
                bot = GameObject.FindObjectOfType<BotManager>();
            }
            bot.RandomOrder();

            CountDown.isWin = false;
            TimeCount.SetActive(true);
        }
        );
       

    }
    public void StartGameForcan()
    {
        cam.transform.DOMoveX(25, 2f);
        cam.transform.DORotate(new Vector3(40, -90, 0), 2f);
        cam.GetComponent<Camera>().DOOrthoSize(10, 2f).OnComplete(() =>
        {
            CreateGlass();
            luuColor();
            CountDown.isWin = false;
            TimeCount.SetActive(true);
            if (bot == null)
            {
                bot = GameObject.FindObjectOfType<BotManager>();
            }
            bot.RandomOrder();
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
    public void luuColor()
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
        yield return new WaitForSeconds(1f);
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


     IEnumerator RadarBlink()
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
        float timeElapsed = 0f;
        while (timeElapsed < 1f)
        {
            foreach (GameObject obj in breckwin)
            {
                if (obj != null)
                {
                    Renderer renderer = obj.GetComponent<Renderer>();

                    renderer.material.color = (renderer.material.color == redColor) ? initialColor[renderer] : redColor;

                }
            }
             yield return new WaitForSeconds(3f);
            timeElapsed += 1f;
        }
        foreach (GameObject obj in breckwin)
        {
            if (obj != null)
            {
                Renderer renderer = obj.GetComponent<Renderer>();

                renderer.material.color = initialColor[renderer];
             

            }
        }
        isStart = true;

    }
    public void Radar()
    {
        StartCoroutine(RadarBlink());
    }


    IEnumerator RunDrone()
    {
        /*float timeElapsed = 0f;
        while (timeElapsed < 1f)
        {
            foreach (GameObject obj in breckwin)
            {
                if (obj != null)
                {
                    Renderer renderer = obj.GetComponent<Renderer>();
                    drone.transform.DOMove(new Vector3(obj.transform.position.x, obj.transform.position.y + 0.5f, obj.transform.position.z), 0.3f);
                    yield return new WaitForSeconds(0.5f);
                    // renderer.material.color = (renderer.material.color == redColor) ? initialColor[renderer] : redColor;
                    obj.SetActive(false);
                    yield return new WaitForSeconds(0.5f);
                }
            }
            yield return new WaitForSeconds(1f);
            drone.transform.DOMove(new Vector3(0, 40f, 0), 1f);
            timeElapsed += 1f;
        }*/
        yield return new WaitForSeconds(2f);
        int randombreck = Random.Range(3, 7);
        Transform hi = breckwin[randombreck].transform;
        drone.transform.DOMove(hi.position, 1f);
        yield return new WaitForSeconds(1f);
        breckwin[randombreck].SetActive(false);
        drone.transform.DOMove(new Vector3(0, 40f, 0), 1f);
    }

    public void Drone()
    {
        StartCoroutine(RunDrone());
    }

}
