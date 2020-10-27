using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followingFriends : MonoBehaviour
{
    //public Transform target; // 따라갈 타겟의 트랜스 폼
    private float speed = 3.0f;
    public Animator anim;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;

    public bool moving = false;
    public float distanceVal; // 타겟과의 거리

    private Caption caption_script;
    int currentIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        // caption 스크립트에 접근
        // 선생님의 지시 후에 친구들과 함께 움직이기 위하여

        caption_script = GameObject.Find("NPC").GetComponent<Caption>();
        anim.speed = 1.3f; // 애니메이션 자체의 스피드!
    }

    public void setFriendsmovingTrue()
    {
        moving = true;
    }

    void OnTriggerEnter(Collider other)
    {
        currentIdx = caption_script.getCurrentIdx();

        if (currentIdx > 0)
        {
            // 맨 앞의 친구가 player와 충돌하면 멈추도록
            if (other.CompareTag("Player"))
            {

                moving = false;

                //Debug.Log("!");
            }
              

        }

    }

    private void OnTriggerExit(Collider other)
    {
        currentIdx = caption_script.getCurrentIdx();

        if(currentIdx > 0)
        {
            if(other.CompareTag("Player"))
            {

                moving = true;
                //Debug.Log("?");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentIdx = caption_script.getCurrentIdx();
        if (currentIdx > 0)
        {
            if(moving)
            {
                anim.SetFloat("speed", speed);
                anim2.SetFloat("speed", speed);
                anim3.SetFloat("speed", speed);
                anim4.SetFloat("speed", speed);
            }

            else
            {
                anim.SetFloat("speed", 0);
                anim2.SetFloat("speed", 0);
                anim3.SetFloat("speed", 0);
                anim4.SetFloat("speed", 0);
            }
        }

        // 애니메이션 쓰면 이 방법 X


        //        currentIdx = caption_script.getCurrentIdx();
        //        if(currentIdx > 0)
        //        {
        //            
        //
        //            /*
        //            //Vector3 targetPosition = target.position + new Vector3(0, 0, -distanceVal); // 타겟 주변으로 가는 위치
        //            Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z - distanceVal);
        //            // targetPosition += new Vector3(0, 0, -distanceVal); // 타겟 주변으로 가는 위치
        //
        //            //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed); // 타겟과의 거리가 멀어지면 따라간다.
        //
        //            if (this.transform.position != targetPosition)
        //                anim.SetFloat("speed", speed);
        //
        //            else
        //                anim.SetFloat("speed", 0);
        //             */
        //
        //        }


        //
        //      if (moving)
        //      {
        //          //teacherbody.position += new Vector3(0, 0, speed);
        //          anim.SetFloat("speed", speed);
        //      }
        //
        //      else if (!moving)
        //      {
        //          anim.SetFloat("speed", 0);
        //      }



    }
        
}
