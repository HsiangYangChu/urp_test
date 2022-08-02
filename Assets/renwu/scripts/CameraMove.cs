using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public Transform target;

    public float speed = 5f;

    Vector3 offset;

    void Start(){
        offset = transform.position - target.position;
    }

	void Update () {
        Vector3 cameraPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, cameraPos,Time.deltaTime * speed);
    }
}
