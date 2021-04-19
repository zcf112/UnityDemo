using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.AI;
/*
    //生成房子（子对象）
*/

public class MainCamera : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;//导航烘焙
    public MysqlManager mysqlManager = new MysqlManager();
    //public MysqlManager mysqlManager2 = new MysqlManager();

    void Start()
    {
        //从数据库中载入房子
        MySqlDataReader reader = mysqlManager.SelectFrom("select House,lx,ly,lz,rx,ry,rz from HouseLoc");
        while (reader.Read())
        {
            GameObject h_Clone = (GameObject)Resources.Load("Prefabs/House");//载入预制体
            h_Clone = Instantiate(h_Clone, new Vector3(reader.GetFloat(1), reader.GetFloat(2), reader.GetFloat(3)), Quaternion.Euler(reader.GetFloat(4), reader.GetFloat(5), reader.GetFloat(6)), GameObject.Find("Homes").transform);
            h_Clone.name = reader.GetString(0);//改名
            TextMesh textMesh = (TextMesh)GameObject.Find("Homes/" + reader.GetString(0) + "/HouseName").transform.GetComponent(typeof(TextMesh));//设置房子text值
            textMesh.text = reader.GetString(0);
        }//实例化房子
        reader.Close();
        
        reader = mysqlManager.SelectFrom("select People.name,People.home,People.company,People.loc1,People.loc2,People.loc3,People.infected," +
            "job.time1,job.time2,job.rate1,job.rate2,job.rate3,job.value,job.happy1,job.happy2,job.happy3,job.happy4" +
            " from People inner join job on People.type=job.type");
        while (reader.Read())
        {
            GameObject s_Clone = (GameObject)Resources.Load("Prefabs/People");
            s_Clone = Instantiate(s_Clone, new Vector3(0, 2, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), GameObject.Find("Peoples").transform); //二合一
            s_Clone.name = reader.GetString(0);//改名
            people peo = s_Clone.GetComponent<people>();
            //Debug.Log(reader.GetString(0) + reader.GetString(1) + reader.GetString(2) + reader.GetString(3) + reader.GetString(4) + reader.GetString(5) + reader.GetString(6) + 
            //reader.GetString(7) + reader.GetString(8) + reader.GetString(9) + reader.GetString(10) + reader.GetString(11) + reader.GetString(12) + reader.GetString(13) + reader.GetString(14));
            peo.home = GameObject.Find("Homes/" + reader.GetString(1) + "/HTrigger");
            peo.company = GameObject.Find("Homes/" + reader.GetString(2) + "/HTrigger");
            peo.Dest1 = GameObject.Find("Homes/" + reader.GetString(3) + "/HTrigger");
            peo.Dest2 = GameObject.Find("Homes/" + reader.GetString(4) + "/HTrigger");
            peo.Dest3 = GameObject.Find("Homes/" + reader.GetString(5) + "/HTrigger");
            peo.isInfected = reader.GetInt32(6);
            peo.time1 = reader.GetFloat(7);
            peo.time2 = reader.GetFloat(8);
            peo.rate1 = reader.GetFloat(9);
            peo.rate2 = reader.GetFloat(10);
            peo.rate3 = reader.GetFloat(11);
            peo.happy1 = reader.GetInt32(12);
            peo.happy2 = reader.GetInt32(13);
            peo.happy3 = reader.GetInt32(14);
            peo.happy4 = reader.GetInt32(15);
        }

        navMeshSurface.BuildNavMesh();//每次添加后，重新烘焙
        reader.Close();
    }
        void Update()
    {
        //isShow = GameObject.Find("Homes/Home").GetComponent<Transform>();//查找并获取子物体
        //isShow.Translate(Vector3.forward,Space.World);//测试 移动
        /*按键，查找物体Home，克隆，设为子物体
        GameObject gO = GameObject.Find("Homes/Home");
        if(Input.GetKeyDown(KeyCode.S)){
            GameObject gg=Instantiate(gO,isShow.position,isShow.rotation);
            gg.name="House(clone)";
            gg.GetComponent<Transform>().parent=GameObject.Find("Homes").transform;//设为子物体
        }*/
        /*
        //按键，载入预制体，生成副本，设为子物体
        if(Input.GetKeyDown(KeyCode.S)){
            GameObject h_Clone = (GameObject)Resources.Load("Prefabs/House");//载入预制体
                                                                             //Transform trans = h_Clone.GetComponent<Transform>();//获取预制体数据
                                                                             //Debug.Log(trans.transform.position);//测试

            //h_Clone = Instantiate(h_Clone,new Vector3(-10,2,10*count-20),Quaternion.Euler(0.0f,0.0f,0.0f)); //自己设定位置和角度的数据结构
            //h_Clone.GetComponent<Transform>().parent=GameObject.Find("Homes").transform;//设为子物体
            int x = Random.Range(-15, 15) * 10;
            int z = Random.Range(-20, 15) * 10;
            //h_Clone = Instantiate(h_Clone,new Vector3(-10,2,10*count-30),Quaternion.Euler(0.0f,0.0f,0.0f),GameObject.Find("Homes").transform); //二合一
            h_Clone = Instantiate(h_Clone, new Vector3(x, 2,z), Quaternion.Euler(0.0f, 0.0f, 0.0f), GameObject.Find("Homes").transform);
            h_Clone.name = "Home("+count+")";//改名
            

            GameObject s_Clone = (GameObject)Resources.Load("Prefabs/Student");
            //s_Clone = Instantiate(s_Clone,new Vector3(-10,2,10*count-20),Quaternion.Euler(0.0f,0.0f,0.0f)); //自己设定位置和角度的数据结构
            //s_Clone.GetComponent<Transform>().parent=GameObject.Find("Students").transform;//设为子物体
            s_Clone = Instantiate(s_Clone,new Vector3(x,2,z),Quaternion.Euler(0.0f,0.0f,0.0f),GameObject.Find("Students").transform); //二合一
		    s_Clone.name = "student("+count+")";//改名
            student std=s_Clone.GetComponent<student>();
            std.Dest2=GameObject.Find("School/STrigger");
            std.Dest1=GameObject.Find("Homes/Home("+count+")/HTrigger");
            //Debug.Log(GameObject.Find("School/STrigger"));
            //Debug.Log(GameObject.Find("Homes/Home("+count+")/HTrigger"));
            count++;
            */

            
            //Debug.Log(std);

    }
}
