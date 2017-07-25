using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    //script legato ad un oggetto vuoto del menu principale
    //permette di definire le variabili globali che verranno manipolate ed utilizzate durante il gioco

    public static string currentLevel; //livello corrente del giocatore
    public static string ambEye; //riferimento all'occhio non ambliope, ovvero quello che verrà penalizzato
	
    //all'inizio del gioco ogni contatore è posto a zero e viene fissata la direzione orizzontale dello schermo

	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        currentLevel = "WolfMain";
        AutoMove.coinCount = 0;
        AutoMove.coinPlayer = 0;
	}
}
