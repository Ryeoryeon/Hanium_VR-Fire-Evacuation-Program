using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Caption : MonoBehaviour
{
    // Start is called before the first frame update

    private Text TimeText;
    private Text NarrationText;

    private float CountingTime = 0;

    public PlayerControl playercontrol;
    private int currentIdx = 1;

    void Start()
    {
        TimeText = GameObject.Find("Time").GetComponent<Text>();
        NarrationText = GameObject.Find("Narration_text").GetComponent<Text>();
        NarrationText.text = "나레이션 스타트";
    }

    // Update is called once per frame
    void Update()
    {
        // 나중에 프로그램이 끝났을 때 정지되도록 예외처리 해주기
        CountingTime += Time.deltaTime;
        SetText();
    }

    void SetText()
    {
        TimeText.text = "소요 시간 : " + CountingTime.ToString() + "초";

        // 인덱스가 변경되었을 때

        if(playercontrol.NarrationText_idx != currentIdx)
        {
            currentIdx = playercontrol.NarrationText_idx;
            NarrationText.text = currentIdx.ToString();
        }

    }
}
