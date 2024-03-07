using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatform : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public Restart restart;

    private void OnTriggerEnter(Collider other)
    {
        restart.Setup();
        player.transform.position = respawnPoint.transform.position;
 

    }
}
