using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary>
/// Script Controls the info and how it handles
/// </summary> 
public class IntroCtrl : MonoBehaviour
{
    public static IntroCtrl instance;
    private float bootUpTimer;
    private bool bootUpComplete;
    private int textController = 4;
    public GameObject WelcomeText;
    public GameObject StoryText1;
    public GameObject StoryText2;
    public GameObject StoryText3;
    public GameObject StoryText4;
    public GameObject NextButton;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            bootUpTimer = 5;
            startUp();
            bootUpComplete = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bootUpTimer >0)
        {
            UpdateTimer();
        }else if(bootUpTimer < 0 && !bootUpComplete)
        {
            WelcomeText.SetActive(false);
            bootUpComplete = true;
            StoryText1.SetActive(true);
            NextButton.SetActive(true);
        }
        
    }
    void UpdateTimer()
    {
        bootUpTimer -= Time.deltaTime;
    }

    public void StoryTeller()
    {
        switch (textController)
        {
            case 4:
                StoryText1.SetActive(false);
                StoryText2.SetActive(true);
                break;
            case 3 :
                StoryText2.SetActive(false);
                StoryText3.SetActive(true);
                break;
            case 2:
                StoryText3.SetActive(false);
                StoryText2.SetActive(true);
                break;
            case 1:
                SceneManager.LoadScene(4);
                break;
            default:
                break;
        }
        textController--;
    }

    void startUp()
    {
        WelcomeText.SetActive(true);
        StoryText1.SetActive(false);
        StoryText2.SetActive(false);
        StoryText3.SetActive(false);
        StoryText4.SetActive(false);
        NextButton.SetActive(false);
    }
}
