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



        StreamReader reader = new StreamReader("Assets\\text\\light_signal.txt");//���� ����
        
            string[] a = reader.ReadLine().Split(' ');//�� �� �Է¹ް� ������ �������� �ڶ� ���� a�� ����
            for(int i = 0; i < g.GetComponent<roads_elemaent>().road.Count; i++)//���������� ��ȣ���� ��ȣ����
            {
            g.GetComponent<roads_elemaent>().road[i].transform.Find("check_road").transform.Find("signal_light").GetComponent<signal_light_element>().signal = a[i];//��ȣ����
               
            }
        reader.Close();//���� �ݱ�
    }
}
