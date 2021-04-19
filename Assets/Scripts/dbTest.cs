using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class dbTest : MonoBehaviour
{
    string id;

    void Start()
    {
        //string constructorString = "datasource=127.0.0.1;port=3306;database=zdata;user=root;pwd=112112@Zcf;";
        /*
        string constructorString = "server=47.102.197.60; port=3306;user=root; password=112112@Zcf; database=zdata";
        MySqlConnection conn = new MySqlConnection(constructorString);
        Debug.Log("1");
        try
        {
            conn.Open();
            Debug.Log("start");
            string sql = "select * from actiontable where id =1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                Debug.Log(rdr.GetString("type"));
            }
            Debug.Log(rdr);
        }
        catch (MySqlException ex)
        {

            Debug.Log("ERROR:"+ex.Message);
        }
        finally
        {
            conn.Close();
            Debug.Log("finish");
        }
        */
        /*MysqlManager mysqlManager = new MysqlManager();
        mysqlManager.SelectFrom("select * from actiontable");

        mysqlManager.Close();*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}


