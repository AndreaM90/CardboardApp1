using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextLevel : MonoBehaviour {

    //quando si preme bottone, viene caricato il livello successivo a quello completato e si salvano i daticon il metodo sottostante


	public void onClick()
    {
        AutoMove.coinCount = 0;

        if (StartGame.currentLevel == "WolfMain")
        {
            StartGame.currentLevel = "WolfLevel1";
            saveScores();
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
        }

        else if(StartGame.currentLevel == "WolfLevel1"){

            StartGame.currentLevel = "WolfLevel2";
            saveScores();
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
        }

        else if (StartGame.currentLevel == "WolfLevel2")
        {

            StartGame.currentLevel = "WolfLevel3";
            saveScores();
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
        }

        else if (StartGame.currentLevel == "WolfLevel3")
        {

            StartGame.currentLevel = "WolfLevel4";
            saveScores();
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
        }

        else if (StartGame.currentLevel == "WolfLevel4")
        {

            StartGame.currentLevel = "WolfLevel5";
            saveScores();
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
        }

        else if (StartGame.currentLevel == "WolfLevel5")
        {

            StartGame.currentLevel = "WolfLevel6";
            saveScores();
            UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
        }
    }

    //salvo monete totali giocatore, occhio non ambliope, livello corrente

    public void saveScores()
    {
        PlayerPrefs.SetInt("TotalCoins", AutoMove.coinPlayer);
        PlayerPrefs.SetString("Eye", StartGame.ambEye);
        PlayerPrefs.SetString("Level", StartGame.currentLevel);
    }
}
