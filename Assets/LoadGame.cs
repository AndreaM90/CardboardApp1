using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour {

    //tale script permette di caricare i dati salvati: le monete totali raccolte dal giocatore, il livello corrente e l'occhio non ambliope da penalizzare
    //viene caricato il livello corrente, ovvero l'ultimo giocato e non completato dal giocatore

	public void onClick()
    {
        AutoMove.coinCount = 0;
        AutoMove.coinPlayer = PlayerPrefs.GetInt("TotalCoins");
        StartGame.ambEye = PlayerPrefs.GetString("Eye");
        StartGame.currentLevel = PlayerPrefs.GetString("Level");

        UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
    }
}
