using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_car : MonoBehaviour
{
    public List<GameObject> start_point; //시작 위치를 알려주는 오브젝트
    public GameObject car; //프리팹
    public int number_of_cars; //자동차 생성 갯수
    public List<GameObject> cars; //자동차 객체 저장하는 변수
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<number_of_cars;i++) {
            
            cars.Add(Instantiate(car));//자동차 생성
            cars[i].transform.position = start_point[i].transform.position;//자동차 위치 설정
            cars[i].GetComponent<move>().direction = start_point[i].GetComponent<start_point_element>().direction;//자동차 이동방향 설정
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
