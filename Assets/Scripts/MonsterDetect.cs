﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetect : MonoBehaviour
{
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioClip dieSound;

    private bool firstHit;

    // Start is called before the first frame update
    void Start()
    {
        firstHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (firstHit)
        {
            if (collision.collider.tag == "Monster")
            {
                Debug.Log("Monster hit");
                PlayerManager.PlayerAudioSource.PlayOneShot(dieSound);
                GameplayManager.Instance.gameOver = true;
                return;
            }

            PlayerManager.PlayerAudioSource.PlayOneShot(hitSound);
            firstHit = false;
        }
    }
}
