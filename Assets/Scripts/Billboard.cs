using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(transform.position + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);

        // 카메라를 계속 따라오게 하는 UI
        this.transform.position = cam.transform.position + (cam.transform.rotation * Vector3.forward);

    }
}
