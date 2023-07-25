using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;
public class filestream : MonoBehaviour
{
    //�̱���
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
    //�̱���




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

        string s = File.ReadAllText(path);//���� �б�
        JObject j = JObject.Parse(s);//jsonó��

           /* for (int i = 0; i < g.GetComponent<roads_elemaent>().road.Count; i++)//���������� ��ȣ���� ��ȣ����
        {
            g.GetComponent<roads_elemaent>().road[i].transform.Find("check_road").transform.Find("signal_light").GetComponent<signal_light_element>().signal = (string)j["traffics"]["at_road"+(i+1).ToString()]["CurrentState"];//��ȣ����
            g.GetComponent<roads_elemaent>().road[i].transform.Find("check_road").transform.Find("signal_light").GetComponent<signal_light_element>().left_signal = (bool)j["traffics"]["at_road" + (i+1).ToString()]["leftsignal"];//��ȣ����
        }*/
    }
}
