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
        GetComponent<MeshRenderer>().material = set_material;
    }

    // Update is called once per frame
    void Update()
    {
        if(name == transform.parent.GetComponent<set_signal>().signal)
        {
            GetComponent<MeshRenderer>().material = change_material;
        }
        else
        {
            GetComponent<MeshRenderer>().material = set_material;
        }
        if (name == "right_signal" && transform.parent.GetComponent<set_signal>().right_signal) { }
        {

        }
    }
}
