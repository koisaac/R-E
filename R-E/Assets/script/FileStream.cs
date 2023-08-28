using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

[System.Serializable]
public class SignalData
{
    public string signal;
    public bool is_turn_left;
    public SignalData(string signal, bool is_turn_left)
    {
        this.signal = signal;
        this.is_turn_left= is_turn_left;
    }


}

[System.Serializable]
public class SignalRules
{
    public string signal;
    public int hold_time;
}



class FileStream : MonoBehaviour
{



    public string json_SignalData_filePath;
    public string json_signalRules_filePath;
    private const string SignalData = "Signal";
    private const string RulesData = "Rules";

    public static string signaldata {
        get
        {
            return SignalData;
        }
    }
    public static string rulesData
    {
        get
        {
            return RulesData;
        }
    }

    public GameObject this_object;


    void Start()
    {



        int light_number = this_object.GetComponent<signal_manager>().signallight.Count;
        for (int i = 0; i < light_number*4; i++)
        {
            Debug.Log(i);
            FileOutStream.Instance.add_signal("red",false);
        }

        this_object.GetComponent<signal_manager>().SetSignal();

        



    }

    private static FileStream filestream = null;
    void Awake()
    {
        if (filestream == null)
        {

            filestream = this;
        }
        else if (filestream != this)
        {
            Destroy(this);
        }
    }
    public static FileStream Instance
    {
        get
        {
            if (filestream == null)
            {
                return null;
            }
            return filestream;
        }
    }

    
}





