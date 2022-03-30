using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;
public class PlayerCameraController : NetworkBehaviour
{
    public Transform target;
    public GameObject Camera;
    private void Start()
    {
        Camera.SetActive(true);
        if (isLocalPlayer)
        {
            CinemachineVirtualCamera cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            GameObject playerFollowCamera = cinemachineVirtualCamera.gameObject;
            cinemachineVirtualCamera.Follow = target;
        }
    }
}
