using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Room currentRoom;
    public float moveSpeedWhenRoomChanged;
    public Transform confiner;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }


    void UpdatePosition()
    {
        if(currentRoom == null)
        {
            return;
        }

        Vector3 targetPos = GetCameraTargetPosition();

        confiner.position = Vector3.MoveTowards(confiner.position, targetPos, Time.deltaTime * moveSpeedWhenRoomChanged);
        // confiner.position = targetPos;
        
    }

    public Vector3 GetCameraTargetPosition()
    {
        if(currentRoom == null)
        {
            return Vector3.zero;
        }

        Vector3 targetPos = currentRoom.GetRoomCenter();
        targetPos.z = confiner.position.z;

        return targetPos;
    }

    public bool IsSwitchingScene()
    {
        return confiner.position.Equals(GetCameraTargetPosition()) == false;
    }
}
