using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public Slider healthSlider;
    public int startHealth = 100;
    public int currentHealth;

    public Image damageImage;//图片闪烁间隔时间
    public float flashTime = 10f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    bool isDamaged = false;

    //add audio source
    AudioSource playerhurt;

    //add Animator
    Animator anim;

	// Use this for initialization
	void Start () {
        currentHealth = startHealth;
        healthSlider.value = startHealth;
        playerhurt = GetComponent<AudioSource>();
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDamaged)
        {
            damageImage.color = flashColor;
        }else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashTime * Time.deltaTime);
        }
        isDamaged = false;
	}

    public void TakeDamage(int damage)
    {
        //Debug.Log("PlayerHurt!");
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        isDamaged = true;
        playerhurt.Play();
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        anim.SetTrigger("death");
    }
}
