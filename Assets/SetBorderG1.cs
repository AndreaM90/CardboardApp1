using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Camera))]
public class SetBorderG1 : MonoBehaviour {

    public Transform puitBorder;
    private Camera gscCam; // 2nd Camera

    //==================================================
    // Use this for initialization
    void Awake()
    {
        gscCam = gameObject.GetComponent<Camera>();
        gameObject.SetActive(false);
    }

    //==================================================
    //
    void OnEnable()
    {
        vSetActive(true);
    }

    //==================================================
    //
    void OnDisable()
    {
        vSetActive(false);
    }

    //=================================================
    // 
    void vSetBorder()
    {
        // Screen
        Rect rCam2 = gscCam.rect;
        rCam2.width *= Screen.width;
        rCam2.height *= Screen.height;
        rCam2.x *= Screen.width;
        rCam2.y *= Screen.height;
        //Debug.Log( ">> " + rCam2 );
        //
        Image uiimBorder = puitBorder.GetComponent<Image>();
        if (uiimBorder != null)
        {
            uiimBorder.rectTransform.sizeDelta = new Vector2(rCam2.width, rCam2.height);
            uiimBorder.rectTransform.position = new Vector2(rCam2.x + uiimBorder.rectTransform.sizeDelta.x / 2, rCam2.y + uiimBorder.rectTransform.sizeDelta.y / 2);
        }
    }

    //====================================================
    //
    public void vSetActive(bool b_Active)
    {
    
        gscCam.enabled = b_Active;
        puitBorder.gameObject.SetActive(b_Active);
        if (b_Active)
        {
            vSetBorder();
        }
    }
}
