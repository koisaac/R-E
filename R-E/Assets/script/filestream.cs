using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading;
using System;
using System.Linq;

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



        StreamReader reader = new StreamReader("Assets\\text\\light_signal.txt");//파일 열기
        
            string[] a = reader.ReadLine().Split(' ');//한 줄 입력받고 공백을 기준으로 자라서 변수 a에 저장
            for(int i = 0; i < g.GetComponent<roads_elemaent>().road.Count; i++)//여러가지의 신호등의 신호변경
            {
            g.GetComponent<roads_elemaent>().road[i].transform.Find("check_road").transform.Find("signal_light").GetComponent<signal_light_element>().signal = a[i];//신호변경
               
            }
        reader.Close();//파일 닫기
    }
}
