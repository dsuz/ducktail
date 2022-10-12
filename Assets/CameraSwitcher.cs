using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCameraBase _playerCamera;
    [SerializeField] CinemachineVirtualCameraBase _focusCamera;

    void OnTriggerEnter(Collider other)
    {
        _focusCamera.MoveToTopOfPrioritySubqueue();
    }

    void OnTriggerExit(Collider other)
    {
        _playerCamera.MoveToTopOfPrioritySubqueue();
    }
}
