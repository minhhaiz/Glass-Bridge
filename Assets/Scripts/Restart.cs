using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartRound()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
