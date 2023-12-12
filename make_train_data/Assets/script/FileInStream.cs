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


    public int GetFile_situation_signal_type()
    {

        return GetFile_string(FileStream.Instance.json_Situation_signal_type_filePath)[0] - 48;

    }


    public Award GetFile_Award()
    {
        return JsonConvert.DeserializeObject<Award>(GetFile_string(FileStream.Instance.json_Award_filePath));
    }
    public string[][] GetFile_SignalType()
    {
        return JsonConvert.DeserializeObject<string[][]>(GetFile_string(FileStream.Instance.json_signal_type_filePath));
    }

}