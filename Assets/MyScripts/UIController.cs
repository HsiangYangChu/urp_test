using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public RectTransform loginTr;//登陆面板
    public RectTransform registerTr;//注册面板

	void Start () {
        //将注册面板先隐藏起来
        registerTr.gameObject.SetActive(false);

    }
	//点击注册按钮，触发的函数
	public void OnClickRegister()
    {
        loginTr.gameObject.SetActive(false);
       registerTr.gameObject.SetActive(true);
    }
    //点击登陆按钮，出发的函数
    public void OnClickLogin()
    {
        registerTr.gameObject.SetActive(false);
        loginTr.gameObject.SetActive(true);
    }

}
