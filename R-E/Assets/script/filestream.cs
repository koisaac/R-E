using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;
public class filestream : MonoBehaviour
{
    //싱글톤
    private static filestream Filestream=null;
    void Awake()
    {
        if (Filestream == null)
        {
            Filestream = this;
        }
        else if (Filestream != this)
        {
            Destroy(this);
        }
    }
    public static filestream Instance
    {
        get
        {
            if (Filestream == null)
            {
                return null;
            }
            return Filestream;
        }
    }
    //싱글톤




    public string path = "Assets\\text\\light_signal.json";

    private filestream()
    {
        

    }

    public string get_data_string()
    {
        return File.ReadAllText(path);
    }
    public JObject get_data_jobject()
    {
        return JObject.Parse(get_data_string());
    }


    void Update()
    {

        string s = File.ReadAllText(path);//파일 읽기
        JObject j = JObject.Parse(s);//json처리

           /* for (int i = 0; i < g.GetComponent<roads_elemaent>().road.Count; i++)//여러가지의 신호등의 신호변경
        {
            g.GetComponent<roads_elemaent>().road[i].transform.Find("check_road").transform.Find("signal_light").GetComponent<signal_light_element>().signal = (string)j["traffics"]["at_road"+(i+1).ToString()]["CurrentState"];//신호변경
            g.GetComponent<roads_elemaent>().road[i].transform.Find("check_road").transform.Find("signal_light").GetComponent<signal_light_element>().left_signal = (bool)j["traffics"]["at_road" + (i+1).ToString()]["leftsignal"];//신호변경
        }*/
    }
}
