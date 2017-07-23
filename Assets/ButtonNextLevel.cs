using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextLevel : MonoBehaviour {


	public void onClick()
    {
        AutoMove.coinCount = 0;

        if (StartGame.currentLevel == "WolfMain")
        {
            StartGame.currentLevel = "WolfLevel2";
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
        }

        else if(StartGame.currentLevel == "WolfLevel2"){

            StartGame.currentLevel = "WolfLevel3";
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
        }
    }
}
