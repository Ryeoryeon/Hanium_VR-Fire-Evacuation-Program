using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public GameObject pointPrefab; // 체크포인트 프리팹
    int turn = 0; // 몇번째 checkpoint인지
    public Transform teacherbody; // 선생님
    private Caption caption_script;
    private followingFriends followingf_script;
    public Text NarrationText;
    public MovingTeacher MovingTeacher = GameObject.Find("Hans_B_withFace").GetComponent<MovingTeacher>();
    

    // Start is called before the first frame update
    void Start()
    {
        // caption 스크립트에 접근
        caption_script = GameObject.Find("NPC").GetComponent<Caption>();
        followingf_script = GameObject.Find("Kira_A_withFace").GetComponent<followingFriends>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextInst()
    {
        turn++;
        switch (turn)
        {
            case 1:
                StartCoroutine(PlayerDialog1());
                break;

            case 2:
                StartCoroutine(PlayerDialog2());
                break;

            case 3:
                StartCoroutine(PlayerDialog3());
                break;

            case 4:
                StartCoroutine(PlayerDialog4());
                break;

            case 5:
                StartCoroutine(PlayerDialog5());
                break;


            default:
                break;
        }

        IEnumerator PlayerDialog1()
        {
            teacherbody.rotation = Quaternion.Euler(0, 180, 0);

            caption_script.setCurrentIdx100();
            NarrationText.text = "반장! 잘 왔다.\n" + "친구들과 함께 다음 지점으로 대피하자꾸나.\n" + "나를 따라오렴!\n";
            yield return new WaitForSeconds(2.5f);
            //Debug.Log("코루틴");
            NarrationText.text = "";
            teacherbody.rotation = Quaternion.Euler(0, 0, 0);
            MovingTeacher.moving = true;

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
            //MovingTeacher.moving = true;
            float tempPositionY = teacherbody.position.y - 3.5f;
            teacherbody.position = new Vector3(teacherbody.position.x, tempPositionY, teacherbody.position.z); // 1층으로 먼저 이동한 선생님

            // 1층으로 선생님이 순간이동 할때 텔레포트 생성
            Vector3 pos = teacherbody.position + new Vector3(0, 0.05f, 1.25f);
            Instantiate(pointPrefab, pos, Quaternion.identity);

            caption_script.restoreCurrentIdx(1);
            caption_script.increaseCurrentIdx();
        }

        IEnumerator PlayerDialog3()
        {
            //teacherbody.rotation = Quaternion.Euler(0, 180, 0);

            caption_script.setCurrentIdx100();
            NarrationText.text = "불을 피해 조심해서 이동하자!";
            yield return new WaitForSeconds(2.5f);
            //Debug.Log("코루틴");
            NarrationText.text = "";
            teacherbody.rotation = Quaternion.Euler(0, 180, 0);
            MovingTeacher.moving = true;

            caption_script.restoreCurrentIdx(2);
            caption_script.increaseCurrentIdx();
        }

        IEnumerator PlayerDialog4()
        {
            teacherbody.rotation = Quaternion.Euler(0, 0, 0);

            caption_script.setCurrentIdx100();
            NarrationText.text = "문이 앞에 있다!\n" + "친구들을 확인하며 조심히 출구까지 가자.";
            yield return new WaitForSeconds(2.5f);
            //Debug.Log("코루틴");
            NarrationText.text = "";
            teacherbody.rotation = Quaternion.Euler(0, -90, 0);

            //MovingTeacher.anim.speed = 1.2f;
            //MovingTeacher.anim.SetBool("walk", true);
            MovingTeacher.moving = true;

            caption_script.restoreCurrentIdx(3);
            caption_script.increaseCurrentIdx();
        }

        IEnumerator PlayerDialog5()
        {
            teacherbody.rotation = Quaternion.Euler(0, 90, 0);

            caption_script.setCurrentIdx100();
            NarrationText.text = "친구들을 데리고\n" + "무사히 대피에 성공했구나!\n" + "멋지구나!";
            yield return new WaitForSeconds(2.5f);
            NarrationText.text = "";
            //teacherbody.rotation = Quaternion.Euler(0, 90, 0);

            //MovingTeacher.anim.speed = 1.2f;
            //MovingTeacher.anim.SetBool("walk", true);
            //MovingTeacher.moving = true;

            caption_script.restoreCurrentIdx(4);
            caption_script.increaseCurrentIdx();
        }
    }
}
