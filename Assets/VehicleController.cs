using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] float _power = 4f;
    [SerializeField] float _maxSpeed = 7f;
    [SerializeField] float _brakeDamp = 0.9f;
    [SerializeField] Transform _censorStart;
    [SerializeField] Transform _censorEnd;
    [SerializeField] LayerMask _layerMask;
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.DrawLine(_censorStart.position, _censorEnd.position);

        if (Physics.Linecast(_censorStart.position, _censorEnd.position, _layerMask))
        {
            _rb.velocity *= _brakeDamp;
        }
        else
        {
            if (_rb.velocity.magnitude < _maxSpeed)
                _rb.AddForce(transform.forward * _power);
        }
    }
}
