using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyTest : MonoBehaviour
{
    [SerializeField] float _power = 5f;
    Rigidbody _rb;
    Animator _anim;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        if (dir.sqrMagnitude > 0)
        {
            _rb.AddForce(dir * _power);
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = _rb.velocity;
        velocity.y = 0;
        _anim.SetFloat("Speed", velocity.magnitude);

        if (velocity != Vector3.zero)
        {
            transform.forward = velocity;
        }    
    }
}
