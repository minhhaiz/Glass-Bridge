using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MinHai
{
    public class SpinWheel : MonoBehaviour
    {
        
        public Transform tfrmPlayer, targetMon;
        public GameObject balloon, panelItem;
        public GameManager gameManager;
        public BotManager botManager;
       
        public float timespin = 0.5f;
        
        private bool isSpinning=  false;


        private void Awake()
        {
            CountDown.isWin = true;
        }

        /*public  void SpinWheelToRandomPosition()
         {

             // Kh�ng cho ph�p quay khi ?� quay
             if (isSpinning)
                 return;

             // Ch?n ng?u nhi�n m?t trong 4 g�c m?i g�c l� 90 ??
             int randomAngle = Random.Range(0, 4) * 90;

             // T�nh to�n g�c cu?i c�ng c?n quay ??n
             float targetAngle = wheelTransform.eulerAngles.z + randomAngle + 60 * 20;

             // Quay b�nh xoay b?ng DOTween
             wheelTransform.DORotate(new Vector3(0, 0, targetAngle), timespin * 10f, RotateMode.FastBeyond360)
                 .SetEase(Ease.OutQuart) // C� th? ?i?u ch?nh lo?i ease t?i ?�y
                 .OnStart(() => isSpinning = true) // B?t ??u quay: ??t bi?n isSpinning th�nh true
                 .OnComplete(() => {
                     isSpinning = false; // K?t th�c quay: ??t bi?n isSpinning th�nh false

                     StartCoroutine(PlayGame());
                     StartCoroutine(UseItem(randomAngle));

                 });
         }*/
        public void NextTo()
        {
            //StartCoroutine(PlayGame());
            panelItem.SetActive(false);
            if (gameManager == null)
            {
                gameManager = GameObject.FindObjectOfType<GameManager>();
            }
            gameManager.StartGameForcan();
        }
       void PlayGame()
        {
          
           
            panelItem.SetActive(false);
            if (gameManager == null)
            {
                gameManager = GameObject.FindObjectOfType<GameManager>();
            }
            gameManager.StartGame();

        }

      
        public void DetermineSelectedItem(int angle)
        {
            int selectedItem = angle; 
         
            if(selectedItem == 0)
            {
                PlayGame();
                Debug.Log("bong bay");
               DOVirtual.DelayedCall(3f, ItemBalloon);
            }
            else if(selectedItem == 1)
            {
               NextTo();
                Debug.Log("Drone");
                DOVirtual.DelayedCall(3f, ItemDrone);
            }
            else if (selectedItem == 2)
            {
                PlayGame();
                Debug.Log("Radar");
                DOVirtual.DelayedCall(3f, ItemRadar);
            }
         
        }

        public void ItemBalloon()
        {
            balloon.SetActive(true);
            Vector3[] path = new Vector3[]
                                    {
                    tfrmPlayer.position,
               new Vector3( tfrmPlayer.position.x - 5f, tfrmPlayer.position.y + 6f, tfrmPlayer.position.z ), // ?i?m cao nh?t c?a nh?y
                       targetMon.position
           };

            tfrmPlayer.DOPath(path, 3f, PathType.CatmullRom).SetEase(Ease.Linear);
        }
                   
        public void ItemTimer()
        {
           
        }
        public void ItemRadar()
        {
            if(gameManager == null)
            {
                gameManager = GameObject.FindObjectOfType<GameManager>();
            }
            gameManager.Radar();
        }
        public void ItemDrone()
        {

            if (gameManager == null)
            {
                gameManager = GameObject.FindObjectOfType<GameManager>();
            }
            gameManager.Drone();
        }
    }

}