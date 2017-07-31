using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainController : MonoBehaviour {

    public Button b_left;
    public Button b_right;
    public Button b_play;
	
	// richiamo tutti i pulsanti disponibili nel main menu per il supporto del joystick
	void Update () {

        var pointer = new PointerEventData(EventSystem.current);

        if (Input.GetButton("ControllerLH"))
        {
            ExecuteEvents.Execute(b_left.gameObject, pointer, ExecuteEvents.submitHandler);
        }

        if (Input.GetButton("ControllerRB"))
        {
            ExecuteEvents.Execute(b_right.gameObject, pointer, ExecuteEvents.submitHandler);
        }

        if (Input.GetButton("VerticalController"))
        {
            if(StartGame.ambEye != null) //NB: tale condizione è necessaria per evitare che il giocatore prema play (possibile) prima di aver selezionato l'occhio non ambliope
            {
                ExecuteEvents.Execute(b_play.gameObject, pointer, ExecuteEvents.submitHandler);
            }
        }

    }

}
