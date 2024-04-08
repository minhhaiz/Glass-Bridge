using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
  

    public void GlassBridge()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MoveToLive()
    {
        SceneManager.LoadScene("MoveToLive");
    }
}
