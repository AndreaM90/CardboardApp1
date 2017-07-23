using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBLeft : MonoBehaviour {


	public void onClick()
    {
        StartGame.ambEye = "sx";
        UnityEngine.SceneManagement.SceneManager.LoadScene("WolfMain");
    }
}
