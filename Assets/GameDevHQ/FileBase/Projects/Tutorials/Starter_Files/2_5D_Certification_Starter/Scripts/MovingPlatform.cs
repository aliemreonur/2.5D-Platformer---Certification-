using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _moveStartPoint, _moveEndPoint;
    private bool _returning = false;
    [SerializeField] private float _speed = 6f;
    //[SerializeField] private bool _waitOnPoint = false;
    [SerializeField] private float _waitDelay;
    private float _currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = _speed;
        //change it from inspector if desired
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_moveEndPoint != null || _moveStartPoint != null)
        {
            if (!_returning)
            {
                transform.position = Vector3.MoveTowards(transform.position, _moveEndPoint.position, _speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _moveStartPoint.position, _speed * Time.deltaTime);
            }
            if (transform.position == _moveStartPoint.position)
            {
                StartCoroutine(PointWaitRoutine());
                _returning = false;
            }
            else if (transform.position == _moveEndPoint.position)
            {
                StartCoroutine(PointWaitRoutine());
                _returning = true;
            }
        }

    }

    IEnumerator PointWaitRoutine()
    {
        if(_waitDelay != 0)
        {
            _speed = 0;
            yield return new WaitForSeconds(_waitDelay);
            _speed = _currentSpeed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Player")
        {
            Debug.Log("Player is on the moving platform!");
        }
    }
}
