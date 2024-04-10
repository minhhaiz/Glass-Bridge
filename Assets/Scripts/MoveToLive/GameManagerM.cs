using DG.Tweening;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static DG.DemiLib.DeToggleColors;

namespace minhai
{
    public class GameManager : MonoBehaviour
    {

        public List<GameObject> floors;
        public List<GameObject> floorsColor;
        public List<GameObject> cubes;

        public List<UnityEngine.UI.Image> round;
        public static int coin;
        public UIGameEnd uIGameEnd;

        public GameObject RR, panelPause;
        private List<Renderer> cellRenderers = new List<Renderer>();
        public GameObject windows;
        public List<Material> colorMark = new List<Material>();
        public float blinkInterval = 2f;
        public Dictionary<GameObject, Material> floorsColorDic = new Dictionary<GameObject, Material>();
        public List<GameObject> luuCell;
        public int turn = 0;
        public Material firstMaterial;


        void Start()
        {
            Time.timeScale = 1f;
            Application.targetFrameRate = 120;

            luuCell.AddRange(floors);
           
            StartCoroutine(BlinkCells());
        }



        IEnumerator BlinkCells()
        {
            round[turn].color = Color.red;

            yield return new WaitForSeconds(1);
            List<GameObject> threeW = new List<GameObject>();

            for (int i = 0; i < 3; i++)
            {
                int random = Random.Range(0, floors.Count);
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

                    go.GetComponent<Renderer>().material = colorMark[index];
                    index++;
                    floorsColor.Add(go);
                    floorsColorDic.Add(go, go.GetComponent<Renderer>().material);
                }

                yield return new WaitForSeconds(2.5f);
                foreach (GameObject went in threeW)
                {

                    went.GetComponent<Renderer>().material = firstMaterial;

                }
                threeW.Clear();



            }
            StartCoroutine(Huy());

        }

        IEnumerator Huy()
        {

            yield return new WaitForSeconds(1f);
            int ischoice = Random.Range(0, 3);
            foreach (GameObject ban in cubes)
            {
                ban.GetComponent<Renderer>().material = colorMark[ischoice];
                //ban.GetComponent<Renderer>().material.color = floorsColor[0].GetComponent<Renderer>().material.color;
            }
            yield return new WaitForSeconds(4f);
            foreach (GameObject ban in cubes)
            {
                ban.GetComponent<Renderer>().material = firstMaterial;
            }


            foreach (KeyValuePair<GameObject, Material> item in floorsColorDic)
            {
                GameObject obj = item.Key;
                Material mat = item.Value;
                if (floorsColor.Contains(obj))
                {
                    Material color = mat;
                  
                    if (Compare(color, colorMark[ischoice]))
                    {                       
                        obj.GetComponent<Renderer>().material = color;
                        obj.SetActive(true);

                    }
                    else
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

            turn++;

            if (turn <= 2)
            {
                DOVirtual.DelayedCall(2f, () =>
                {

                    StartCoroutine(BlinkCells());
                });
                foreach (GameObject obj2 in floors)
                {
                    obj2.SetActive(true);
                    obj2.GetComponent<Renderer>().material = firstMaterial;

                }
            }
            else
            {
                foreach (GameObject obj2 in floors)
                {
                    obj2.SetActive(true);
                    obj2.GetComponent<Renderer>().material = firstMaterial;

                }
                DOVirtual.DelayedCall(1f, () =>
                {
                    RR.SetActive(false);
                    uIGameEnd.ShowPanel(true);
                });
            }


        }
        bool Compare(Material mat1, Material mat2)
        {
            if (mat1 == null || mat2 == null) return false;
            if (mat1.mainTexture != mat2.mainTexture)
            {
                return false;
            }
            return true;
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
        public void PauseG()
        {
            Time.timeScale = 0f;
            panelPause.SetActive(true);

        }
        public void Continue()
        {
            Time.timeScale = 1f;
            panelPause.SetActive(false);
        }

    }
}
