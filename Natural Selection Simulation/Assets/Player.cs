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
    //public GlobalData oandf = new GlobalData();
    //public GlobalData stam = new GlobalData();

    int time = 0;
    int final = 0;
    int stamina = 4000;

    [SerializeField]
    private bool swapNew = true;
    [SerializeField]
    bool clear = true;
    public Transform agentclone;

    void Start()
    {       
        agent = this.GetComponent<NavMeshAgent>();
        swapNew = true;
    }

    void Update()
    {   //Debug.Log(GlobalData.spawnamount);
        Debug.Log(stamina); 
        time++;
        final++;
        amountnum++;
        stamina--;
        
        if (amountnum < agentamount){
            Instantiate(agentclone,placementPosition(),Quaternion.identity);
        }

        if(time >= 400 && this.swapNew)
        {
            this.agent.destination = new Vector3(Random.Range(-45,45),0,Random.Range(-45,45));
            time = 0;
        }

        if(stats.food >= 1){
            this.swapNew = false;
            this.clear = false;
            this.agent.destination = placementPosition();
            if (stats.food >= 2)
            {
                GlobalData.spawnamount++;
            }
            stats.food = 0;
        }
        if(stamina <= 0 && clear)
        {
            this.agent.destination = this.agent.transform.position;
        }
        if (final >= 5500 && clear) {
            Debug.Log(1);
            Destroy(this.gameObject);

        } else if (final >= 5500 && clear == false){
                this.swapNew = true;
                Debug.Log(2);
                this.clear = true;
            for(int i = 0; i < GlobalData.spawnamount; i++){
                Instantiate(agentclone,placementPosition(),Quaternion.identity);
            }
                
                GlobalData.spawnamount = 0;
                stamina = 4000;
                final = 0;
    }

    }

    Vector3 placementPosition(){
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
