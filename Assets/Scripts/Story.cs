using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Story")]
public class Story : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string storyText;

    public string GetStory()
    {
        return storyText;
    }
}
