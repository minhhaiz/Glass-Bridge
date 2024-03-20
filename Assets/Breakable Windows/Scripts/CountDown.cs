using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : Respawn
{
    float currentTime = 0f;
    float startingTime = 90f;
    private Animation animation;
    public static bool isWin;
    public GameObject pause;
    [SerializeField] Text countdownText;
    [SerializeField] Text deathsText;

    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        currentTime = startingTime;
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWin == false)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0s");

            if (currentTime <= 0)
            {
                currentTime = 0;

                lose.SetActive(true);
                pause.SetActive(false);

                // SceneManager.LoadScene("SampleScene");
            }
           

            // deathsText.text = countDies.ToString("");
        }


    }

}