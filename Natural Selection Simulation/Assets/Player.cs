using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField][Range(1,10)]
    public int agentamount;

    int amountnum = 0;

    NavMeshAgent agent;

    public GlobalData stats = new GlobalData();
    //public GlobalData oandf = new GlobalData();
    //public GlobalData stam = new GlobalData();

    int time = 0;
    int inc = 1;
    int final = 0;
    
    float randomValue;
    [SerializeField]
    int stamina = 8000;
    bool dontDie = true;
    bool stop = true;
    [SerializeField]
    private bool swapNew = true;
    [SerializeField]
    bool clear = true;
    public Transform agentclone;

    void Start()
    {       
        agent = this.GetComponent<NavMeshAgent>();
        swapNew = true;
        GlobalData.amountOfAgents += 1;
        GlobalData.averageSpeed += agent.speed;
        
    }

    void Update()
    {   
        //Debug.Log(stamina); 
        time++;
        final++;
        amountnum++;
        stamina--;
        
        if (amountnum < agentamount){
            Instantiate(agentclone,placementPosition(),Quaternion.identity);
        }
        if(time == 400){
            //inc = 0;
            dontDie = true;
        }
        if(time >= 400 && this.swapNew)
        {
            this.agent.destination = new Vector3(Random.Range(-45,45),0,Random.Range(-45,45));
            time = 0;
        }

        if(stats.food >= 1 && stop){ //add && stamina < 2000
            this.swapNew = false;
            this.clear = false;
            inc = 0;
            this.agent.destination = placementPosition();
            if (stats.food >= 2)
            {
                GlobalData.spawnamount++;
            }
            stats.food = 0;
            stop = false;
        }
        
        if(stamina <= 0 && clear)
        {
            this.agent.destination = this.agent.transform.position;
        }
        if(this.agent.transform.position.x == 48 || this.agent.transform.position.x == -48 || this.agent.transform.position.z == 48 || this.agent.transform.position.z == -48){
            Debug.Log("yay");
            dontDie = false;
        }
        if (final >= 10000 && dontDie) {
            //Debug.Log(1);
            GlobalData.amountOfAgents -= 1;
            GlobalData.averageSpeed -= agent.speed;
            Destroy(this.gameObject);

        } else if (final >= 10000 && clear == false){
                this.swapNew = true;
                Debug.Log(2);
                this.clear = true;
                this.stop = true;
                this.dontDie = true;
                
            for(int i = 0; i < GlobalData.spawnamount; i++){
                randomValue = Random.Range(-0.5f,3);
                Transform instantiated = Instantiate(agentclone,placementPosition(),Quaternion.identity);
                instantiated.GetComponent<NavMeshAgent>().speed += Random.Range(-5,5);
                instantiated.localScale += new Vector3(Random.Range(-0.5f,3),randomValue,Random.Range(-0.5f,3));
                randomValue = 0;
            }

                
                GlobalData.spawnamount = 0;
                stamina = 8000;
                final = 0;
                stats.food = 0;
                inc = 1;
    }
    
    

    }

    Vector3 placementPosition(){
        int posi = Random.Range(1,4);
        if(posi == 1){
            return new Vector3(Random.Range(-48 - inc,48 - inc),1 + randomValue,-48 - inc);
        }else if(posi == 2){
            return new Vector3(Random.Range(-48 - inc,48 - inc),1 + randomValue,48 - inc);
        }else if(posi == 3){
            return new Vector3(-48 - inc,1 + randomValue,Random.Range(-48 - inc,48 - inc));
        }else if(posi == 4){
            return new Vector3(48 - inc,1 + randomValue,Random.Range(-48 - inc,48 - inc));
        }else{
            return new Vector3(0,1,0);
        }
    }   
}
