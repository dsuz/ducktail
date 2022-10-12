using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] Transform _teleportTarget;

    void OnTriggerEnter(Collider other)
    {
        if (_teleportTarget)
        {
            other.transform.position = _teleportTarget.position;
        }
    }
}
