using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class move : MonoBehaviour
{
    public float car_sped_x,car_sped_z;
    private float car_sped_x_p=0,car_sped_z_p=0;
    void OnCollisionEnter(Collision collision)
    {
        car_sped_x_p = car_sped_x; //�̵� ���� �ʱ�ȭ
        car_sped_z_p = car_sped_z;
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
    void OnTriggerStay(Collider other)
    {
        
            Debug.Log(other.transform.Find("signal_light").GetComponent<signal_light_element>().signal);//���� �ڵ����� �ν��ϰ� �ִ� ��ȣ ���
            if (other.transform.Find("signal_light").GetComponent<signal_light_element>().signal == "red")//���� ���̸� ���� �ƴϸ� �����̱�
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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(car_sped_x_p,0,car_sped_z_p));//�̵�
    }
}
