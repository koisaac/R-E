using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading;
using System.Diagnostics;
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



        StreamReader reader = new StreamReader("Assets\\text\\light_signal.txt");
        
            string[] a = reader.ReadLine().Split(' ');
            for(int i = 0; i < g.GetComponent<roads_elemaent>().road.Count; i++)
            {
                
                g.GetComponent<roads_elemaent>().road[i].GetComponentInChildren<signal_light_element>().signal = a[i];
            }
        reader.Close();
    }
}
