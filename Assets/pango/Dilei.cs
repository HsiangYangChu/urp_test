using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dilei : MonoBehaviour {

    AudioSource au;

	// Use this for initialization
	void Start () {
        au = GetComponent<AudioSource>();
        Invoke("Dead", 2f);
    }

    void Dead()
    {
        CancelInvoke("Dead");
        Collider[] c = Physics.OverlapSphere(this.transform.position, 10);
		GameObject fx = Instantiate(Resources.Load("DamageOverTimeFire")) as GameObject;
        fx.transform.position = this.transform.position;
        au.Play();
        Debug.Log("长度："+c.Length);
        for (int i=0; i<c.Length; ++i)
        {
            //Debug.Log("zhadan" + c[i].transform.name);
            // Destroy(c[i].gameObject);
            Rigidbody targetRigidBody = c[i].GetComponent<Rigidbody> ();
            if (!targetRigidBody) continue;
            //targetRigidBody.AddExplosionForce(100, this.transform.position, 1000);
            float damage = 8 * (10 - Vector3.Distance(c[i].transform.position, this.transform.position));
            if(c[i].tag == "enemy")
            {
                EnemyHealth enemyhealth = c[i].GetComponent<EnemyHealth>();
                if (enemyhealth != null)
                {
                    enemyhealth.TakeDamage((int)damage);
                }
            }
            //Debug.Log("zhadan" + c[i].transform.name+": "+damage);
        }

        Destroy(this.gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
