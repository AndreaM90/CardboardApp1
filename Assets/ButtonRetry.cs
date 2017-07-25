using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRetry : MonoBehaviour {

    //nella schermata di sconfitta, una volta premuto il pulsante si ricarica l'ultimo livello giocato (e non  vinto)


	public void onClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
    }
}
