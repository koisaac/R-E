using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_car_manager : MonoBehaviour
{
    //�̱��� ����
    private static set_car_manager manager = null;
    void Awake()
    {
        if (manager == null)
        {
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(this);
        }
    }
    public static set_car_manager Instance
    {
        get
        {
            if (manager == null)
            {
                return null;
            }
            return manager;
        }
    }
    //�̱��� ����

    public GameObject car_p; //������

    private List<GameObject> start_point = new List<GameObject>();//���� ��ġ�� �˷��ִ� ������Ʈ
    
    private List<GameObject> car = new List<GameObject>(); //�ڵ��� ��ü �����ϴ� ���� 
    public List<GameObject> cars
    {
        get
        {
            return car;
        }
    }


    private int number_of_car = 0;
    public List<GameObject> SetCar(int number_of_cars)
    {
        set_start_point();
        for (int i = 0; i < number_of_cars; i++)
        {

            car.Add(Instantiate(car_p));//�ڵ��� ����
            car[i + number_of_car].transform.position = start_point[i].transform.position;//�ڵ��� ��ġ ����
            car[i + number_of_car].GetComponent<move>().direction = start_point[i].GetComponent<start_point_element>().direction;//�ڵ��� �̵����� ����
        }
        number_of_car = number_of_cars;
        return car;
    }

    private void set_start_point()
    {
        set_road_manager set_Road = set_road_manager.Instance;
        List<GameObject> road_list = set_Road.roads;


        for (int i = 0; i < road_list.Count; i++)
        {
            start_point.Add(road_list[i].transform.Find("start_point_"+(i+1).ToString()).gameObject);
        }
    }

}
