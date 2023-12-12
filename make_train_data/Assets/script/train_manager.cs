using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEditor;


public class train_manager : MonoBehaviour
{
    public train_manager instance;
    public float award;
    public GameObject car;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        this.award = 0;

    }

    // Update is called once per frame
    void Update()
    {
        award = 0;
        for (int i = 0; i < car.transform.childCount; i++)
        {
            award -= car.transform.GetChild(i).GetComponent<get_award>().waitTimer;
            
        }
        if (Colliddetact.IsCrashed)
        {
            award -= 99999999999999;
        }
        FileOutStream.Instance.setAward(award, Colliddetact.IsCrashed);
    }
}
