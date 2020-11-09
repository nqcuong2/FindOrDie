using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{   

    [SerializeField] AudioClip VictorySound;
    [SerializeField] AudioClip LoseSound;
    public static EndGameManager Instance;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Victory;
    [SerializeField] GameObject PlayAgainText;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void showGameOver(){
        GameOver.SetActive(true);
    }

    public void showVictory(){
        Victory.SetActive(true);
    }

    public void showPlayAgain(){
        TimeNRock.Instance.gameObject.SetActive(false);
        PlayAgainText.SetActive(true);
    }

    public void playVictory(bool play){
        if(play){
            PlayerManager.PlayerAudioSource.PlayOneShot(VictorySound);
        }
    }

    public void playLose(bool play){
        if(play){
          PlayerManager.PlayerAudioSource.PlayOneShot(LoseSound);
        }
    }
}
