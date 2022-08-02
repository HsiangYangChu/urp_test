using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMove : MonoBehaviour
{
    GameObject PlayObject;
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    BossHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.

    void Start()
    {
        // Set up the references.
        PlayObject = GameObject.FindWithTag("Player");

        player = PlayObject.transform;

        nav = GetComponent<NavMeshAgent>();

        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<BossHealth>();
    }


    void Update()
    {
        // //If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            Debug.Log(enemyHealth.currentHealth);
            ////... set the destination of the nav mesh agent to the player.

            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            //    // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }

    public void setspeed(float x)
    {
        nav.speed = x;
    }

    public float getspeed()
    {
        return nav.speed;
    }
}
