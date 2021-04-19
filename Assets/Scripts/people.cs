using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class people : MonoBehaviour
{
    public GameObject home, company;
    public GameObject Dest1,Dest2,Dest3;//寻路到目标物体
    public float time1, time2, rate1, rate2, rate3,value, happy1, happy2, happy3, happy4;

    private NavMeshAgent agent;//导航
    public System.Random rd = new System.Random();
    public int isInfected=0;
    public GameObject std;

    // 寻路
    void Start(){
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(Dest1.transform.position);//寻路到目标物体

        if (isInfected==1)
        {
            std.GetComponent<Renderer>().material.color = Color.red;
            Text txt=GameObject.Find("Canvas/numInfected").GetComponent<Text>();
            txt.text=(Int32.Parse(txt.text)+1)+"";
        }

        StartCoroutine(Timer());
    }

    void Update()
    {
        /*
        Random ran=new Random();
        int RandKey=ran.Next(100,999);
        */
    }

    void OnTriggerStay(Collider coll)//
    {
        System.Random ran = new System.Random();
        int RandKey = ran.Next(0, 24);
        //Debug.Log(Time.time);//显示时间
        if (string.Equals(coll.gameObject.name,"HTrigger")){
            //Debug.Log("Get to School");
            if(Time.time%24==time1){
                agent.SetDestination(company.transform.position);
            }
        }

        if(string.Equals(coll.gameObject.name,"HTrigger")){
            //Debug.Log("Get to Home"); 
            if(Time.time%24==time2){
                agent.SetDestination(home.transform.position);
            }
            if (ran.Next(0, 100000)<rate1)
            {
                agent.SetDestination(Dest1.transform.position);
            }
            if (ran.Next(0, 100000) < rate2)
            {
                agent.SetDestination(Dest2.transform.position);
            }
            if (ran.Next(0, 100000) < rate3)
            {
                agent.SetDestination(Dest3.transform.position);
            }
        }

        if (string.Equals(coll.gameObject.tag, "peopletag")&& coll.gameObject.GetComponent<Renderer>().material.color != Color.red)
        {
            if (std.GetComponent<Renderer>().material.color==Color.red)
            {
                if (rd.Next(0,3000) == 1)
                {
                    Debug.Log("感染");
                    coll.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    Text txt = GameObject.Find("Canvas/numInfected").GetComponent<Text>();
                    txt.text = (Int32.Parse(txt.text) + 1) + "";
                }
            }
        }
    }

    IEnumerator Timer() 
    {
        while (true) {
            yield return new WaitForSeconds(1.0f);
            //Debug.Log(string.Format("Timer2 is up !!! time=${0}", Time.time%24));
        }
    }

    /*
    isShow = GameObject.Find("Homes/Home").GetComponent<Transform>();//查找并获取子物体
        //isShow.Translate(Vector3.forward,Space.World);//测试 移动

        GameObject gO = GameObject.Find("Homes/Home");
        if(Input.GetKeyDown(KeyCode.S)){
            GameObject gg=Instantiate(gO,isShow.position,isShow.rotation);
            gg.name="House(clone)";
            gg.GetComponent<Transform>().parent=GameObject.Find("Homes").transform;//设为子物体
        }
    */
}
