using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewEffect : MonoBehaviour
{
    //carichiamo un'immagine che riproduca la vista del visore cardboard, in quanto non è possibile utilizzare i package/assets di google impostando due camere da rendere separatamente

    public Texture2D textureImage;

    void OnGUI() { GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textureImage); }

}