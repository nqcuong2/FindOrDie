using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject rockPrefab;
    [SerializeField] public GameObject fakeHandRock;
    [SerializeField] Transform rightHandTransform;
    [SerializeField] int throwForce = 1000;
    [SerializeField] AudioClip throwSound;

    public static PlayerManager Instance { get; private set; }
    public static AudioSource PlayerAudioSource { get; private set; }

    public const string THROW_STATE = "Throw";
    public Animator animator;

    private bool isThrowing;
    private List<GameObject> rocksOnFloor = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
            Instance = this;

        animator = GetComponent<Animator>();
        PlayerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowRock()
    {
        isThrowing = true;
        animator.Play(THROW_STATE);
    }

    public void SpawnRock()
    {
        PlayerAudioSource.PlayOneShot(throwSound);
        var rock = Instantiate(rockPrefab);
        rock.transform.position = GameObject.Find("StoneSpawnPos").transform.position;
        rocksOnFloor.Add(rock);
        rock.GetComponent<Rigidbody>().AddRelativeForce(Camera.main.transform.forward * throwForce);
    }

    public void DisallowThrowingRock()
    {
        fakeHandRock.SetActive(false);
    }

    public void AllowThrowingRock()
    {
        fakeHandRock.SetActive(true);
    }

    public void FinishedThrow()
    {
        isThrowing = false;
    }

    public bool CanThrowRock()
    {
        return fakeHandRock != null && fakeHandRock.activeSelf && !isThrowing;
    }

    public void CleanRocks()
    {
        foreach (GameObject r in rocksOnFloor)
        {
            Destroy(r);
        }
    }
}
