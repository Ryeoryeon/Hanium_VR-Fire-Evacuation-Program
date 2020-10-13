using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTeacher : MonoBehaviour
{
    public bool moving = false;
    public Transform teacherbody;
    public Animator anim;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            //teacherbody.position += new Vector3(0, 0, speed);
            anim.SetFloat("speed", speed);
        }
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌 시, 움직임 변수 true 설정
        if (other.CompareTag("Player"))
        {
            moving = true;

        }
    }

    // 추후 변형시켜 플레이어와의 거리가 일정 이상 멀어지면 움직임을 멈추도록 진행
    // Deactivate the Main function when Player exit the trigger area
    /*
     *     
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moving = false;
        }
    }
     */

}
