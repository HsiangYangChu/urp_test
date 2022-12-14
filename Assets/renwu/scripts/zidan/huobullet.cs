using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huobullet : MonoBehaviour
{

    public static int huoattack = 50;

    AudioSource au;

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
                EnemyHealth enemyhealth = other.GetComponent<EnemyHealth>();
                if (enemyhealth != null)
                {
                    enemyhealth.TakeDamage(huoattack);
                }
            }

            if (other.tag == "boss")
            {
                BossHealth bosshealth = other.GetComponent<BossHealth>();
                if (bosshealth != null)
                {
                    bosshealth.TakeDamage(huoattack);
                }
            }

            Destroy(this.gameObject);
        }
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
