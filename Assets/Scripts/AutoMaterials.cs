using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMaterials : MonoBehaviour
{

    Material m_Material;
    public GameObject[] BottomList;
    public GameObject[] CeramicList;
    public GameObject[] CementList;
    public GameObject[] WoodenList;

    public bool initialIndex = false;

    void Start()
    {
        Material_Cement();
        Material_Ceramic();
        Material_Bottom();
        Material_Wooden();
    }

    void Update() 
    {
        /*
        if(!initialIndex)
        {


            initialIndex = true;
        }
         */

    }

    /*
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Success");
        foreach (GameObject child in BottomList)
        {
            child.GetComponentInChildren<Renderer>().enabled = true;
        }
    }
     */

    void Material_Wooden()
    {
        // 'wooden'으로 태그된 오브젝트들을 모두 찾는다
        WoodenList = GameObject.FindGameObjectsWithTag("Wooden");

        Transform[] WoodenChildList;

        foreach (GameObject child in WoodenList)
        {
            // 부모 오브젝트(상위) 의 자식 오브젝트들을 배열에 구성한다
            WoodenChildList = child.GetComponentsInChildren<Transform>();

            foreach (Transform grandchild in WoodenChildList)
            {
                m_Material = grandchild.GetComponent<Renderer>().material;

                // mesh renderer가 없을 경우 새로 만들어주기
                if (m_Material == null)
                {
                    grandchild.gameObject.AddComponent<UnityEngine.MeshRenderer>();
                    m_Material = grandchild.GetComponent<Renderer>().material;
                }


                // 해당되는 모든 오브젝트들을 한꺼번에 색상 변경
                Color c = new Color(120/255f, 50/255f, 0, 1/255f);
                m_Material.color = c;
                
            }
        }
    }
    void Material_Cement()
    {
        CementList = GameObject.FindGameObjectsWithTag("Cement");

        Transform[] CementChildList;

        //Transform[] trSphereList = 오브젝트이름.gameObject.GetComponentsInChildren<Transform>(); // 이 스크립트 본인의 child를 가져와야 하는데..!!

        foreach (GameObject child in CementList)
        {
            CementChildList = child.GetComponentsInChildren<Transform>();

            foreach (Transform grandchild in CementChildList)
            {
                //Debug.Log(grandchild.name);
                m_Material = grandchild.GetComponent<Renderer>().material;

                // mesh renderer가 없을 경우 새로 만들어주기
                if (m_Material == null)
                {
                    grandchild.gameObject.AddComponent<UnityEngine.MeshRenderer>();
                    m_Material = grandchild.GetComponent<Renderer>().material;
                }

                //Debug.Log(grandchild.name + m_Material.color);
                //Debug.Log("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
                m_Material.color = Color.white;
                //Debug.Log("후" + grandchild.name + m_Material.color);
            }
        }
    }
    void Material_Ceramic()
    {
        CeramicList = GameObject.FindGameObjectsWithTag("Ceramic");

        Transform[] CeramicChildList;

        //Transform[] trSphereList = 오브젝트이름.gameObject.GetComponentsInChildren<Transform>(); // 이 스크립트 본인의 child를 가져와야 하는데..!!

        foreach (GameObject child in CeramicList)
        {
            CeramicChildList = child.GetComponentsInChildren<Transform>();

            foreach (Transform grandchild in CeramicChildList)
            {
                //Debug.Log(grandchild.name);
                m_Material = grandchild.GetComponent<Renderer>().material;

                // mesh renderer가 없을 경우 새로 만들어주기
                if (m_Material == null)
                {
                    grandchild.gameObject.AddComponent<UnityEngine.MeshRenderer>();
                    m_Material = grandchild.GetComponent<Renderer>().material;
                }

                //Debug.Log(grandchild.name + m_Material.color);
                //Debug.Log("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
                m_Material.color = Color.red;
                //Debug.Log("후" + grandchild.name + m_Material.color);
            }
        }
    }
    void Material_Bottom()
    {
        BottomList = GameObject.FindGameObjectsWithTag("Bottom");

        Transform[] BottomChildList;

        foreach (GameObject child in BottomList)
        {
            BottomChildList = child.GetComponentsInChildren<Transform>();
            //Debug.Log(child.name);

            foreach (Transform grandchild in BottomChildList)
            {
                //Debug.Log(grandchild.name);
                m_Material = grandchild.GetComponent<Renderer>().material;

                // mesh renderer가 없을 경우 새로 만들어주기
                if (m_Material == null)
                {
                    grandchild.gameObject.AddComponent<UnityEngine.MeshRenderer>();
                    m_Material = grandchild.GetComponent<Renderer>().material;
                }

                //Debug.Log(grandchild.name + m_Material.color);
                //Debug.Log("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
                m_Material.color = Color.red;
                //Debug.Log("후" + grandchild.name + m_Material.color);
            }
        }
    }

}
