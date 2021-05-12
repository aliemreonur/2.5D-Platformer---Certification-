using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    [SerializeField] private GameObject ladderKeyImg;

    private void Start()
    {
        ladderKeyImg.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ClimbTextOnRoutine());
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //StartCoroutine(ClimbTextOnRoutine());
            Player player = other.gameObject.GetComponent<Player>();
            if(player != null)
            {
                player.ClimbLadder = true;
            }
           
        }
    }

    IEnumerator ClimbTextOnRoutine()
    {
        ladderKeyImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        ladderKeyImg.gameObject.SetActive(false);
    }

 
}
