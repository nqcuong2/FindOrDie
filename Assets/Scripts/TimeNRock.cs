using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeNRock : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text TimeBox;
    [SerializeField] Text RockBox;
    [SerializeField] Sprite blackHeart;
    [SerializeField] Image[] hearts;

    public static TimeNRock Instance;

    private int currHeartIndex = 0;

    private bool isCutScene= false;

    private float TimeRemaining;
    private int RockRemaining;

    void Start() {
        if (!Instance)
            Instance = this;
    }

    void Update(){
        if(panel.activeInHierarchy == true){
            DisplayTimeNRock();
        }

    }

    public void SetDisplay(){
        isCutScene = false;
    }

    //Display Time and # of Rock
    public void DisplayTimeNRock(){
        if(TimeRemaining>=0)
            TimeBox.text = ((int)GameplayManager.Instance.timeLeft).ToString();

        if(RockRemaining>=0)
            RockBox.text = $"x {GameplayManager.ROCKS_PER_ROUND - GameplayManager.Instance.rocksThrown}";
    }

    public void LoseHeart()
    {
        hearts[currHeartIndex++].sprite = blackHeart;
    }
}
