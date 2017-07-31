using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBLeft : MonoBehaviour {

    //tale script setta la variabile ambEye che tiene traccia dell'occhio non ambliope per penalizzarlo in seguito
    //in corrispondenza del click sul pulsante, è selezionato l'occhio sinistro per la penalizzazione
    //le due camere vengono poi traslate alla schermata dei comandi: si distrugge il canvas principale e si attacca alle camere il canvas dei controlli
    //NB: ciò è reso necessario per evitare di creare una nuova scena e quindi interrompere la traccia musicale

    private Camera g1;
    private Camera g2;

    private Canvas c1;
    private Canvas c2;


    public void onClick()
    {
        StartGame.ambEye = "sx";
        g1 = GameObject.Find("Main Camera G1").GetComponent<Camera>();
        g2 = GameObject.Find("Main Camera G2").GetComponent<Camera>();

        g1.transform.position = new Vector3(25, 0, -10);
        g2.transform.position = new Vector3(25, 0, -10);

        Destroy(GameObject.Find("Canvas G1"));
        Destroy(GameObject.Find("Canvas G2"));

        c1 = GameObject.Find("Canvas Controls G1").GetComponent<Canvas>();
        c2 = GameObject.Find("Canvas Controls G2").GetComponent<Canvas>();

        c1.renderMode = RenderMode.ScreenSpaceCamera;
        c1.worldCamera = g1;

        c2.renderMode = RenderMode.ScreenSpaceCamera;
        c2.worldCamera = g2;
    }
}
