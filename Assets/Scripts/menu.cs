using System;
using UnityEngine;
using UnityEngine.UI;
public class menu : MonoBehaviour
{
    public Text id;
    public Text peo_name;
    public Text type;
    public Text home;
    public Text company;
    public Text loc1;
    public Text loc2;
    public Text loc3;
    public GameObject gamObject;

    //gg
    Button[] Buttons;
    void Start()
    {
        Buttons = FindObjectsOfType<Button>();
        foreach (var item in Buttons)
        {
            item.onClick.AddListener(() => OnButtonClicked(item));
        }
    }
    private void OnButtonClicked(Button item)
    {
        MysqlManager mysqlManager = new MysqlManager();
        //下拉框显示数据库内容
        Debug.Log("你按下了：" + item.name);
        switch (item.name)
        {
            case "menu":
                gamObject.SetActive(true);
                break;
            case "menuclose":
                gamObject.SetActive(false);
                break;
            case "add":
                string str = "'" + peo_name.text + "'," + type.text + ",'" + home.text + ",'" + company.text + "'," + loc1.text + ",'" + loc2.text + "'," + loc3.text;
                mysqlManager.InsertInto("People", "`name`,`type`,`home`,`company`,`loc1`,`loc2`,`loc3`",str);
                break;
            case "update":
                str = "set name=" + peo_name.text + " type=" + type.text + " home=" + home.text + " company=" + company.text + " loc1=" + loc1.text + " loc2=" + loc2.text + " loc3=" + loc3.text;
                mysqlManager.UpdateSet("People", str , int.Parse(id.text));//未测试
                break;
            case "delete":
                mysqlManager.DeleteFrom("People", int.Parse(id.text));
                break;
        }
    }
}
