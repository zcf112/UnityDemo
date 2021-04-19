using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdown : MonoBehaviour
{
    public MysqlManager mysqlManager = new MysqlManager();
    public Dropdown dDown;
    public InputField id;
    public InputField peo_name;
    public InputField type;
    public InputField home;
    public InputField company;
    public InputField loc1;
    public InputField loc2;
    public InputField loc3;
  
    void Start()
    {
        MySqlDataReader reader=mysqlManager.SelectFrom("select id,name from People");
        List<string> DropOptions=new List<string>();
        
        while (reader.Read())
        {
            int count = reader.FieldCount;
            for (int i = 0; i < count; i++)
            {
                string key = reader.GetValue(i)+" "+ reader.GetValue(++i);
                //Debug.Log(key);
                DropOptions.Add(key);
            }    
        }
        dDown.AddOptions(DropOptions);
        //添加监听器
        dDown.GetComponent<Dropdown>().onValueChanged.AddListener(ConsoleResult);
        reader.Close();
    }

    public void ConsoleResult(int value)
    {
        MySqlDataReader reader = mysqlManager.SelectFrom("select id,name,type,home,company,loc1,loc2,loc3 from People");
        Debug.Log(value);
        int count = 1;
        while (reader.Read())
        {
            //Debug.Log("count");
            if (count == value)
            {
                //Debug.Log("if");
                id.text= reader.GetString(0);
                peo_name.text = reader.GetString(1);
                type.text = reader.GetString(2);
                home.text = reader.GetString(3);
                company.text = reader.GetString(4);
                loc1.text = reader.GetString(5);
                loc2.text = reader.GetString(6);
                loc3.text = reader.GetString(7);
                break;
            }
            count++;
        }
        reader.Close();
    }
}
