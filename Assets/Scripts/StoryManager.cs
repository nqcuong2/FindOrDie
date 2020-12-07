using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{

    public static StoryManager Instance;

    private bool isDisplaying =false;
    private Coroutine introCoroutine;
    // Start is called before the first frame update
    [SerializeField] Text StoryText;
    [SerializeField] Story Intro;
    [SerializeField] Story Instruct_1;
    [SerializeField] Story Instruct_2;
    [SerializeField] Story Dark_1;
    [SerializeField] Story Dark_2;
    [SerializeField] Story Dark_3;

    [SerializeField] GameObject TimeNRockPanel;
    void Awake()
    {   
        if (!Instance){
            Instance = this;
        }
    }

    private IEnumerator sInstruct_2(){
        isDisplaying = true;
        yield return new WaitForSecondsRealtime(4);

        StartCoroutine(sInstruct_2());
        isDisplaying=false; 
    }

    private IEnumerator sDark_1(){
        isDisplaying = true;
        StoryText.text = "";
        StoryText.text  = Dark_1.GetStory();
        yield return new WaitForSecondsRealtime(4);
        StoryText.text = "";
        isDisplaying=false;
    }

    private IEnumerator sDark_2(){
        isDisplaying = true;
        StoryText.text = "";   
        StoryText.text  = Dark_2.GetStory();
        yield return new WaitForSecondsRealtime(4);
        StoryText.text = "";
        isDisplaying=false;
    }

    private IEnumerator sDark_3(){
        isDisplaying = true;
        StoryText.text = ""; 
        StoryText.text  = Dark_3.GetStory();
        yield return new WaitForSecondsRealtime(4);
        StoryText.text = "";
        isDisplaying=false;
    }


    public void ShowIntro(){
        introCoroutine = StartCoroutine(ShowIntroDiscretely());
    }

    private IEnumerator ShowIntroDiscretely()
    {
        TimeNRockPanel.SetActive(false);

        isDisplaying = true;
        StoryText.text = Intro.GetStory();
        yield return new WaitForSecondsRealtime(7.5f);

        StoryText.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.6f);

        StoryText.gameObject.SetActive(true);
        StoryText.text = Instruct_1.GetStory();
        yield return new WaitForSecondsRealtime(7.5f);

        StoryText.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.6f);

        StoryText.gameObject.SetActive(true);
        StoryText.text = Instruct_2.GetStory();

        yield return new WaitForSecondsRealtime(7.0f);

        ShowGameScreen();
    }

    private void ShowGameScreen()
    {
        gameObject.SetActive(false);
        GameplayManager.Instance.startGame = true;
        TimeNRockPanel.SetActive(true);
    }

    public void SkipIntro()
    {
        StopCoroutine(introCoroutine);
        ShowGameScreen();
    }

    //public void ShowDark_1(){
    //    coroutine = sDark_1();
    //    StartCoroutine(coroutine);
    //}

    //public void ShowDark_2(){
    //    coroutine = sDark_2();
    //    StartCoroutine(coroutine);
    //}

    //public void ShowDark_3(){
    //    coroutine = sDark_3();
    //    StartCoroutine(coroutine);
    //}
}
