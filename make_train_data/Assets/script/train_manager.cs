using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train_manager : MonoBehaviour
{
    public train_manager instance;
    public float award;
    void Awake()
    {
        if(instance == null)
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
        
        FileOutStream.Instance.setAward(award);
    }
}
