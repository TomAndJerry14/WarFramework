using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancedColor : MonoBehaviour
{
    [SerializeField]
    Color color = Color.white;

    void Awake()
    {
        var propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", color);
        GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
    }

    static MaterialPropertyBlock propertyBlock;
    static int colorID = Shader.PropertyToID("_Color");

    void OnValidate()
    {
        if (propertyBlock == null)
            propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor(colorID, color);
        GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
    }
}
