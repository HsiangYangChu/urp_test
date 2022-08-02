using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dileiBorn : MonoBehaviour
{
    //随机生成道具
    public List<Transform> patrolPosList;
    private NavMeshAgent nav;
    private int patrolIndex = 0;

    public GameObject gameobject;
    public static float bornTime = 80f;

    public static bool flagdilei = false;

    // Use this for initialization
    void Start()
    {
        flagdilei = true;
        Invoke("Born", bornTime);

        nav = this.GetComponent<NavMeshAgent>();
        patrolIndex = 0;
    }

    private void CheckPatrolDistance()
    {
        if (nav.remainingDistance < 0.5f)//如果达到寻路目标点，让怪物待机3秒钟
        {
            Invoke("PatroNext", 1f); //3秒后执行IdleWait函数      
        }
    }

    //去往下一个寻路点
    private void PatroNext()
    {
        CancelInvoke("PatroNext");//清理定时函数
        patrolIndex = patrolIndex % patrolPosList.Count;
        if (patrolPosList[patrolIndex])
        {
            nav.isStopped = false;
            nav.SetDestination(patrolPosList[patrolIndex].position);  //设置下一目标点      

        }
        Debug.Log("xunlu:" + patrolIndex);
        patrolIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPatrolDistance();
        if (!flagdilei)
        {
            flagdilei = true;
            nav.isStopped = false;
            Invoke("Born", bornTime);
        }
    }

    void Born()
    {
        CancelInvoke("Born");
        nav.isStopped = true;
        Vector3 ve = new Vector3(transform.position.x, transform.position.y + 0.7f, transform.position.z);
        Instantiate(gameobject, ve, transform.rotation);
    }
}
