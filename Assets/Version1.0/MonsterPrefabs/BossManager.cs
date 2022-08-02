using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public GameObject enemy;
    public static float bornTime = 80f;
    public Transform bornPos;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Born", bornTime, bornTime);
        //Invoke("Born", bornTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Born()
    {
        Instantiate(enemy, bornPos.position, bornPos.rotation);
    }
}
