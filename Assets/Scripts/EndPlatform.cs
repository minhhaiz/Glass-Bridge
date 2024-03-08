using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatform : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform finish;
    public GameObject Winpanel , buttL,buttR;
    public Restart restart;

    private void OnTriggerEnter(Collider other)
    {
        restart.Setup();

    }
    private void Update()
    {
            if(player.transform.position == finish.transform.position)
        {
                    Winpanel.SetActive(true);
                    buttL.SetActive(false); 
                    buttR.SetActive(false);
             }
    }
}
