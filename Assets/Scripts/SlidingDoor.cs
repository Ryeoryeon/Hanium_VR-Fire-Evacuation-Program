using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make an empty GameObject and call it "Door"
//Drag and drop your Door model into Scene and rename it to "Body"
//Move the "Body" Object inside "Door"
//Add a Collider (preferably SphereCollider) to "Door" Object and make it much bigger then the "Body" model, mark it as Trigger
//Assign this script to a "Door" Object (the one with a Trigger Collider)
//Make sure the main Character is tagged "Player"
//Upon walking into trigger area the door should Open automatically

public class SlidingDoor : MonoBehaviour
{
    // Sliding door
    public float openDistance = 1f; // 방향에 따라 음/양 조절 가능. 문이 열리는 범위 설정
    public float openSpeed = 10.0f;
    public Transform doorBody; // 소스코드에 연결해 준 오브젝트 Transform

    bool open = false; // 열림 상태 변수

    Vector3 defaultDoorPosition;

    public enum OpenDirection { x, y, z }
    public OpenDirection direction;
    private Vector3 modifyingPosition;


    void Start()
    {
        if (doorBody)
        {
            defaultDoorPosition = doorBody.localPosition;
        }
    }

    void Update()
    {
        // transform이 없을 경우
        if (!doorBody)
            return;

        if(direction == OpenDirection.x)
        {
            modifyingPosition = new Vector3(Mathf.Lerp(doorBody.localPosition.x, defaultDoorPosition.x + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.y, doorBody.localPosition.z);
        }

        else if (direction == OpenDirection.y)
        {
            modifyingPosition = new Vector3(doorBody.localPosition.x, Mathf.Lerp(doorBody.localPosition.y, defaultDoorPosition.y + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.z);
        }
        else if (direction == OpenDirection.z)
        {
            modifyingPosition = new Vector3(doorBody.localPosition.x, doorBody.localPosition.y, Mathf.Lerp(doorBody.localPosition.z, defaultDoorPosition.z + (open ? openDistance : 0), Time.deltaTime * openSpeed));
        }

        //

        doorBody.localPosition = modifyingPosition;


    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌 시, 문 열림 동작 실행
        if (other.CompareTag("Player"))
        {
            open = true;

        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = false;
        }
    }
}