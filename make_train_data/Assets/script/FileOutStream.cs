using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using System.Linq;
using Unity.VisualScripting;

public class FileOutStream : MonoBehaviour
{
    private static FileOutStream filestream = null;
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
    public static FileOutStream Instance
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


    public void add_signal(string signal, bool is_turn_left)
    {
        SignalData signalData = new SignalData(signal, is_turn_left);
        List<SignalData> jsondata_class = FileInStream.Instance.GetFile_SignalData();
        jsondata_class.Add(signalData);

        ApplyToFile(jsondata_class);
    }
    public void set_situation_car_number(int[] car_number)
    {
        Debug.Log(JsonConvert.SerializeObject(car_number));
        File.WriteAllText(FileStream.Instance.json_Situation_car_number_filePath, JsonConvert.SerializeObject(car_number));


    }

    public void setsignal(int Signal_number, string chae_light)
    {
        List<SignalData> jsondata_class = FileInStream.Instance.GetFile_SignalData();
        jsondata_class[Signal_number].signal = chae_light;

        ApplyToFile(jsondata_class);
    }

    public void setAward(float award, bool is_renewal)
    {
        Award aw = FileInStream.Instance.GetFile_Award();
        aw.award = award;
        aw.is_crash = is_renewal;
        File.WriteAllText(FileStream.Instance.json_Award_filePath, JsonConvert.SerializeObject(aw));
    }

    private void ApplyToFile(List<SignalData> JSON)
    {
        string jsondata_string = JsonConvert.SerializeObject(JSON);

        File.WriteAllText(FileStream.Instance.json_SignalData_filePath, jsondata_string);
    }

    private void ApplyToFile(string JSON, string File_path)
    {
        Debug.Log(File_path);
        Debug.Log(JSON);
        File.WriteAllText(File_path, "{ car_number :" + JSON + "}");
    }


}
