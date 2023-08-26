using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManger : MonoBehaviour
{
    public int camera_number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(camera_number == button.camera_type)
        {
            this.GetComponent<Camera>().depth = 1;
        }
        else
        {
            this.GetComponent<Camera>().depth = 0;
        }
    }
}
