using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour {
    Animation anim;//Animation组件
	void Start () {
        //获取脚本所在对象上的Animation组件
        //GetComponent是Unity中脚本获取组件的方法
        anim = this.GetComponent<Animation>();
        //让Animation组件播放动画片段“GoDown”;
        anim.Play("GoDown");
	}

}
