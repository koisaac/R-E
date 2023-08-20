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
}

class FileStream : MonoBehaviour
{

    public string json_filePath;
    private const string SignalData = "Signal"; 

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

    public static string signaldata => SignalData;

    public string GetFile_string(string path)
    {
        return File.ReadAllText(path);
    }

    public List<SignalData> GetFile_SignalData(string path)
    {
        switch (path)
        {
            case "Signal":
                return JsonConvert.DeserializeObject<List<SignalData>>(GetFile_string(json_filePath));
            default:
                return JsonConvert.DeserializeObject<List<SignalData>>(GetFile_string(path));
        }
    }
}