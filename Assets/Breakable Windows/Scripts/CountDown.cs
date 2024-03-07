using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : Respawn
{
    float currentTime = 0f;
    float startingTime = 120f;

    [SerializeField] Text countdownText;
    [SerializeField] Text deathsText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0s");

        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene("SampleScene");
        }

       // deathsText.text = countDies.ToString("");

        
    }

}