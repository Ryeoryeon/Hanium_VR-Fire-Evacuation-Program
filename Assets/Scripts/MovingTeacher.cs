using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingTeacher : MonoBehaviour
{
    public bool moving = false;
    public Transform teacherbody;
    public Animator anim;
    public float speed = 2.0f;
    public Text NarrationText;

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

        else if (!moving)
        {
            anim.SetFloat("speed", 0);
        }
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        // 플레이어와 충돌 시, 움직임 변수 true 설정
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlayerDialog1());

        }

        else if (other.CompareTag("Destination"))
        {
            moving = false;
            teacherbody.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    IEnumerator PlayerDialog1()
    {
        teacherbody.rotation = Quaternion.Euler(0, 180, 0);
        NarrationText.text = "반장! 잘 왔다.\n" +"친구들과 함께 다음 지점으로 대피하자꾸나.\n" + "나를 따라오렴!\n";
        yield return new WaitForSeconds(2.5f);
        //Debug.Log("코루틴");
        NarrationText.text = "";
        teacherbody.rotation = Quaternion.Euler(0, 0, 0);
        moving = true;

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
