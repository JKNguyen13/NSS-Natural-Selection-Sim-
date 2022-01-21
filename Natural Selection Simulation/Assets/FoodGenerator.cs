using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{   
    public Transform cubeclone;
    [SerializeField][Range(1,40)]
    public int agentamount;

    int amountnum = 0;
    
    //gameObject clone;
    
    // Start is called before the first frame update
    void Start()
    {
        
    
    }


    // Update is called once per frame
    void Update()
    {   
        amountnum++;
        if(amountnum - 1 < agentamount){
        Instantiate(cubeclone, new Vector3(Random.Range(-45,45), 1, Random.Range(-45,45)),Quaternion.identity);
 
     

        }
    }

    /*public void OnTriggerEnter (Collider other) {
        if(other.gameObject.tag == "Agent"){
            Destroy(gameObject);
            //agent.destination = new Vector3(0,1,0);
            Debug.Log(1);
        }
    }*/
}
