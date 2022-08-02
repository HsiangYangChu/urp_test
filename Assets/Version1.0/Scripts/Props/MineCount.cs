using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class MineCount : MonoBehaviour
{
    public int count;

    public Text countText;
    
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = count.ToString();
    }
}
