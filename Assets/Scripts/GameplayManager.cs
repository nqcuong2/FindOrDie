using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public const int NUMBER_ROUNDS = 5;
    public const float TIME_PER_ROUND = 10;
    public const int ROCKS_PER_ROUND = 2;

    public int rocksThrown = 0;
    public int roundsPassed = 0;
    public float timeLeft = TIME_PER_ROUND;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = TIME_PER_ROUND;
            rocksThrown = 0;
            roundsPassed++;
            LightManager.lightsOff = true;
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
}
