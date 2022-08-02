using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bingbullet : MonoBehaviour
{

    public static int bingattack = 20;

    AudioSource au;

    //怪物的两个脚本
    EnemyHealth enemyhealth;
    EnemyMovement enemymove;

    //boss的两个脚本
    BossHealth bosshealth;
    BossMove bossmove;

    //记录怪物以前的速度
    float x;

    void Start()
    {
        au = GetComponent<AudioSource>();
        au.Play();
        Invoke("Dead", 4);
    }

    void Dead()
    {
        CancelInvoke("Dead");
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            Debug.Log("hit:" + other.transform.name);

            if (other.tag == "enemy")
            {
                Debug.Log("enemy受伤");
                enemyhealth = other.GetComponent<EnemyHealth>();
                enemymove = other.GetComponent<EnemyMovement>();
                if (enemyhealth != null)
                {
                    enemyhealth.TakeDamage(bingattack);
                    x = enemymove.getspeed();
                    enemymove.setspeed(1f);
                    Invoke("resumespeed", 4f);
                }
            }

            if(other.tag == "boss")
            {
                bosshealth = other.GetComponent<BossHealth>();
                bossmove = other.GetComponent<BossMove>();
                if(bosshealth != null)
                {
                    bosshealth.TakeDamage(bingattack);
                    x = bossmove.getspeed();
                    bossmove.setspeed(2f);
                    Invoke("resumebossspeed", 4f);
                }
            }

            Destroy(this.gameObject);
        }
    }

    void resumespeed()
    {
        enemymove.setspeed(x);
    }

    void resumebossspeed()
    {
        bossmove.setspeed(x);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag != "Player" && col.collider.tag != "enemy")
        {
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
