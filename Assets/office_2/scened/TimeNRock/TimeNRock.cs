using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeNRock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int TotalRock;

    [SerializeField] float TotalTime;

    [SerializeField] GameObject panel;

    [SerializeField] Text TimeBox;

    [SerializeField] Text RockBox;

    private bool isCutScene= false;

    private bool OutOfTime = false;

    private float TimeRemaining;
    private int RockRemaining;

    void Start() {
        RockRemaining = TotalRock;
        TimeRemaining = TotalTime;
    }

    void Update(){
        if(panel.activeInHierarchy == true){
            if(!OutOfTime){DecreaseTime();}
            displayTimeNRock();
        }

    }

    public void SetDisplay(){
        isCutScene = false;
    }

    //Start counting for the round, when done, set true to OutOfTime
    public void DecreaseTime(){
        TimeRemaining -= Time.deltaTime;
        if(TimeRemaining<0){
            OutOfTime = true;
            TimeRemaining = 0;
        }
        
    }

    //Return true if player is out of time for the round
    public bool isTimeOut(){
        return OutOfTime;
    }

    public void DecreaseRock(){
        RockRemaining--;
    }
    //Display Time and # of Rock
    public void displayTimeNRock(){
        if(TimeRemaining>=0){TimeBox.text = ((int)TimeRemaining).ToString();}

        if(RockRemaining>=0){RockBox.text = RockRemaining.ToString() + "/"+TotalRock;}
    }
}
