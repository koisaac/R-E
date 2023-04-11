using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{
    public float car_sped_x,car_sped_z;
    private float car_sped_x_p,car_sped_z_p;
    void OnTriggerStay(Collider other)
    {

            Debug.Log(other.transform.Find("signal_light").GetComponent<signal_light_element>().signal);
            if (other.transform.Find("signal_light").GetComponent<signal_light_element>().signal == "red")//초록불이면 이동한다
            {
                car_sped_x_p = 0;
                car_sped_z_p = 0;
            }
            else
            {
                car_sped_x_p = car_sped_x;
                car_sped_z_p = car_sped_z;
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        car_sped_x_p = car_sped_x;
        car_sped_z_p = car_sped_z;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(new Vector3(car_sped_x_p, 0, car_sped_z_p));
    }
}
