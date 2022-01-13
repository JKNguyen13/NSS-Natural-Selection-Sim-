using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform sense;
    public Transform food;

    int time = 0;
    bool tf = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        time++;

        agent = this.GetComponent<NavMeshAgent>();

        if(time == 2400 && GlobalData.tf){
        agent.destination = new Vector3(Random.Range(-45,45),0,Random.Range(-45,45));
        time = 0;
        }
    }

    public void OnTriggerEnter (Collider gameObject) {
        if(gameObject.CompareTag("Food")){
            //Destroy (GameObject.FindWithTag("Food"));
            GlobalData.tf = false;
            //agent.destination = new Vector3(0,1,0);
            agent.destination = food.transform.position;

        }

        }
    
}
