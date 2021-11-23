using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedJump;
    private Animator _animator;
    private Rigidbody2D _rigidBody;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {

        Spin();

        _rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * _speedMove, _rigidBody.velocity.y);        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector2.up * _speedJump); //, ForceMode2D.Impulse);
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            _animator.SetInteger("Number", 0 );
        }
        else
        {
            _animator.SetInteger("Number", 1);
        }
    }

    private void Spin()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}

