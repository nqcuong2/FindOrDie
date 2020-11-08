using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfObjects : MonoBehaviour
{

    [SerializeField] GameObject[] ObjectsList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] GetGameObjects(){
        return ObjectsList;
    }
}
