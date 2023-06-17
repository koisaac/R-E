using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_car_manager : MonoBehaviour
{
    //싱글톤 구현
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
    //싱글톤 구현

    public GameObject car_p; //프리팹

    private List<GameObject> start_point = new List<GameObject>();//시작 위치를 알려주는 오브젝트
    
    private List<GameObject> car = new List<GameObject>(); //자동차 객체 저장하는 변수 
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

            car.Add(Instantiate(car_p));//자동차 생성
            car[i + number_of_car].transform.position = start_point[i].transform.position;//자동차 위치 설정
            car[i + number_of_car].GetComponent<move>().direction = start_point[i].GetComponent<start_point_element>().direction;//자동차 이동방향 설정
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
