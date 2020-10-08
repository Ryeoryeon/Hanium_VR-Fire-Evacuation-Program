using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update

    public enum MoveType
    {
        WAY_POINT,
        LOOK_AT,
        DAYDREAM
    }

    public MoveType moveType = MoveType.WAY_POINT; // 이동 방식
    public float speed = 1.0f; // 이동 속도
    public float damping = 3.0f; // 회전 속도 조절 계수

    private CharacterController cc;
    private Transform tr;
    public Transform camera_trs;

    public int NarrationText_idx = 0;

    private Transform[] points; // 웨이포인트 저장 배열
    private int nextIdx = 1; // 다음에 이동해야 할 위치 변수

    //public float speed = 1.5f; // transform 속도

    void Start()
    {
        tr = GetComponent<Transform>();
        camera_trs = Camera.main.GetComponent<Transform>(); // 메인 카메라의 transform 값 가져오기
        cc = GetComponent<CharacterController>();
        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //cc.SimpleMove(camera_trs.forward * speed);
        switch(moveType)
        {
             case MoveType.WAY_POINT:
                MoveWayPoint();
                break;

            case MoveType.LOOK_AT:
                MoveLookAt();
                break;

            case MoveType.DAYDREAM:
                break;

        }
    }

    void MoveWayPoint()
    {
        // 현재 위치에서 다음 웨이포인트를 바로보는 벡터를 계산
        Vector3 direction = points[nextIdx].position - tr.position; // 빼기 조심!

        // 산출된 벡터의 회전 각도를 쿼터니언 타입으로 산출
        Quaternion rot = Quaternion.LookRotation(direction);

        // 현 각도에서 회전해야 할 각도까지 부드럽게 회전 처리
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

        // 전진 방향으로 이동
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void MoveLookAt()
    {
        Vector3 dir = camera_trs.TransformDirection(Vector3.forward); // 메인카메라가 바라보는 방향
        cc.SimpleMove(dir * speed); // dir 벡터의 방향으로 초당 speed만큼씩 이동

    }

    //웨이포인트 둥기둥기
    void OnTriggerEnter(Collider coll)
    {
        //웨이포인트에 충돌 여부 판단
        if(coll.CompareTag("WAY_POINT"))
        {
            NarrationText_idx = nextIdx;

            // 맨 마지막 웨이포인트에 도달했을 때 다시 처음 인덱스로 변경
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
        }
    }
}
