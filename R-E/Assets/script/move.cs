using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//test_1
public class move : MonoBehaviour
{
    public float direction;
    private float sped = 0;
    private Ray ray;
    private RaycastHit hit;

    void OnCollisionEnter(Collision collision)
    {
        transform.localEulerAngles = new Vector3(0, direction, 0);
        sped = 0.1f;

    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);

        Debug.Log(other.transform.Find("signal_light").GetComponent<signal_light_element>().signal);//���� �ڵ����� �ν��ϰ� �ִ� ��ȣ ���
        if (other.transform.Find("signal_light").GetComponent<signal_light_element>().signal == "red" || Physics.Raycast(ray, 10))//���� ���̸� ���� �ƴϸ� �����̱�
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
        ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3((sped), 0, 0));//�̵�

    }
}
