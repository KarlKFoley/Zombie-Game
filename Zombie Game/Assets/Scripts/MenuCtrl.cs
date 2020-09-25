using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This class handles moving between all scenes.
/// Code implemtation comes from udemy.com/course/unity-2d-course-build-a-mobile-platformer-game-from-scratch
/// </summary>
public class MenuCtrl : MonoBehaviour
{
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
