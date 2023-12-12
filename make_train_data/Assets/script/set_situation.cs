using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Newtonsoft.Json;

public class set_situation : MonoBehaviour
{


    public GameObject car_file;

    void Awake()
    {



    }

    void start_test()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string[][] signal_type = FileInStream.Instance.GetFile_SignalType();
        int[] car_number = new int[4];
        int signal = FileInStream.Instance.GetFile_situation_signal_type();
        for (int i = 0; i < car_number.Length; i++)
        {
            car_number[i] = 0;
        }
        for (int i = 0; i < car_file.transform.childCount; i++)
        {
            if (!car_file.transform.GetChild(i).gameObject.activeSelf)
            {
                continue;
            }
            if (car_file.transform.GetChild(i).gameObject.transform.position.z < -9)
            {
                car_number[0] += 1;
            }
            else if (car_file.transform.GetChild(i).gameObject.transform.position.x < -9)
            {
                car_number[1] += 1;
            }
            else if (car_file.transform.GetChild(i).gameObject.transform.position.z > 9)
            {
                car_number[2] += 1;
            }
            else if (car_file.transform.GetChild(i).gameObject.transform.position.x > 9)
            {
                car_number[3] += 1;
            }
        }
        for (int i = 0; i < signal_type[signal].Length; i++)
        {
            
            FileOutStream.Instance.setsignal(i, signal_type[signal][i]);
        }
        FileOutStream.Instance.set_situation_car_number(car_number);
    }
}
