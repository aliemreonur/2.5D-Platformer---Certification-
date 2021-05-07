using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController _cc;
    Animator _animator;

    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jump = 15f;
    [SerializeField] private float _gravity = 1f;
    private bool _jumping = false;
    private bool _onLedge = false;
    private Ledge _activeLedge;

    private Vector3 _direction, _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        if (_cc == null)
        {
            Debug.LogError("Player could not fidnd the Character Controller component");
        }
        _animator = GetComponentInChildren<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Player Animator is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(_onLedge)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _animator.SetTrigger("ClimbUp");
            }
        }
    }

    private void Move()
    {
        if (_cc.isGrounded)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _direction = new Vector3(0, 0, horizontalInput) * _speed;
            _animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

            if (horizontalInput != 0)
            {
                Vector3 facingSide = transform.localEulerAngles;
                if (horizontalInput > 0)
                {
                    facingSide.y = 0;
                }
                else if (horizontalInput < 0)
                {
                    facingSide.y = 180;
                }
                //facingSide.y = _direction.z > 0 ? 0 : 180; //this is new for me
                transform.localEulerAngles = facingSide;
            }

            if (_jumping)
            {
                _jumping = false;
                _animator.SetBool("Jump", false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _direction.y += _jump;
                _jumping = true;
                _animator.SetBool("Jump", true);
            }
        }
        _direction.y -= _gravity;
        _cc.Move(_direction * Time.deltaTime);
    }

    public void LedgeGrab(Vector3 handposition, Ledge currentLedge)
    {
        _cc.enabled = false;
        _animator.SetBool("LedgeGrab", true);

        //we do not want to trigger any other animation while hanging on a ledge
        _animator.SetFloat("Speed", 0.0f);
        _animator.SetBool("Jump", false);
        _onLedge = true;

        //this is for a better look 
        transform.position = handposition;
        _activeLedge = currentLedge;
    }

    public void ClimbPosition()
    {
        transform.position = _activeLedge.standPos;
        _animator.SetBool("LedgeGrab", false);
        _cc.enabled = true;
    }
}
