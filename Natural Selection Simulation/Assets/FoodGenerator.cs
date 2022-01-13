using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{   
    public Transform cubeclone;
    int check = 1;
    //gameObject clone;
    public float[] values;
    // Start is called before the first frame update
    void Start()
    {
        
    
    }


    // Update is called once per frame
    void Update()
    {
        if(check < 20){
        var clone = Instantiate(cubeclone, new Vector3(Random.Range(-45,45), 1, Random.Range(-45,45)),Quaternion.identity);
        check++;
        values[].Add(clone.position);

        }
    }

    public void OnTriggerEnter (Collider gameObject) {
        if(gameObject.CompareTag("Agent")){
            Destroy(gameObject);
            Debug.Log(1);
        }
    }
}
