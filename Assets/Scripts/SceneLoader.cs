using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Loads a specific scene matching the string used in the inspector. The scene may be selected depending on the button of the canvas
    // to which this is attached.
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Closes the game when called.
    public void QuitGame()
    {
        Application.Quit();
    }
}
