using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRetry : MonoBehaviour {


	public void onClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(StartGame.currentLevel);
    }
}
