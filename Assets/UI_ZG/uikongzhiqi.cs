using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class uikongzhiqi : MonoBehaviour
{

    public AudioClip click;
    AudioSource au;

    public RectTransform Panel_zhu, Panel_shezhi, Panel_shuoming;
    public Slider sli;
    public RectTransform[] nandu;
    private int rk;
    // Use this for initialization
    void Start()
    {
        rk = 0;
        //场景间传递参数
        GlobalControl.Instance.enemy = 9f;
        GlobalControl.Instance.boss = 50f;
        GlobalControl.Instance.move = 15f;
        GlobalControl.Instance.bing = 15f;
        GlobalControl.Instance.huo = 16f;
        GlobalControl.Instance.gao = 17f;
        GlobalControl.Instance.dilei = 20f;
        GlobalControl.Instance.jiaxue = 40f;

        sli.value = 10f;
        GlobalControl.Instance.volume = sli.value;
        GlobalControl.Instance.rank = 0;
        //GameObject.Find("Main Camera").GetComponent<GaussianBlur>().enabled = true;

        au = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Panel_shezhi_dianjizengjianandu()
    {
        au.Play();

        rk = (rk + 1) % 3;
        for (int i = 0; i < 3; ++i) nandu[i].gameObject.SetActive(false);
        nandu[rk].gameObject.SetActive(true);
        Panel_shezhi_shezhinandu();
    }

    public void Panel_shezhi_dianjijianshaonandu()
    {
        au.Play();

        rk = (rk + 2) % 3;
        for (int i = 0; i < 3; ++i) nandu[i].gameObject.SetActive(false);
        nandu[rk].gameObject.SetActive(true);
        Panel_shezhi_shezhinandu();
    }

    public void Panel_shezhi_shezhinandu()
    {
        GlobalControl.Instance.rank = rk;
        if(rk == 0)
        {
            Debug.Log("点击简单");
            GlobalControl.Instance.enemy = 9f;
            GlobalControl.Instance.boss = 50f;
            GlobalControl.Instance.move = 15f;
            GlobalControl.Instance.bing = 15f;
            GlobalControl.Instance.huo = 16f;
            GlobalControl.Instance.gao = 17f;
            GlobalControl.Instance.dilei = 20f;
            GlobalControl.Instance.jiaxue = 40f;
        }
        else if(rk == 1)
        {
            Debug.Log("点击中等");
            /*enemyManager.bornTime = 8f;
            BossManager.bornTime = 40f;
            Move.playerSpeed = 4f;
            BingbulletBorn.bornTime = 50f;
            HuobulletBorn.bornTime = 70f;
            GaobulletBorn.bornTime = 110f;
            dileiBorn.bornTime = 70f;
            jiaxueBorn.bornTime = 100f;*/
            GlobalControl.Instance.enemy = 8f;
            GlobalControl.Instance.boss = 40f;
            GlobalControl.Instance.move = 10f;
            GlobalControl.Instance.bing = 20f;
            GlobalControl.Instance.huo = 22f;
            GlobalControl.Instance.gao = 24f;
            GlobalControl.Instance.dilei = 25f;
            GlobalControl.Instance.jiaxue = 45f;
        }
        else if(rk == 2)
        {
            Debug.Log("点击较难");
            /*enemyManager.bornTime = 3f;
            BossManager.bornTime = 20f;
            Move.playerSpeed = 3f;
            BingbulletBorn.bornTime = 40f;
            HuobulletBorn.bornTime = 60f;
            GaobulletBorn.bornTime = 80f;
            dileiBorn.bornTime = 30f;
            jiaxueBorn.bornTime = 50f;*/
            GlobalControl.Instance.enemy = 7f;
            GlobalControl.Instance.boss = 30f;
            GlobalControl.Instance.move = 8f;
            GlobalControl.Instance.bing = 25f;
            GlobalControl.Instance.huo = 27f;
            GlobalControl.Instance.gao = 29f;
            GlobalControl.Instance.dilei = 30f;
            GlobalControl.Instance.jiaxue = 50f;
        }
    }


    public void Panel_shezhi_gaibianyinliang()
    {

        GlobalControl.Instance.volume = sli.value;
        //Panel_zanting.gameObject.SetActive(false);

    }

    public void Panel_shezhi_dianjifanhui()
    {
        au.Play();

        Panel_shezhi.gameObject.SetActive(false);
        Panel_zhu.gameObject.SetActive(true);
        //Panel_zanting.gameObject.SetActive(false);
    }

    public void Panel_zhu_dianjikaishi()
    {
        au.Play();

        SceneManager.LoadScene("bigjob");
    }

    public void Panel_zhu_dianjishezhi()  //点击设置
    {
        au.Play();

        Panel_shezhi.gameObject.SetActive(true);
        Panel_zhu.gameObject.SetActive(false);
    }

    public void Panel_zhu_dianjishuoming()  //点击设置
    {
        au.Play();

        Panel_shuoming.gameObject.SetActive(true);
        Panel_zhu.gameObject.SetActive(false);
    }

    public void Panel_zhu_dianjituichu()    //点击退出
    {
        au.Play();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Panel_shuoming_dianjifanhui()
    {
        au.Play();

        Panel_zhu.gameObject.SetActive(true);
        Panel_shuoming.gameObject.SetActive(false);
    }

}
