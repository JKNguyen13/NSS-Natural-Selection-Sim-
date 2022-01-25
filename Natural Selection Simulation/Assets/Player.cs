using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField][Range(1,5)]
    public int agentamount;

    int amountnum = 0;

    NavMeshAgent agent;
    public GlobalData stats = new GlobalData();
    //public GlobalData stam = new GlobalData();
    
    int time = 0;
    [SerializeField]
    bool tf = true;

    public Transform agentclone;

    // Start is called before the first frame update
    void Start()
    {       
        agent = this.GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {          
        time++;
        amountnum++;     
        //Debug.Log(GlobalData.spawnamount);               
        if(amountnum < agentamount){
            Instantiate(agentclone,placementPosition(),Quaternion.identity);
        }

        if(time >= 2400 && tf){
            agent.destination = new Vector3(Random.Range(-45,45),0,Random.Range(-45,45));
            time = 0;
        }

        /*if(stats.food < 2){
            tf = true;
        }*/

        if(stats.food >= 2){
            Debug.Log(4);
            tf = false;

            this.agent.destination = placementPosition();
            GlobalData.spawnamount++;
            stats.food = 0;
        }
        
        if(DayData.daytimer >= 12000 && stats.food < 1){
            Debug.Log(1);
            GlobalData.spawnamount = 0;
            DayData.daytimer = 0;
            stats.food = 0;
            tf = true;
            Destroy(this.gameObject);
            Debug.Log(3);
            tf = true;
        }
        if(DayData.daytimer >= 12000){
            for(int i = 0; i < GlobalData.spawnamount; i++){
               Debug.Log(2);
                tf=true;
                //GameObject newSpawn = Instantiate(agentclone.gameObject, placementPosition(),Quaternion.identity);
                Instantiate(agentclone,placementPosition(),Quaternion.identity);
                //NavMeshAgent instantAgent = newSpawn.GetComponent<NavMeshAgent>();
                //instantAgent.destination = new Vector3(Random.Range(-45,45),0,Random.Range(-45,45));
            }
    }

    }

    Vector3 placementPosition(){
        //tf = true;
        int posi = Random.Range(1,4);
        if(posi == 1){
            return new Vector3(Random.Range(-48,48),1,-48);
        }else if(posi == 2){
            return new Vector3(Random.Range(-48,48),1,48);
        }else if(posi == 3){
            return new Vector3(-48,1,Random.Range(-48,48));
        }else if(posi == 4){
            return new Vector3(48,1,Random.Range(-48,48));
        }else{
            return new Vector3(0,1,0);
        }
    }   
}
