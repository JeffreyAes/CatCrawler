using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    public CinemachineVirtualCamera VcCamera;
    public CameraController cam;
    public GameObject player;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = cam.GetCameraTargetPosition();
        if(cam.confiner.position != targetPos)
        {
            VcCamera.Follow = null;
            VcCamera.transform.position = Vector3.MoveTowards(VcCamera.transform.position, targetPos, Time.deltaTime * (cam.moveSpeedWhenRoomChanged/3f));
        }

        else{
            VcCamera.Follow = player.transform;
        }
    }
}
