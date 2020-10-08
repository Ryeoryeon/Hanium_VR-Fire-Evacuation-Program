using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Adds a mesh collider to each game object that contains collider in its name
public class AutoMeshCollider : AssetPostprocessor
{
    void OnPostprocessModel(GameObject g)
    {
        Apply(g.transform);
    }

    void Apply(Transform t)
    {
        if (t.name.ToLower().Contains("collider"))
            t.gameObject.AddComponent<MeshCollider>();

        // Recurse
        foreach (Transform child in t)
            Apply(child);
    }
}
/*
 public class AutoMeshCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 */
