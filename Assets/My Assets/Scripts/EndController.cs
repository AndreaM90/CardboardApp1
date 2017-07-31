using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndController : MonoBehaviour {

    //gestisco interazione tra pulsanti del joystick e pulsanti in-game nella schermata finale

    public Button b_got;
    public Button b_main;
	
	
	void Update () {

        var pointer = new PointerEventData(EventSystem.current);

        if (Input.GetButton("VerticalController"))
        {
            ExecuteEvents.Execute(b_got.gameObject, pointer, ExecuteEvents.submitHandler);
        }

        if (Input.GetButton("ControllerRB"))
        {
            ExecuteEvents.Execute(b_main.gameObject, pointer, ExecuteEvents.submitHandler);
        }

    }
}
