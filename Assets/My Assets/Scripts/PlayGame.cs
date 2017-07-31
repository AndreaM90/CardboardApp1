using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour {

    //carico livello 1 alla prima invocazione dell'applicazione o a New Game

    public void onClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WolfMain");
    }
}
