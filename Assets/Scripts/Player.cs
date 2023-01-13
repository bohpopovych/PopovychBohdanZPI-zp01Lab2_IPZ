using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private float _accelerationForce;
    [SerializeField] private float _jumpForce;

    private bool _onGround = false;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
            Move(new Vector3(-1, 0, 0)); 

        if(Input.GetKey(KeyCode.S))
            Move(new Vector3(1, 0, 0)); 

        if(Input.GetKey(KeyCode.D))
            Move(new Vector3(0, 0, 1)); 

        if(Input.GetKey(KeyCode.A))
            Move(new Vector3(0, 0, -1));

        if(_onGround && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Move(Vector3 direction)
    {
        _rigidBody.AddForce(direction * _accelerationForce);
    }

    private void Jump()
    {
        _rigidBody.AddForce(new Vector3(0, _jumpForce, 0));
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Ground"))
            _onGround = true;
    }   

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ground"))
            _onGround = false;    
    }
}
