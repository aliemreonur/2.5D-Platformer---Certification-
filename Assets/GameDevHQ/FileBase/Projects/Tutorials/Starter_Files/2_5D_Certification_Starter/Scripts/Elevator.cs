using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool _goingUp = false;
    private float _speed = 3.0f;
    Vector3 _topFloor, _downFloor;

    [SerializeField] private Transform _topTransform, _downTransform;

    // Start is called before the first frame update
    void Start()
    {
        _topFloor = new Vector3(0, 33.41f, 0);
        _downFloor = Vector3.zero;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_goingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, _topTransform.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _downTransform.position, _speed * Time.deltaTime);
        }

        if(transform.position == _topTransform.position)
        {
            StartCoroutine(ElevatorRoutine());
            _goingUp = false;
        }
        else if(transform.position == _downTransform.position)
        {
            StartCoroutine(ElevatorRoutine());
            _goingUp = true;
        }
        
    }

    IEnumerator ElevatorRoutine()
    {
        _speed = 0;
        yield return new WaitForSeconds(5f);
        _speed = 3f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Player")
        {
            Debug.Log("Player on the elevator");
        }
    }


}
