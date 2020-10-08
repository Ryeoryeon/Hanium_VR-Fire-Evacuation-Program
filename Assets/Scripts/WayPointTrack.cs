using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointTrack : MonoBehaviour
{
    public Color lineColor = Color.yellow;
    private Transform[] points;

    void OnDrawGizmos()
    {
        // 라인 색 지정
        Gizmos.color = lineColor;
        //WayPointGroup 게임 오브젝트 아래에 있는 모든 Point 게임 오브젝트 추출
        points = GetComponentsInChildren<Transform>();

        int nextIdx = 1; // 자식오브젝트의 정보를 가져오면서 부모의 정보를 가져오기 때문에 1로 설정

        Vector3 currPos = points[nextIdx].position;
        Vector3 nextPos;

        // Point 게임 오브젝트를 순회하면서 라인을 그림
        for(int i=0; i<=points.Length; i++)
        {
            //마지막 point일 경우 첫 번째 point로 지정
            nextPos = (++nextIdx >= points.Length) ? points[1].position :
                points[nextIdx].position;

            //시작 위치에서 종료 위치까지 라인을 그림
            Gizmos.DrawLine(currPos, nextPos);

            currPos = nextPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
