using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {

    //carico menu principale di selezione/comandi in corrispondenza del click sul pulsante New Game

	public void onClick()
    {
        StartGame.currentLevel = "MainMenu";
        UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
    }
}
