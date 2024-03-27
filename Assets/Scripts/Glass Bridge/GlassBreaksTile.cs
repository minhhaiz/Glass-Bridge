using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreaksTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Touch")
        {
            Destroy(gameObject);
        }
    }

   

}
