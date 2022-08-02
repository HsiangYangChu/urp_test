using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class uikongzhiqi2 : MonoBehaviour
{
    public RectTransform Panel_zanting, Panel_jieshu, Panel_xinjilu;
    public RectTransform[] xing;
    public Text text_now, text_best, text_update;
    PlayerHealth playerhealth;
    bool flag;
    public Text text_nandu;

    public Image bloodimage;
    public Slider blood;
    public Text score;
    public Image dilei;
    public Text dileicount;


    AudioSource au;
    public AudioClip Audiosuccess;
    public AudioClip Audiodefeat;

    // Start is called before the first frame update
    void Start()
    {

        int rk = GlobalControl.Instance.rank;
        if (rk == 0) text_nandu.text = "简单";
        else if (rk == 1) text_nandu.text = "中等";
        else if (rk == 2) text_nandu.text = "较难";

        flag = false;
        Panel_zanting.gameObject.SetActive(false);

        GameObject player = GameObject.FindWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();

        au = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Panel_zanting.gameObject.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<GaussianBlur>().enabled = true;
        }

        if(playerhealth.currentHealth <= 0 && !flag)
        {
            Time.timeScale = 0;
            flag = true;
            GameObject.Find("Main Camera").GetComponent<GaussianBlur>().enabled = true;
            int tmp = GlobalControl.Instance.rank;
            int bestScore = 0;
            int nowScore = ScoreManager.score;
            if (tmp == 0) bestScore = PlayerPrefs.GetInt("level0");
            else if (tmp == 1) bestScore = PlayerPrefs.GetInt("level1");
            else if (tmp == 2) bestScore = PlayerPrefs.GetInt("level2");

            Debug.Log("hhhhhh: " + tmp + "   sjjssj: " + bestScore);
            if (nowScore > bestScore)
            {
                au.clip = Audiosuccess;
                au.Play();
                //去除多余
                bloodimage.gameObject.SetActive(false);
                blood.gameObject.SetActive(false);
                score.gameObject.SetActive(false);
                dilei.gameObject.SetActive(false);
                dileicount.gameObject.SetActive(false);
                text_nandu.gameObject.SetActive(false);

                Panel_xinjilu.gameObject.SetActive(true);
                Panel_jieshu.gameObject.SetActive(false);
                text_update.text = nowScore.ToString();
                if (tmp == 0) PlayerPrefs.SetInt("level0", nowScore);
                else if (tmp == 1) PlayerPrefs.SetInt("level1", nowScore);
                else if (tmp == 2) PlayerPrefs.SetInt("level2", nowScore);
            }
            else
            {
                au.clip = Audiodefeat;
                au.Play();
                //去除多余
                bloodimage.gameObject.SetActive(false);
                blood.gameObject.SetActive(false);
                score.gameObject.SetActive(false);
                dilei.gameObject.SetActive(false);
                dileicount.gameObject.SetActive(false);
                text_nandu.gameObject.SetActive(false);

                Panel_jieshu.gameObject.SetActive(true);
                Panel_xinjilu.gameObject.SetActive(false);
                text_now.text = nowScore.ToString();
                text_best.text = bestScore.ToString();
                int dia = bestScore / 3;
                int rk = (nowScore + dia - 1) / dia;
                if (rk >= 4) rk = 3;
                for (int i = 0; i < 3; ++i) xing[i].gameObject.SetActive(false);
                for (int i = 0; i < rk; ++i) xing[i].gameObject.SetActive(true);
            }
        }
    }

    public void Panel_zanting_dianjijixu()
    {
        au.Play();

        Time.timeScale = 1;
        Panel_zanting.gameObject.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<GaussianBlur>().enabled = false;
    }

    public void Panel_zanting_dianjichongwan()
    {
        au.Play();

        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");

    }


    public void Panel_jieshu_dianjihenxinliqu()
    {
        au.Play();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Panel_jieshu_dianjichongxinkaishi()
    {
        au.Play();

        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

}
