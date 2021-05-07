using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    [SerializeField] Vector3 _handPos, _standPos;

    public Vector3 standPos
    {
        get
        {
            return _standPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GrabCheck")
        {
            //Debug.Log("Grab Check");
            Player player = other.GetComponentInParent<Player>();
            if(player != null)
            {
                player.LedgeGrab(_handPos, this);
            }
        }
    }
}
