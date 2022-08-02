using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimatorEvent : MonoBehaviour {
    public Transform bullet;
    public Transform firePos;
	// Use this for initialization
	void Start () {
      
	}


    
    public void Fire()
    {
    
      Debug.Log("Fire:" );
      Transform b =  Instantiate(bullet,firePos.position,firePos.rotation);
      //  if(b)
      b.gameObject.GetComponent<Rigidbody>().AddForce(b.forward * 2000);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }
    }
   
}
