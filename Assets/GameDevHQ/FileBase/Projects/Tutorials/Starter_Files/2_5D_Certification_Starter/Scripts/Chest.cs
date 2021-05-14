using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Light _light;
    private Animator _anim;
    private bool _boxOpen = false;
    //public Coin coin;
    //public GameObject coinToSpawn;
    public Coin coinToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponentInChildren<Light>();
        if(_light == null)
        {
            Debug.Log("Chest could not gather the light");
        }
        _anim = GetComponent<Animator>();
        if(_anim == null)
        {
            Debug.Log("Chest could not get its animator component bro");
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" && !_boxOpen)
        {
            for(int i = 0; i<5; i++)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if (player == null)
                {
                    Debug.LogError("Chest trigger Stay could not get the player component");
                }
                _anim.SetTrigger("ChestOpen");
                Coin spawnedCoin = Instantiate(coinToSpawn, new Vector3(0, transform.position.y,
                    transform.position.z), Quaternion.identity);
                spawnedCoin.Idle = false;
                Rigidbody rbSpawned = spawnedCoin.GetComponent<Rigidbody>();
                if (rbSpawned != null)
                {
                    rbSpawned.AddForce(new Vector3(0, 1, 1f) * 200);
                }
            }
            StartCoroutine(ChestLightOffRoutine());
        }
    }

    IEnumerator ChestLightOffRoutine()
    {
        if(!_boxOpen)
        {
            yield return new WaitForSeconds(1f);
            _light.gameObject.SetActive(false);
            _boxOpen = true;
        }
    }
}
