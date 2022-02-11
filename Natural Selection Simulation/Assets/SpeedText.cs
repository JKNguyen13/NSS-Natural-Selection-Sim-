using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedText : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI dayTimerText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = "Average Speed = " + GlobalData.averageSpeed / GlobalData.amountOfAgents;
        GlobalData.daytimer++;
        dayTimerText.text = "Time = " + GlobalData.daytimer;
    }
}
