using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{ 

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if(player != null)
            {
                player.ClimbLadder = true;
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
