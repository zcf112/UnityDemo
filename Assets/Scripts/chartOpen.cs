using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chartOpen : MonoBehaviour
{
    public Button menuBtn;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menuBtn.onClick.AddListener(delegate () {
            //显示菜单
            if (menuBtn.name.Equals("ChartButton")) gameObject.SetActive(true);
            //关闭菜单
            else if (menuBtn.name.Equals("close")) gameObject.SetActive(false);
        });
    }
}
