using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCoord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh ;
        Vector3[] vs = mesh.vertices;
        foreach (var item in vs)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
