using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject unitychan;
    public float defference=20;
   
    // Start is called before the first frame update
    void Start()
    {
        unitychan = GameObject.Find("unitychan");
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position=new Vector3(0,transform.position.y,unitychan.transform.position.z+defference);
    }

   
}
