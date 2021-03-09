using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used to Control the dialogue for in game stories
/// basic understanding is from https://www.youtube.com/watch?v=p_d2ugJ3FRg. 
/// </summary>
public class DialougeManager : MonoBehaviour
{
    public GameObject SoliderSpeechBubble;
    public GameObject Nextbutton;
    public GameObject LeaveLvl;
    public GameObject StayInLvl;
    public Button nextButton;
    public Button btnLeaveLvl;
    public Button btnStayInLvl;
    public Text soliderMessage;
    private Text playerMessage;
    private float Timer;
    private List<string> startingMessage;
    private int listIterator; 

    void Awake()
    {
        Timer = 0;
        listIterator = 0;
        startingMessage = new List<string>();
        switch (OverAllGameInfo.CurrentLevel)
        {
            case 0:
                startingMessage.Add("Whatch Out there are Zombies in the Zone. Let me know when your Ready to get out of here!");
                break;
            case 1:
                startingMessage.Add("Whatch Out there new Zombies in the Zone.");
                startingMessage.Add("Some Of the Zombies in this zone will jump at you, they are refered to as mimics");
                startingMessage.Add("they are refered to as mimics");
                startingMessage.Add("Let me know when your Ready to get out of here!");
                break;
            case 2:
                startingMessage.Add("Whatch Out there new Zombies in the Zone.");
                startingMessage.Add("Some Of the Zombies in this zone are faster and will jump in your direction!");
                startingMessage.Add("they are refered to as the infectors");
                startingMessage.Add("This should be the last of them. Report to me when your done");
                break;
            default:
                break;

        }
        soliderMessage.text = startingMessage[listIterator];
        SoliderSpeechBubble.gameObject.SetActive(true);
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 15f)
        {
            SoliderSpeechBubble.SetActive(false);
        }

    }
    public void NextDialouge()
    {
        if (listIterator < startingMessage.Count-1)
        {
            listIterator++;
            soliderMessage.text = startingMessage[listIterator];
        }
        else
        {
            SoliderSpeechBubble.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Timer = 0;
        listIterator = 0;
        startingMessage = new List<string>();
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (OverAllGameInfo.CurrentLevel != 2)
                {
                    Nextbutton.SetActive(false);
                    SoliderSpeechBubble.SetActive(true);
                    startingMessage.Add( "Are you Ready to Leave");
                    LeaveLvl.SetActive(true);
                    StayInLvl.SetActive(true);
                    Timer = 0;
                }
                else if(OverAllGameInfo.numberOfInfectorsLvl3 != 0)
                {
                    SoliderSpeechBubble.SetActive(true);
                    startingMessage.Add("You havn't Killed All the infectors.");
                    startingMessage.Add("Return when you have!");
                }
                else
                {
                    Nextbutton.SetActive(false);
                    SoliderSpeechBubble.SetActive(true);
                    startingMessage.Add("Well Done! We will tak....");
                    LeaveLvl.SetActive(true);
                    StayInLvl.SetActive(true);
                }
                break;
            default:
                break;
        }
        soliderMessage.text = startingMessage[listIterator];
    }

    public void StayInLevel()
    {
        SoliderSpeechBubble.SetActive(false);
    }

    public void leaveLevel()
    {
        GameCtrl.instance.LevelComplete();
    }

}
