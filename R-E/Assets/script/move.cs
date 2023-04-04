using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{

    void OnCollisionStay(Collision collision)//물체가 서로 붙어 있을 때 실행
    {
        string a = collision.transform.Find("signal_light").GetComponent<set_signal>().signal; //신호등의 신호가 무엇인지 알아낸다. 
        if (a == "green")//초록불이면 이동한다
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
