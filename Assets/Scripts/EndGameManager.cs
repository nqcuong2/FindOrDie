using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{   
    public static EndGameManager Instance;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Victory;
    [SerializeField] GameObject PlayAgainButton;

    [SerializeField] GameObject GameOverPanel;

    [SerializeField] bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!Instance){
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGameOver(){
        GameOver.SetActive(true);
    }

    public void showVictory(){
        Victory.SetActive(true);
    }

    public void showPlayAgain(){
        TimeNRock.Instance.gameObject.SetActive(false);
        PlayAgainButton.SetActive(true);
    }

}
