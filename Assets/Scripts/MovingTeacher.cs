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

    private Caption caption_script;
    private followingFriends followingf_script;

    // Start is called before the first frame update
    void Start()
    {
        // caption 스크립트에 접근
        caption_script = GameObject.Find("NPC").GetComponent<Caption>();
        followingf_script = GameObject.Find("Kira_A_withFace").GetComponent<followingFriends>();
        anim.speed = 0.8f; // 애니메이션 자체의 스피드!
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
            int currentIdx = caption_script.getCurrentIdx();

            switch(currentIdx)
            {
                case 0:
                    StartCoroutine(PlayerDialog1());
                    break;

                case 1:
                    StartCoroutine(PlayerDialog2());
                    break;

                case 2:
                    StartCoroutine(PlayerDialog3());
                    break;

                case 3:
                    StartCoroutine(PlayerDialog4());
                    break;


                default:
                    break;
            }
            

        }

        else if (other.CompareTag("Destination"))
        {
            if (!anim.GetBool("walk"))
            {
                moving = false;
                teacherbody.rotation = Quaternion.Euler(0, -90, 0);
            }

            else
                anim.SetBool("walk", false);
        }
    }

    IEnumerator PlayerDialog1()
    {
        teacherbody.rotation = Quaternion.Euler(0, 180, 0);

        caption_script.setCurrentIdx100();
        NarrationText.text = "반장! 잘 왔다.\n" +"친구들과 함께 다음 지점으로 대피하자꾸나.\n" + "나를 따라오렴!\n";
        yield return new WaitForSeconds(2.5f);
        //Debug.Log("코루틴");
        NarrationText.text = "";
        teacherbody.rotation = Quaternion.Euler(0, 0, 0);
        moving = true;

        caption_script.restoreCurrentIdx(0);
        caption_script.increaseCurrentIdx();
        followingf_script.setFriendsmovingTrue();
    }

    IEnumerator PlayerDialog2()
    {
        teacherbody.rotation = Quaternion.Euler(0, 180, 0);

        caption_script.setCurrentIdx100();
        NarrationText.text = "모두 잘 왔구나.\n" + "1층에 불이 났으니 조심해서 이동하자!\n";
        yield return new WaitForSeconds(2.5f);
        //Debug.Log("코루틴");
        NarrationText.text = "";
        teacherbody.rotation = Quaternion.Euler(0, -90, 0);
        //moving = true;
        float tempPositionY = teacherbody.position.y - 3.5f;
        teacherbody.position = new Vector3 (teacherbody.position.x, tempPositionY, teacherbody.position.z); // 1층으로 먼저 이동한 선생님

        caption_script.restoreCurrentIdx(1);
        caption_script.increaseCurrentIdx();
    }

    IEnumerator PlayerDialog3()
    {
        teacherbody.rotation = Quaternion.Euler(0, 180, 0);

        caption_script.setCurrentIdx100();
        NarrationText.text = "불을 피해 조심해서 이동하자!";
        yield return new WaitForSeconds(2.5f);
        //Debug.Log("코루틴");
        NarrationText.text = "";
        teacherbody.rotation = Quaternion.Euler(0, 90, 0);
        moving = true;

        caption_script.restoreCurrentIdx(2);
        caption_script.increaseCurrentIdx();
    }

    IEnumerator PlayerDialog4()
    {
        teacherbody.rotation = Quaternion.Euler(0, -180, 0);

        caption_script.setCurrentIdx100();
        NarrationText.text = "문이 앞에 있다!\n" + "친구들을 확인하며 조심히 출구까지 가자.";
        yield return new WaitForSeconds(2.5f);
        //Debug.Log("코루틴");
        NarrationText.text = "";
        teacherbody.rotation = Quaternion.Euler(0, -90, 0);

        anim.speed = 1.2f;
        anim.SetBool("walk", true);

        caption_script.restoreCurrentIdx(3);
        caption_script.increaseCurrentIdx();
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
