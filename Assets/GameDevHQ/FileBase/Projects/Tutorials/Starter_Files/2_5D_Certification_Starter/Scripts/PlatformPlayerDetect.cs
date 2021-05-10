using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerDetect : MonoBehaviour
{
    MovingPlatform  _movingPlatform;
    // Start is called before the first frame update
    void Start()
    {
        _movingPlatform = GetComponentInParent<MovingPlatform>();
        if(_movingPlatform == null)
        {
            Debug.Log("Moving platform child could not get the parent");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player is on top");
            _movingPlatform.PlayerisOnTop(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has left the moving platform");
            _movingPlatform.PlayerHasLeft(other.gameObject);
        }
    }

}
