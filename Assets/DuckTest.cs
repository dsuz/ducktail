using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckTest : MonoBehaviour
{
    [SerializeField] float _power = 3f;
    Rigidbody _rb;
    Animator _anim;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _anim.Play("Walk");
    }

    void Update()
    {
        _rb.AddForce(_power * this.transform.forward);
    }
}
