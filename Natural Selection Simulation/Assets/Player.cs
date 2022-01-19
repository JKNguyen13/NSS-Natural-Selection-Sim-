using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField][Range(1,5)]
    public int amount;
    int amountnum = 0;
    //GlobalData stats = new GlobalData();
    NavMeshAgent agent;
    //public Transform sense;
    //public Transform food;

    public GlobalData stats = new GlobalData();
    int time = 0;
    int deathtimer = 0;
    bool tf = true;
    public Transform agentclone;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        deathtimer++;
        time++;
        amountnum++;
        Debug.Log(stats.food);
        Debug.Log(deathtimer);
        agent = this.GetComponent<NavMeshAgent>();
        if(amountnum < amount){
        Instantiate(agentclone, new Vector3(0,1,0),Quaternion.identity);
        }

        if(time == 2400 && tf){
        agent.destination = new Vector3(Random.Range(-45,45),0,Random.Range(-45,45));
        time = 0;
        }

        if(deathtimer == 12000 && stats.food < 2){
            Destroy(gameObject);
        }

        if(stats.food > 2){
        tf = false;
        this.agent.destination = new Vector3(50,1,0);
        
        //}else if(stats.food == 2){  
        Instantiate(agentclone, new Vector3(0,1,0),Quaternion.identity);
         stats.food = 0;
        }
    }

    
    
}
