using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaobullet : MonoBehaviour
{

    public static int gaoattack = 30;

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
        if (other.tag == "FX")
            return;
        if (other.tag != "Player")
        {
            Debug.Log("hit:" + other.transform.name);

            if (other.tag == "enemy")
            {
                Debug.Log("enemy受伤");
                EnemyHealth enemyhealth = other.GetComponent<EnemyHealth>();
                if (enemyhealth != null)
                {
                    enemyhealth.TakeDamage(gaoattack);
                }
            }

            if(other.tag == "boss")
            {
                BossHealth bosshealth = other.GetComponent<BossHealth>();
                if(bosshealth != null)
                {
                    bosshealth.TakeDamage(gaoattack);
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
