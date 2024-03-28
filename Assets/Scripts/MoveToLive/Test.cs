using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static DG.DemiLib.DeToggleColors;

public class Test : MonoBehaviour
{

    public List<GameObject> floors;
    public List<GameObject> floorsColor;
    public List<GameObject> cubes;
    public static int coin;
    public UIGameEnd uIGameEnd;

    private List<Renderer> cellRenderers = new List<Renderer>();
    public GameObject windows;
    public List<Color> colors = new List<Color>();
    public float blinkInterval = 2f;
    public Dictionary<GameObject, Color> floorsColorDic = new Dictionary<GameObject, Color>();
    public List<GameObject> luuCell;
    public int turn = 1;

    void Start()
    {
        ColorSet();
        luuCell.AddRange(floors);
        StartCoroutine(BlinkCells());
    }
    void ColorSet()
    {
        colors.Add(Color.blue);
        colors.Add(Color.green);
        colors.Add(Color.red);
    }

    IEnumerator BlinkCells()
    {
       
       
        List<GameObject> threeW = new List<GameObject>();
        
        for (int i = 0; i < 3; i++)
        {
            int random = Random.Range(0,floors.Count);
            threeW.Add(floors[random]);
            floors.Remove(floors[random]);

            int random1 = Random.Range(0, floors.Count);
            threeW.Add(floors[random1]);
            floors.Remove(floors[random1]);

            int random2 = Random.Range(0, floors.Count);
            threeW.Add(floors[random2]);
            floors.Remove(floors[random2]);
            int index = 0;
            foreach (GameObject go in threeW)
            {
                
                go.GetComponent<Renderer>().material.color = colors[index];
                index++;
                floorsColor.Add(go);
                floorsColorDic.Add(go, go.GetComponent<Renderer>().material.color);
            }
            
            yield return new WaitForSeconds(blinkInterval);
            foreach (GameObject went in threeW)
            {
                
                went.GetComponent<Renderer>().material.color = Color.white;
              
            }
            threeW.Clear();

           

        }
        StartCoroutine(Huy());

    }

    IEnumerator Huy()
    {
        yield return new WaitForSeconds(1f);
       int ischoice = Random.Range(0, 3);
        foreach(GameObject ban in cubes)
        {
            ban.GetComponent<Renderer>().material.color = colors[ischoice];
            //ban.GetComponent<Renderer>().material.color = floorsColor[0].GetComponent<Renderer>().material.color;
        }
        yield return new WaitForSeconds(3f);
        foreach (GameObject ban in cubes)
        {
            ban.GetComponent<Renderer>().material.color = Color.white;
        }


        foreach (KeyValuePair<GameObject,Color> item in floorsColorDic)
        {
            GameObject obj = item.Key;
            Color mat = item.Value;
            if (floorsColor.Contains(obj))
            {
                Color color = mat;
               // Debug.Log(color.ToString());
                if (color == colors[ischoice]) {
                    obj.GetComponent<Renderer>().material.color = color;
                    obj.SetActive(true);

                }else
                {
                    obj.SetActive(false);
                }  
                
            }
        }
        floorsColor.Clear();
        floorsColorDic.Clear();
        Debug.Log(floorsColor.Count);
        floors.AddRange(luuCell);
        yield return new WaitForSeconds(2f);
        foreach (GameObject obj2 in floors)
        {
            obj2.SetActive(true);
            obj2.GetComponent<Renderer>().material.color = Color.white;
           
        }
        turn++;
        if (turn <= 3)
        {
            DOVirtual.DelayedCall(3f, () =>
            {

                StartCoroutine(BlinkCells());
            });
        }
        else
        {
            Debug.Log(" you win ");
            
            
            uIGameEnd.ShowPanel(true);
        }
    

    }


    bool CompareColors(GameObject obj, Color targetColor)
    {
        // L?y Renderer c?a GameObject
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            // L?y màu c?a v?t li?u (material) c?a Renderer
            Color objectColor = renderer.material.color;

            // So sánh màu c?a v?t li?u v?i màu c?n so sánh
            if (objectColor.Equals(targetColor))
            {
               
                return true;
            }
        }
        return false;
    }
    

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MoveToLive");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
