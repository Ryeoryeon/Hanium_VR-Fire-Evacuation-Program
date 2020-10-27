using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Caption : MonoBehaviour
{
    // Start is called before the first frame update

    private Text TimeText;
    public Text NarrationText;

    private float CountingTime = 0;

    public PlayerControl playercontrol;
    private int currentIdx = 0;

    void Start()
    {
        TimeText = GameObject.Find("Time").GetComponent<Text>();
        NarrationText = GameObject.Find("Narration_text").GetComponent<Text>();
        NarrationText.text = "나레이션 스타트";
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while(true)
        {
            CountingTime++;
            SetText();
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 나중에 프로그램이 끝났을 때 정지되도록 예외처리 해주기
        //CountingTime += Time.deltaTime;
        SetText();
    }

    void SetText()
    {
        TimeText.text = "소요 시간 : " + CountingTime.ToString() + "초";

        // 인덱스가 변경되었을 때 (Playercontrol의 waypoint 이동방식 쓸거면 체크)
        /*
        if(playercontrol.NarrationText_idx != currentIdx)
        {
            currentIdx = playercontrol.NarrationText_idx;
            NarrationText.text = "불이 났어요!\n" + "선생님을 찾아 교실 밖으로 나갑시다!";
        }         
         */

        switch(currentIdx)
        {
            case 0:
                NarrationText.text = "불이 났어요!\n" + "선생님을 찾아 교실 밖으로 나갑시다!";
                break;

            case 1:
                NarrationText.text = "선생님을 따라 친구들과 함께\n" + "계단 앞으로 대피합시다";
                break;

            case 2:
                NarrationText.text = "계단을 따라 1층으로 대피합시다";
                break;

            default:
                break;

        }

        if (currentIdx == 0)
        {
            NarrationText.text = "불이 났어요!\n" + "선생님을 찾아 교실 밖으로 나갑시다!";
        }


    }

    public int getCurrentIdx() // 외부 스크립트에서 currentIdx의 값을 알고 싶을 때
    {
        return currentIdx;
    }

    public void setCurrentIdx100()
    {
        currentIdx = 100;
        // update문에서 캡션이 지정된 값(0,1,2..)에 따라 업데이트가 되고 있음
        // 그렇게 선생님 대사가 출력 안 되는 문제가 있으므로,
        // case에 없는 값으로 임시 설정해주는 함수
    }

    public void restoreCurrentIdx(int original) // 원래의 값으로 복원해주기
    {
        currentIdx = original;
    }

    public void increaseCurrentIdx()
    {
        currentIdx++;
    }
}
