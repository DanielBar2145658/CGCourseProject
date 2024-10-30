using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LUT : MonoBehaviour
{
    public Shader shaderLUT = null;
    public Material renderMaterial;
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, renderMaterial);
    }
}
