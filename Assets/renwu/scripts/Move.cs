using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    Animator anmi;
    private int LayerIndex = -1;
    public static float playerSpeed = 10f;
    
    Rigidbody playerRigidbody;
    float raylength = 100f;
    
	// Use this for initialization
	void Start () {
        anmi = this.GetComponent<Animator>();
        LayerIndex = LayerMask.GetMask("Ground");
        playerRigidbody = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //正常移动
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveVec = new Vector3(h, 0, v);
        Vector3 norm = moveVec.normalized;
        Debug.Log(norm);
        moveVec = transform.position + moveVec.normalized * playerSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(moveVec);

        //旋转
        //trans.Translate(norm * Time.deltaTime * playerSpeed);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo))
        {
            Vector3 playerRotate = hitinfo.point - transform.position;
            playerRotate.y = 0f;
            Quaternion rotate = Quaternion.LookRotation(playerRotate);
            playerRigidbody.MoveRotation(rotate);
        }

        //控制动画
        bool moving = (h != 0f || v != 0f);
        anmi.SetBool("move", moving);
	}
}
