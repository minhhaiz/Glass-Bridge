using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMG : MonoBehaviour
{
    public List<GameObject> lisBots;
    public GameObject player,Panellose, Round;

     void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Bots"))
        {
            lisBots.Remove(other.gameObject);
            Debug.Log("da xoa");
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("m thua r");
            Time.timeScale = 0f;
            Round.SetActive(false);
            Panellose.SetActive(true);
        }
    }
}
