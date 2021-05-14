using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private bool _idle = true;

    public bool Idle
    {
        get
        {
            return _idle;
        }
        set
        {
            _idle = value;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rotateSpeed = 90f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_idle)
        {
            transform.Rotate(new Vector3(0, 0, 1) * _rotateSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                Debug.Log("Player add coin");
            }
            player.AddCoins();
            Destroy(this.gameObject);
        }
    }
}
