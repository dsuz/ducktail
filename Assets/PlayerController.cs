using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _power = 5f;
    [SerializeField] Transform _trafficButton;
    Rigidbody _rb;
    Animator _anim;
    bool _isCloseToButton = false;

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

        if (Input.GetButtonDown("Fire1"))
        {
            if (_isCloseToButton)
            {
                Vector3 lookAtTowards = _trafficButton.position;
                lookAtTowards.y = this.transform.position.y;
                transform.DOLookAt(lookAtTowards, 0.2f);
                // ƒ{ƒ^ƒ“‚ð‰Ÿ‚·
                GetComponent<HandIK>().TouchTarget();
            }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TrafficLight")
        {
            _isCloseToButton = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "TrafficLight")
        {
            _isCloseToButton = false;
        }
    }
}
