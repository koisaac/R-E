using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading;
using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class filestream : MonoBehaviour
{
    public GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        string s = File.ReadAllText("Assets\\text\\light_signal.json");//파일 읽기
        JObject j = JObject.Parse(s);//json처리
        for(int i = 0; i < g.GetComponent<roads_elemaent>().road.Count; i++)//여러가지의 신호등의 신호변경
        {
            g.GetComponent<roads_elemaent>().road[i].transform.Find("check_road").transform.Find("signal_light").GetComponent<signal_light_element>().signal = (string)j["signal"][i.ToString()];//신호변경   
        }
    }
}
