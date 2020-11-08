using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ListOfObjects : MonoBehaviour
{
    GameObject MonsterObj;
    [SerializeField] GameObject[] ObjectsList;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public GameObject[] GetGameObjects(){
        return ObjectsList;
    }

    
    public void DisableAll(){
        //hide all the selected game objects that monster can possess.
        foreach (var item in ObjectsList)
        {
            item.SetActive(false);
        }
    }

    public void RandomAndSet(){
        //Random select an collective game object and set it visible.
        System.Random rnd = new System.Random();
        if(ObjectsList!=null){
            int pos = rnd.Next(ObjectsList.Length);
            
            //Loop until the new random monster is selected
            while(Array.IndexOf(ObjectsList,MonsterObj) == pos){
                pos = rnd.Next(ObjectsList.Length);
            }

            if(MonsterObj!=null){ //If there is a monster obj already exist
                    MonsterObj.SetActive(false);  //Disable the previous monster obj
            }
            MonsterObj = ObjectsList[pos];
            if(MonsterObj !=null){
            MonsterObj.SetActive(true);  //Enable the next monster obj
            }
        }
    }
}
