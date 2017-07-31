using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextTotal : MonoBehaviour {

    private int cc = AutoMove.coinPlayer;
    public Text scoreUITextTotal;
    private string ccs;

    void Start()
    {
        ccs = cc.ToString();
        scoreUITextTotal.text = ccs;
    }
}
