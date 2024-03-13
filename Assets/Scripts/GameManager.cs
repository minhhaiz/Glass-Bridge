using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public List<GameObject> window1, window2, window3, window4, window5, window6, window7;
    public GameObject panelwin, panellose, buttL, buttR, finishPl, player;
    public BreakableWindow breakableWindow = new BreakableWindow();
    Color redColor = Color.red;
    public List<GameObject> breckwin = new List<GameObject>();
    Dictionary<Renderer, Color> initialColor = new Dictionary<Renderer, Color>();
    void Start()
    {
        CreateGlass();
        luuColor();
    }
    private void Update()
    {
        if(player.transform.position == finishPl.transform.position)
        {
            Win();
        }
    }
   
    void CreateGlass()
    {
        buttL.SetActive(false);
        buttR.SetActive(false); 
        for (int i = 0; i < 7; i++)
        {

            int inRan = Random.Range(0, 2);
            if (i == 0)
            {

                window1[inRan].AddComponent<BreakableWindow>();
                window1[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
                window1[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
                window1[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
                window1[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
                breckwin.Add(window1[inRan]);
                BotManager.instance.listSai.Add(window1[inRan].name);

            }
            if (i == 1)
            {
                window2[inRan].AddComponent<BreakableWindow>();
                window2[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
                window2[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
                window2[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
                window2[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
                breckwin.Add(window2[inRan]);
                BotManager.instance.listSai.Add(window2[inRan].name);

            }
            if (i == 2)
            {
                window3[inRan].AddComponent<BreakableWindow>();
                window3[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
                window3[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
                window3[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
                window3[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
                breckwin.Add(window3[inRan]);
                BotManager.instance.listSai.Add(window3[inRan].name);
            }
            if (i == 3)
            {
                window4[inRan].AddComponent<BreakableWindow>();
                window4[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
                window4[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
                window4[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
                window4[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
                breckwin.Add(window4[inRan]);
                BotManager.instance.listSai.Add(window4[inRan].name);
            }
            if (i == 4)
            {
                window5[inRan].AddComponent<BreakableWindow>();
                window5[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
                window5[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
                window5[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
                window5[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
                breckwin.Add(window5[inRan]);
                BotManager.instance.listSai.Add(window5[inRan].name);
            }
            if (i == 5)
            {
                window6[inRan].AddComponent<BreakableWindow>();
                window6[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
                window6[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
                window6[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
                window6[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
                breckwin.Add(window6[inRan]);
                BotManager.instance.listSai.Add(window6[inRan].name);
            }
            if (i == 6)
            {
                window7[inRan].AddComponent<BreakableWindow>();
                window7[inRan].GetComponent<BreakableWindow>().panelLose = breakableWindow.panelLose;
                window7[inRan].GetComponent<BreakableWindow>().buttL = breakableWindow.buttL;
                window7[inRan].GetComponent<BreakableWindow>().buttR = breakableWindow.buttR;
                window7[inRan].GetComponent<BreakableWindow>().breakingSound = breakableWindow.breakingSound;
                breckwin.Add(window7[inRan]);
                BotManager.instance.listSai.Add(window7[inRan].name);
            }

        }



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

    }


    IEnumerator BlinkBreckGlass()
    {
        float timeElapsed = 0f;
        while(timeElapsed < 1f)
        {
            foreach(GameObject obj in breckwin)
            {
                if (obj != null)
                {
                    Renderer renderer = obj.GetComponent<Renderer>();

                   renderer.material.color = (renderer.material.color == redColor) ? initialColor[renderer] : redColor;

                    
                }
            }
            yield return new WaitForSeconds(1f);
            timeElapsed += 0.5f;
        }
        foreach(GameObject obj in breckwin)
        {
            if (obj != null)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
            
                renderer.material.color = initialColor[renderer];
            }
        }
        buttL.SetActive(true);
        buttR.SetActive(true);
    }
    void Win()
    {
        panelwin.SetActive(true);
        buttL.SetActive(false);
        buttR.SetActive(false);
    }
    public void Restart()
    {
          SceneManager.LoadScene("SampleScene");
        
    }
}
