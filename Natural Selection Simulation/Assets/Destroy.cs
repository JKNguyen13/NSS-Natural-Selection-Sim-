using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Destroy : MonoBehaviour
{   
    
    public static int food;
    //public gameObject agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Agent"){
            Destroy(gameObject);
            //GlobalData.tf = false;
            //other.GetComponent<Player>().stats.food++;
            GlobalData.food = 1;
            //agent.destination = new Vector3(0,1,0);
            //Debug.Log(1);
        }
    }
}
