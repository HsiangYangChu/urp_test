using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class setNum : MonoBehaviour
{

    public AudioMixer mastermixer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bigjob:" + GlobalControl.Instance.enemy);
        enemyManager.bornTime = GlobalControl.Instance.enemy;
        BossManager.bornTime = GlobalControl.Instance.boss;
        Move.playerSpeed = GlobalControl.Instance.move;
        BingbulletBorn.bornTime = GlobalControl.Instance.bing;
        HuobulletBorn.bornTime = GlobalControl.Instance.huo;
        GaobulletBorn.bornTime = GlobalControl.Instance.gao;
        dileiBorn.bornTime = GlobalControl.Instance.dilei;
        jiaxueBorn.bornTime = GlobalControl.Instance.jiaxue;
        mastermixer.SetFloat("mastervol", GlobalControl.Instance.volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
