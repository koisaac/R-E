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
        GetComponent<MeshRenderer>().material = set_material; //신호등을 초기 상태로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if(name == transform.parent.GetComponent<signal_light_element>().signal)  //신호에 맞추어 신호등의 신호 변경
        {
            GetComponent<MeshRenderer>().material = change_material; //신호 켜기
        }
        else
        {
            GetComponent<MeshRenderer>().material = set_material; //신호 끄기
        }


        if (name == "right_signal" && transform.parent.GetComponent<signal_light_element>().left_signal) //좌회전 신호 표시
        {
            GetComponent<MeshRenderer>().material = change_material; //신호 켜기
        }
        else if(name == "right_signal")
        {
            GetComponent<MeshRenderer>().material = set_material; //신호 끄기
        }
    }
}
