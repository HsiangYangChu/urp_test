using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    //控制连续发射
    private float shoot;
    private float firetime;

    //获取地雷数脚本
    MineCount mine;

    //获取地雷
    public Transform dilei;

    public Transform bullet;

    public Transform weapon;
    public Transform firePos;

    public Transform weapon1;
    public Transform firePos1;

    public Transform weapon2;
    public Transform firePos2;

    public Transform weapon3;
    public Transform firePos3;

    public Transform weapon4;
    public Transform firePos4;

    public Transform part;

    public int usingGlue = 0;

	public Obi.ObiEmitter emitter;
	// public Obi.ObiSolver solver;

    ParticleSystem gunParticle;


    GameObject fx;
    Light gunLight;

    Ray shootRay;
    //int shootMask;
    RaycastHit shootHit;
    float timer;

    public float range = 300f;
    public float timeBetweenBullet = 0.3f;
    public int damage = 20;

    // Use this for initialization
    void Start () {
        //时间初始化
        shoot = firetime = 0;
        //shootMask = LayerMask.GetMask("shootable");
        gunParticle = GetComponentInChildren<ParticleSystem>();

        mine = this.GetComponentInParent<MineCount>();
	}

    public void Fire()
    {
        Debug.Log("Fire:");

        if(usingGlue == 1){
            Debug.Log("nishigehaoren");
            emitter.transform.position = firePos4.position;
            emitter.transform.rotation = transform.rotation;
            weapon.gameObject.SetActive(false);
            weapon1.gameObject.SetActive(false);
            weapon2.gameObject.SetActive(false);
            weapon3.gameObject.SetActive(false);
            weapon4.gameObject.SetActive(true);
            emitter.speed = 4.0f;
            return;
        }

        if(bullet.name == "Sphere")
        {
            // Debug.Log("Fire:");

            // Debug.Log("sdkjhskjdfhkjshakjfhlkjashfshdkjfhkjdshfkjhskjfdhkjdshkjfhsdkjfhkjshdfkjshdkjfhdskjfhkjsdhfkjdshkjfhdskjfjh");
            Transform b = Instantiate(bullet, firePos.position, transform.rotation);
            //  if(b)
            b.gameObject.GetComponent<Rigidbody>().AddForce(b.forward * 2000);
            weapon.gameObject.SetActive(true);
            weapon1.gameObject.SetActive(false);
            weapon2.gameObject.SetActive(false);
            weapon3.gameObject.SetActive(false);
            weapon4.gameObject.SetActive(false);

        }else if(bullet.name == "Bullet_GoldFire_Small_Projectile")
        {
            Transform b = Instantiate(bullet, firePos1.position, transform.rotation);
            //  if(b)
            b.gameObject.GetComponent<Rigidbody>().AddForce(b.forward * 2000);
            weapon.gameObject.SetActive(false);
            weapon1.gameObject.SetActive(true);
            weapon2.gameObject.SetActive(false);
            weapon3.gameObject.SetActive(false);
            weapon4.gameObject.SetActive(false);

        }else if(bullet.name == "Bullet_SilverFlare_Small_Projectile")
        {
            Transform b = Instantiate(bullet, firePos2.position, transform.rotation);
            //  if(b)
            b.gameObject.GetComponent<Rigidbody>().AddForce(b.forward * 2000);
            weapon.gameObject.SetActive(false);
            weapon1.gameObject.SetActive(false);
            weapon2.gameObject.SetActive(true);
            weapon3.gameObject.SetActive(false);
            weapon4.gameObject.SetActive(false);

        }else if(bullet.name == "Bullet_VenomGreen_Small_Projectile")
        {
            Transform a = Instantiate(bullet, firePos3.position, transform.rotation);
            Transform b = Instantiate(bullet, firePos3.position, transform.rotation);
            Transform c = Instantiate(bullet, firePos3.position, transform.rotation);
            Transform d = Instantiate(bullet, firePos3.position, transform.rotation);

            a.gameObject.GetComponent<Rigidbody>().AddForce(a.forward * Random.Range(2000, 2500));
            b.gameObject.GetComponent<Rigidbody>().AddForce(b.forward * Random.Range(2000, 2500));
            c.gameObject.GetComponent<Rigidbody>().AddForce(c.forward * Random.Range(2000, 2500));
            d.gameObject.GetComponent<Rigidbody>().AddForce(d.forward * Random.Range(2000, 2500));
            weapon.gameObject.SetActive(false);
            weapon1.gameObject.SetActive(false);
            weapon2.gameObject.SetActive(false);
            weapon3.gameObject.SetActive(true);
            weapon4.gameObject.SetActive(false);

        }

        gunParticle.transform.position = part.position;
        gunParticle.Stop();
        gunParticle.Play();

        /*shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay, out shootHit, range, shootMask))
        {
            enemyHealth enemyhealth = shootHit.collider.GetComponent<enemyHealth>();
            Debug.Log(shootHit.collider.transform.name + "受伤!!!");
            if (enemyhealth != null)
            {
                //Debug.Log(shootHit.collider.transform.name + "受伤!!!");
                enemyhealth.TakeDamage(damage,shootHit.point);
            }
        }*/
    }

    // Update is called once per frame
    void Update () {
        /*timer += Time.deltaTime;
        if(Input.GetMouseButton(0) && timer >= timeBetweenBullet)
        {
            Fire();
        }else if(timer >= timeBetweenBullet)
        {
            timer = 0;
        }*/

        if (Input.GetMouseButton(0))
        {
            shoot += Time.deltaTime;
            if(shoot >= firetime)
            {
                firetime += 0.2f;
                Fire();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            shoot = firetime = 0;
            emitter.speed = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(mine.count > 0)
            {
                Instantiate(dilei, transform.position, transform.rotation);
                mine.count--;
            }
        }
    }
}
