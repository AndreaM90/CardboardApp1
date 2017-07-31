using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartMain : MonoBehaviour {

    //Per favorire l'interazione con il joystick, ho settato nell'input manager tre pulsanti, ControllerLH, ControllerRB e VerticalController, rispettivamente riferiti ai tasti X,B,A del
    //trust controller

    //richiamando un pointer e sfruttando la classe EventSystems fornita dagli assets di Unity posso richiamare remotamente i click sui pulsanti senza dover ricorrere al touch/mouse

    public Button bnew_left;
    public Button bload_right;

	
	void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void Update()
    {
        var pointer = new PointerEventData(EventSystem.current);

        if (Input.GetButton("ControllerLH"))
        {
            ExecuteEvents.Execute(bnew_left.gameObject, pointer, ExecuteEvents.submitHandler);
        }

        if (Input.GetButton("ControllerRB"))
        {
            ExecuteEvents.Execute(bload_right.gameObject, pointer, ExecuteEvents.submitHandler);
        }
    }
}
