using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_signal : MonoBehaviour
{
    public string signal = "yellow";//��ȣ�� ����
    public bool left_signal = false;//��ȸ�� ��ȣ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(signal);
    }
}
