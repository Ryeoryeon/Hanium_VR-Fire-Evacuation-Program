using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Move : MonoBehaviour
{
    public SteamVR_Input_Sources handType; // 왼손, 오른손
    public SteamVR_Action_Boolean moveAction; // 무브 액션
    public SteamVR_Action_Boolean forwardAction; // 앞으로
    public SteamVR_Action_Boolean backAction; // 뒤로

    public Transform cameraRigTransform; // cameraRig 트랜스폼
    public Transform headTransform; // 플레이어 머리 (카메라) 트랜스폼
    public Camera cam; // 메인카메라

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (forwardAction.GetState(handType) || backAction.GetState(handType))
        {
            Debug.Log("ok");
            CameraMove();
        }
            
    }

    /*private void CameraMove()
    {
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;

        Vector3 dir = cam.transform.localRotation * Vector3.forward; // 메인카메라가 바라보는 방향
        dir.y = 0;
        cameraRigTransform.position += (dir + difference) * 0.1f; // 흠...? 방향에 뭘 더해줘야하나?
    }*/

    private void CameraMove()
    {
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;

        if (forwardAction.GetState(handType))
        {
            Vector3 dir = cam.transform.localRotation * Vector3.forward; // 메인카메라가 바라보는 방향
            dir.y = 0;
            cameraRigTransform.position += dir * 0.05f;
        }
        else if (backAction.GetState(handType))
        {
            Vector3 dir = cam.transform.localRotation * Vector3.back ; // 메인카메라가 바라보는 방향
            dir.y = 0;
            cameraRigTransform.position += dir * 0.05f; // 흠...? 방향에 뭘 더해줘야하나?
        }

        
    }
}