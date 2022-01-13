using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sense : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider gameObject) {
        if(gameObject.CompareTag("Food")){
            //GlobalData.agent.destination = new Vector3(0,1,0);

        }
    }
}
