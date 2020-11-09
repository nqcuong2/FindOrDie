using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    
    public bool endSound = true;

    public int gameState = 0;

    public const int NUMBER_ROUNDS = 5;
    public const float TIME_PER_ROUND = 25;
    public const int ROCKS_PER_ROUND = 2;

    public int rocksThrown = 0;
    public int roundsPassed = 0;
    [HideInInspector] public float timeLeft;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
            Instance = this;

        timeLeft = TIME_PER_ROUND;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {   
            if(gameState==0){
                StoryManager.Instance.ShowIntro();
                StoryManager.Instance.ShowInstruct_1();
                StoryManager.Instance.ShowInstruct_2();
            }else if(gameState==2){
                StoryManager.Instance.ShowDark_1();
            }else if(gameState==3){
                StoryManager.Instance.ShowDark_2();
            }else if(gameState==4){
                StoryManager.Instance.ShowDark_3();
            }
            gameState++;
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                LightManager.lightsOff = true;
                Invoke("DoThingsWhenLightsOff", 1.5f);
                timeLeft = TIME_PER_ROUND;
                rocksThrown = 0;
                roundsPassed++;
                if (roundsPassed > NUMBER_ROUNDS)
                {
                    gameOver = true;
                } 
                else
                {
                    TimeNRock.Instance.LoseHeart();
                }
            }

            if (Input.GetMouseButtonDown(0) && PlayerManager.Instance.CanThrowRock())
            {
                PlayerManager.Instance.ThrowRock();
                rocksThrown++;
                if (rocksThrown == ROCKS_PER_ROUND)
                {
                    PlayerManager.Instance.DisallowThrowingRock();
                }
            }
        }
        else
        {
            if (roundsPassed == NUMBER_ROUNDS + 1)
            {
                //Lost. Show lost screen
                Debug.Log("Lost");
                EndGameManager.Instance.playLose(endSound);
                EndGameManager.Instance.showGameOver();
                EndGameManager.Instance.showPlayAgain();
            } 
            else
            {
                //Won. Show won screen
                Debug.Log("Won");
                EndGameManager.Instance.playLose(endSound);
                EndGameManager.Instance.showVictory();
                EndGameManager.Instance.showPlayAgain();
            }
            endSound =false;
        }
    }

    void DoThingsWhenLightsOff()
    {
        MonsterManager.Instance.SelectRandomMonsterObject();
        PlayerManager.Instance.AllowThrowingRock();
        PlayerManager.Instance.CleanRocks();
    }
}
