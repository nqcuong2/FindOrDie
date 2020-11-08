using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public const int NUMBER_ROUNDS = 5;
    public const float TIME_PER_ROUND = 30;
    public const int ROCKS_PER_ROUND = 2;

    public int rocksThrown = 0;
    public int roundsPassed = 0;
    public float timeLeft = TIME_PER_ROUND;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            timeLeft -= Time.deltaTime;
            TimeNRock.Instance.TimeRemaining = timeLeft;
            TimeNRock.Instance.RockRemaining = ROCKS_PER_ROUND - rocksThrown;

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
            }

            if (Input.GetMouseButtonDown(0) && PlayerManager.Instance.fakeHandRock != null && PlayerManager.Instance.fakeHandRock.activeSelf)
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
            } 
            else
            {
                //Won. Show won screen
                Debug.Log("Won");
            }
        }
    }

    void DoThingsWhenLightsOff()
    {
        MonsterManager.Instance.SelectRandomMonsterObject();
        PlayerManager.Instance.AllowThrowingRock();
    }
}
