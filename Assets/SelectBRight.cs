using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBRight : MonoBehaviour {


	public void onClick()
    {
        StartGame.ambEye = "dx";
        UnityEngine.SceneManagement.SceneManager.LoadScene("WolfMain");
    }
}
