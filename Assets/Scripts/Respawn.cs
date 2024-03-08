using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public GameObject lose;
    protected float countDies = 0;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
        countDies++;
        Debug.LogWarning(countDies + " deaths");
        lose.SetActive(true);

    }

}
