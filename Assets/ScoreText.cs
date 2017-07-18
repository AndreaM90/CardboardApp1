using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    //importiamo il valore del contatore dello script AutoMove relativamente alle monete raccolte e lo convertiamo a String in modo tale da poterlo mostrare nella schermata di fine livello

    private int cc = AutoMove.coinCount;
    public Text scoreUIText;
    private string ccs;

    void Start()
    {
        ccs = cc.ToString();
        scoreUIText.text = ccs;
    }
}
