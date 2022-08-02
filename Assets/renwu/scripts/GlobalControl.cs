using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    //要保存使用的数据;
    public float enemy;
    public float boss;
    public float move;
    public float bing;
    public float huo;
    public float gao;
    public float dilei;
    public float jiaxue;
    public float volume;
    public int rank;

    //初始化
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
}
