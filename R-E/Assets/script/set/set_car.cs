using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_car : MonoBehaviour
{
    public List<GameObject> start_point; //���� ��ġ�� �˷��ִ� ������Ʈ
    public GameObject car; //������
    public int number_of_cars; //�ڵ��� ���� ����
    public List<GameObject> cars; //�ڵ��� ��ü �����ϴ� ����
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<number_of_cars;i++) {
            
            cars.Add(Instantiate(car));//�ڵ��� ����
            cars[i].transform.position = start_point[i].transform.position;//�ڵ��� ��ġ ����
            cars[i].GetComponent<move>().car_sped_x = start_point[i].GetComponent<start_point_element>().sped_x;//�ڵ��� �̵����� ����
            cars[i].GetComponent<move>().car_sped_z = start_point[i].GetComponent<start_point_element>().sped_z;//�ڵ��� �̵����� ����
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
