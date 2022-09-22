using FishNet.Object;
using Cinemachine;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            Camera c = Camera.main;
            CinemachineVirtualCamera vc = c.GetComponent<CinemachineVirtualCamera>();
            vc.Follow = transform;
            vc.LookAt = transform;
        }
    }
}

// original camera w/o cinemachine cameras
// public class CameraController : NetworkBehaviour
// {
//     public override void OnStartClient()
//     {
//         base.OnStartClient();
//         if (base.IsOwner)
//         gameObject.SetActive(true);
//     }
// }
