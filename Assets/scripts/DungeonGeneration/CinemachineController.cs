using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera VcCamera;
    [SerializeField] Transform player;

    public CameraController cam;





    void Update()
    {
        Vector3 targetPos = cam.GetCameraTargetPosition();
        if (cam.confiner.position != targetPos)
        {
            // VcCamera.Follow = cam.confiner;
            // VcCamera.Follow = cam.confiner;
            VcCamera.transform.position = Vector3.MoveTowards(VcCamera.transform.position, player.position, Time.deltaTime * (cam.moveSpeedWhenRoomChanged/6f));
        }
        else
        {
            VcCamera.Follow = player;
        }


    }
}
