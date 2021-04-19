using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuOpen : MonoBehaviour
{
    public Button menuBtn;
    public GameObject gameObject;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        menuBtn.onClick.AddListener(delegate () {
            //显示菜单
            if (menuBtn.name.Equals("menu")) gameObject.SetActive(true);
            //关闭菜单
            else if (menuBtn.name.Equals("close")) gameObject.SetActive(false);
        });
    }
}
