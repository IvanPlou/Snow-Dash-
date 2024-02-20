using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLinveLvl2 : FinishLineLvl1
{
    //Inherited from FinishLineLvl1, does the same but calls the Scene 0 on the build instead.
    override protected void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
