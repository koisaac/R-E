using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signal_manager : MonoBehaviour
{
    // Start is called before the first frame update


    public List<GameObject> signallight;




    void Start()
    {
        List<SignalData> signalData = FileStream.Instance.GetFile_SignalData(FileStream.signaldata);


        for(int i=0;i<signalData.Count;i++)
        {
            string bf = "";
            bf = i.ToString() + "��° ��ȣ��" + "��ȣ : " + signalData[i].signal + "��ȸ�� ��ȣ : " + signalData[i].is_turn_left.ToString() ;
            Debug.Log(bf);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
