using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour {
    public GameObject enemy;
    public static float bornTime = 10f;
    public Transform bornPos;

	// Use this for initialization
	void Start () {
        // Instantiate(enemy, bornPos.position, bornPos.rotation); 
        InvokeRepeating("Born", 7, bornTime);
        //Invoke("Born", bornTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Born()
    {
        Instantiate(enemy, bornPos.position, bornPos.rotation);
    }
}
