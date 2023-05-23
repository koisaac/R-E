using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{
    public float direction;
    private float sped = 0;

    void OnCollisionEnter(Collision collision)
    {
        transform.localEulerAngles = new Vector3(0, direction, 0);
        sped = 0.1f;
         
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);

            Debug.Log(other.transform.Find("signal_light").GetComponent<signal_light_element>().signal);//현재 자동차가 인식하고 있는 신호 출력
            if (other.transform.Find("signal_light").GetComponent<signal_light_element>().signal == "red")//빨간 불이면 정지 아니면 움직이기
            {
                sped = 0;
            }
            else
            {
                sped = 0.1f;
            }

        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sped);
        transform.Translate(new Vector3((sped),0,0));//이동
    }
}
