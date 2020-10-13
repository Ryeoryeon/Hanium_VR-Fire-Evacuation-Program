//수정 전 이동 코드

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_PlayerKeyboard : MonoBehaviour
{
    public int speed = 15;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveKeyboard();
    }

    void moveKeyboard()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.Self);
        //transform.Translate(Vector3.left * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
        transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime * keyVertical, Space.Self);
        //transform.Translate(Vector3.back * speed * Time.smoothDeltaTime * keyVertical, Space.World);

        // 왼쪽 회전
        if (Input.GetKey(KeyCode.Z))
            transform.Rotate(0.0f, -40.0f * Time.smoothDeltaTime, 0.0f);

        // 오른쪽 회전
        if (Input.GetKey(KeyCode.X))
            transform.Rotate(0.0f, 40.0f * Time.smoothDeltaTime, 0.0f);



    }
}