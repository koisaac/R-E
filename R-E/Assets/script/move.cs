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

            Debug.Log(other.transform.Find("signal_light").GetComponent<signal_light_element>().signal);//현재 자동차가 인식하고 있는 신호 출력
            if (other.transform.Find("signal_light").GetComponent<signal_light_element>().signal == "red")//빨간 불이면 정지 아니면 움직이기
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
        car_sped_x_p = car_sped_x; //이동 방향 초기화
        car_sped_z_p = car_sped_z;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(new Vector3(car_sped_x_p, 0, car_sped_z_p));//이동
    }
}
