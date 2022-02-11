using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sense : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Food"){
            GameObject food = GameObject.FindWithTag("Food");
            
            agent.destination = food.transform.position;

        }
    }
}
