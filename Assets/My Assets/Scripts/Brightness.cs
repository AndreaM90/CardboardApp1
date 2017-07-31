using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brightness : MonoBehaviour
{

    //Brightness per la camera 1

    public Shader shaderDerp;
    Material m_Material;

    [Range(0f, 2f)]
    public float brightness = 1f;

    public float pen_bright;


    Material material
    {
        get
        {
            if (m_Material == null)
            {
                m_Material = new Material(shaderDerp);
                m_Material.hideFlags = HideFlags.HideAndDontSave;
            }
            return m_Material;
        }
    }


    void OnDisable()
    {
        if (m_Material)
        {
            DestroyImmediate(m_Material);
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (StartGame.ambEye == "sx")
        {
            material.SetFloat("_Brightness", pen_bright);
            Graphics.Blit(source, destination, material);
        }
        else
        {
            material.SetFloat("_Brightness", brightness);
            Graphics.Blit(source, destination, material);
        }
    }
}
