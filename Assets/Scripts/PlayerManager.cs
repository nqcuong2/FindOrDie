﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public static GameObject rockPrefab;
    [SerializeField] Transform rightHandTransform;
    [SerializeField] int throwForce = 1000;

    public static AudioSource PlayerAudioSource { get; private set; }

    private const string THROW_STATE = "Throw";
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play(THROW_STATE);
        }
    }

    public void ThrowRock()
    {
        if (rockPrefab != null)
        {
            var rock = Instantiate(rockPrefab);
            rock.transform.position = rightHandTransform.position;
            rock.GetComponent<Rigidbody>().AddRelativeForce(Camera.main.transform.forward * throwForce);
        }
    }
}
