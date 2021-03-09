using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public GameObject selectLevelPanel;
    private bool isActive = false;
    // Start is called before the first frame update
    public void SelectLevelPanel()
    {
        selectLevelPanel.SetActive(!isActive);
        isActive = !isActive;
    }
    public void LoadScene(int SceneID)
    {
        switch (SceneID)
        {
            case 1:
                OverAllGameInfo.CurrentLevel = 0;
                break;
            case 5:
                OverAllGameInfo.CurrentLevel = 1;
                break;
            case 6:
                OverAllGameInfo.CurrentLevel = 2;
                break;
            default:
                break;

        }
        SceneManager.LoadScene(SceneID);
    }
}
