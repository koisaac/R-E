using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        Debug.Log('a');
       
        Debug.Log(other.transform.Find("signal_light").GetComponent<set_signal>().signal);
        if (other.transform.Find("signal_light").GetComponent<set_signal>().signal == "green")//초록불이면 이동한다
        {
            transform.Translate(new Vector3((float)-0.2, 0, 0));
        }
    }
    void OnTriggerExit(Collider other)
    {
            Destroy(gameObject);
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
