using System;
using UnityEngine;
using UnityEngine.UI;
using XCharts;
public class lineChart : MonoBehaviour
{
    public GameObject lChart,Txt;//XChart插件里的LineChart
    public LineChart chart;
    public int i = 1;
    void Start()
    {
        chart = lChart.GetComponent<LineChart>();
        /*if (chart == null)
        {
            Debug.Log("ChartNull");
            chart = lChart.AddComponent<LineChart>();
            chart.SetSize(580, 300);//代码动态添加图表需要设置尺寸，或直接操作chart.rectTransform
            chart.title.show = true;
            chart.title.text = "Line Simple";
        }*/
        chart.AddSerie(SerieType.Line, "感染人数");
    }
    void Update()
    {
        if (i % 100 == 0)
        {
            Text txt = Txt.GetComponent<Text>();
            chart.series.AddData("感染人数", Int32.Parse(txt.text));
            chart.xAxis0.AddData((int)Time.time + "");
        }
        i++;
    }
}
