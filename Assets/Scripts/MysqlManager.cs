using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MySql.Data.MySqlClient;

public class MysqlManager
{
    string ip = "47.102.197.60";//ip地址
    string username = "zdata";//登录ID
    string password = "112112@Zcf";//登录密码
    string dbName = "zdata";//数据库名称

    MySqlConnection connect;//数据库连接
    MySqlCommand command;//数据库命令

    public MysqlManager()
    {
        Open();
    }

    //打开数据库
    public void Open()
    {
        connect = new MySqlConnection();
        connect.ConnectionString = "server=" + ip + "; user id=" + username +"; password=" + password + "; database=" + dbName;
        connect.Open();
        command = connect.CreateCommand();//?
        Debug.Log("打开数据库");
    }

    //关闭数据库
    public void Close()
    {
        command.Dispose();
        connect.Dispose();
        Debug.Log("关闭数据库");
    }

    //创建表
    public void CreateTable(string tabelName, Dictionary<string, string> infos)
    {
        string sql = "create table " + tabelName;
        sql += @"(
            id int primary key auto_increment not null,
            name varchar(10),
            attack int,
            ranges float
            )";
        ExcuteSql(sql);
    }

    //增加，列名要用反单引号（键盘左上角），值名加英文单引号
    public void InsertInto(string tableName,string clo,string value)
    {
        string sql = "insert into " + tableName + " (" + clo + ")"+ "values("+value+")";
        ExcuteSql(sql);
    }

    //删除
    public void DeleteFrom(string tableName,int id)
    {
        try
        {
            string sql = "delete from " + tableName + " " + "where id = "+id;
            ExcuteSql(sql);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    //修改
    public void UpdateSet(string tableName,string sqlup,int id)
    {
        string sql = "update " + tableName + " " + sqlup+" where id="+id;
        ExcuteSql(sql);
    }

    //查询
    public MySqlDataReader SelectFrom(string sql)
    {
        //string sql = "select * from " + tableName;

        command.CommandText = sql;
        MySqlDataReader reader = command.ExecuteReader();//以阅读器来查询
        return reader;
        /*
        while (reader.Read())
        {
            int count = reader.FieldCount;
            for (int i = 0; i < count; i++)
            {
                string key = reader.GetName(i);//列名
                object value = reader.GetValue(i);//列值

                //Console.WriteLine(key + ":" + value);
                Debug.Log(key + ":" + value);
            }
        }*/
    }

    //应用
    void ExcuteSql(string sql)
    {
        //Console.WriteLine("sql -> " + sql);
        command.CommandText = sql;
        command.ExecuteNonQuery();
    }
}
