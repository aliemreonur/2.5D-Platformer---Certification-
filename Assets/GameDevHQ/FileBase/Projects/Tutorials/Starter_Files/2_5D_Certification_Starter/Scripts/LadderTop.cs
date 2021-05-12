using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "LadderTopCheck")
        {
            Player player = other.GetComponentInParent<Player>();
            if(player != null)
            {
                //Debug.Log("Player is at the top of the ladder"); //works
                //player.ClimbLadder = false;
                //player.transform.position = this.transform.position;
                player.LadderTop();
            }
            
            
        }
    }
}
