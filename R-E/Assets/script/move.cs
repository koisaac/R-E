using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{

    void OnCollisionStay(Collision collision)//��ü�� ���� �پ� ���� �� ����
    {
        string a = collision.transform.Find("signal_light").GetComponent<set_signal>().signal; //��ȣ���� ��ȣ�� �������� �˾Ƴ���. 
        if (a == "green")//�ʷϺ��̸� �̵��Ѵ�
        {
            transform.Translate(new Vector3(-1,0,0));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
