using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LostController : MonoBehaviour {

    // interazione joystick-pulsanti per le scene di vittoria e sconfitta

    public Button b_retry;
	
	void Update () {

        var pointer = new PointerEventData(EventSystem.current);

        if (Input.GetButton("VerticalController"))
        {
            ExecuteEvents.Execute(b_retry.gameObject, pointer, ExecuteEvents.submitHandler);
        }

    }
}
