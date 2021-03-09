using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void SelectLevel()
    {
        switch (OverAllGameInfo.CurrentLevel)
        {
            case 1:
                SceneManager.LoadScene(5);
                break;
            case 2:
                SceneManager.LoadScene(6);
                break;
            default:
                break;

        }
    }
}
