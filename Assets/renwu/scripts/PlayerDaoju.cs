using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDaoju : MonoBehaviour
{

    //获取玩家身上的四个脚本
    PlayerHealth playerhealth;
    PlayerShoot playershoot;
    MineCount mine;

    //定义四个子弹
    public Transform huobullet;
    public Transform bingbullet;
    public Transform gaobullet;
    public Transform putong;

    //获得特效
    GameObject fxbing;
    GameObject fxhuo;
    GameObject fxgao;
    GameObject fxspeed;
    GameObject fxblood;

    //当前那个特效跟随
    int flag;

    // Start is called before the first frame update
    void Start()
    {
        //初始化两个脚本
        playerhealth = GetComponent<PlayerHealth>();
        playershoot = GetComponentInChildren<PlayerShoot>();
        mine = GetComponent<MineCount>();

        flag = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        //胶水测试
        if (other.tag == "glue"){
            Debug.Log("danzihaoda");
            if (flag != 0)
                destory();
            playershoot.usingGlue = 1;
            Invoke("resume", 20f);
            Destroy(other.gameObject);
        }
        //碰到火子弹
        if(other.tag == "huo")
        {
            if (flag != 0)
                destory();
            HuobulletBorn.flaghuo = false;
            playershoot.bullet = huobullet;
            Invoke("resume", 15f);
            /*
            加特效 
            */
            fxhuo = Instantiate(Resources.Load("SpinningFire")) as GameObject;
            fxhuo.transform.position = transform.position;
            flag = 1;
            Invoke("destory", 14f);

            Destroy(other.gameObject);
        }
        //碰到冰子弹
        if(other.tag == "bing")
        {
            if (flag != 0)
                destory();
            BingbulletBorn.flagbing = false;
            playershoot.bullet = bingbullet;
            Invoke("resume", 10f);
            /*
            加特效 
            */
            fxbing = Instantiate(Resources.Load("SpinningModular")) as GameObject;
            fxbing.transform.position = transform.position;
            flag = 2;
            Invoke("destory", 9f);

            Destroy(other.gameObject);
        }
        //碰到高伤害子弹
        if(other.tag == "gao")
        {
            if (flag != 0)
                destory();
            GaobulletBorn.flaggao = false;
            playershoot.bullet = gaobullet;
            Invoke("resume", 10f);
            /*
            加特效 
            */
            fxgao = Instantiate(Resources.Load("SpinningLife")) as GameObject;
            fxgao.transform.position = transform.position;
            flag = 3;
            Invoke("destory", 9f);

            Destroy(other.gameObject);
        }
        //碰到速度加成道具
        if(other.tag == "speed")
        {
            if (flag != 0)
                destory();
            jiasuBorn.flagspeed = false;
            fxspeed = Instantiate(Resources.Load("Prefab_DiLiuZhang/fx_feixingdandao_6.2")) as GameObject;
            fxspeed.transform.position = transform.position;
            Move.playerSpeed += 3f;
            flag = 4;
            Invoke("resumespeed", 10f);

            Destroy(other.gameObject);
        }
        //碰到血量加成道具
        if(other.tag == "blood")
        {
            if (flag != 0)
                destory();
            jiaxueBorn.flagblood = false;
            fxblood = Instantiate(Resources.Load("Prefab_DiJiuZhang/fx_jiaxue_9.1")) as GameObject;
            fxblood.transform.position = transform.position;
            playerhealth.currentHealth = 100;
            playerhealth.healthSlider.value = 100;
            flag = 5;
            Invoke("destory", 3f);

            Destroy(other.gameObject);
        }
        //碰到地雷道具
        if(other.tag == "dilei")
        {
            mine.count++;
            dileiBorn.flagdilei = false;

            Destroy(other.gameObject);
        }
    }

    //破坏当前特效
    void destory()
    {
        //将当前播放的特效去掉
        switch(flag)
        {
            case 1:Destroy(fxhuo);flag = 0; break;
            case 2:Destroy(fxbing); flag = 0; break;
            case 3:Destroy(fxgao); flag = 0; break;
            case 4:Destroy(fxspeed); flag = 0; break;
            case 5:Destroy(fxblood); flag = 0; break;
        }
    }

    //恢复普通子弹
    void resume()
    {
        CancelInvoke("resume");
        playershoot.bullet = putong;
        playershoot.usingGlue = 0;
    }

    //恢复原有速度
    void resumespeed()
    {
        CancelInvoke("resumespeed");
        Move.playerSpeed -= 3f;
        destory();
    }

    // Update is called once per frame
    void Update()
    {
        //特效跟随
        switch (flag)
        {
            case 1: fxhuo.transform.position = this.transform.position; break;
            case 2: fxbing.transform.position = this.transform.position; break;
            case 3: fxgao.transform.position = this.transform.position; break;
            case 4: fxspeed.transform.position = this.transform.position; break;
            case 5: fxblood.transform.position = this.transform.position; break;
        }
    }
}
