using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading;
using System.Diagnostics;
using System;

public class filestream : MonoBehaviour
{
    public GameObject g;

    int number_of_signal_lights = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        StreamReader reader = new StreamReader("Assets\\text\\light_signal.txt");
        
            string[] a = reader.ReadLine().Split(' ');
            UnityEngine.Debug.Log(a[0]);
            for(int i = 0; i < number_of_signal_lights; i++)
            {
                
                g.GetComponent<set_road>().road[i].GetComponentInChildren<set_signal>().signal = a[i];
            }
        reader.Close();
    }
}
