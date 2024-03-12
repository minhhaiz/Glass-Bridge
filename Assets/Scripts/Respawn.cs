using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public List<GameObject> botlist = new List<GameObject>();
    public GameObject lose;
    protected float countDies = 0;

    private void OnTriggerEnter(Collider other)
    {
        //player.transform.position = respawnPoint.transform.position;

        //Debug.LogWarning(countDies + " deaths");
       // botlist[0].SetActive(false);
        //lose.SetActive(true);

    }

}
