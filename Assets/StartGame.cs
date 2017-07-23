using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public static string currentLevel;
    public static string ambEye;
	
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        currentLevel = "WolfMain";
        AutoMove.coinCount = 0;
        AutoMove.coinPlayer = 0;
	}
}
