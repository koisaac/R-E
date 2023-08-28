using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;

class FileInStream : MonoBehaviour
{

    
    private static FileInStream filestream = null;
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
    public static FileInStream Instance
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


    public string GetFile_string(string path)
    {
        return File.ReadAllText(path);
    }



    public List<SignalData> GetFile_SignalData()
    {
        return JsonConvert.DeserializeObject<List<SignalData>>(GetFile_string(FileStream.Instance.json_SignalData_filePath)); 
    }

    public List<List<SignalRules>> GetFile_SignalRules()
    {
        return JsonConvert.DeserializeObject<List<List<SignalRules>>>(GetFile_string(FileStream.Instance.json_signalRules_filePath));
    }
}