using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_signal_light : MonoBehaviour
{
    public Material set_material;
    public Material change_material;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = set_material; //��ȣ���� �ʱ� ���·� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if(name == transform.parent.GetComponent<signal_light_element>().signal)  //��ȣ�� ���߾� ��ȣ���� ��ȣ ����
        {
            GetComponent<MeshRenderer>().material = change_material; //��ȣ �ѱ�
        }
        else
        {
            GetComponent<MeshRenderer>().material = set_material; //��ȣ ����
        }


        if (name == "right_signal" && transform.parent.GetComponent<signal_light_element>().left_signal) //��ȸ�� ��ȣ ǥ��
        {
            GetComponent<MeshRenderer>().material = change_material; //��ȣ �ѱ�
        }
        else if(name == "right_signal")
        {
            GetComponent<MeshRenderer>().material = set_material; //��ȣ ����
        }
    }
}
