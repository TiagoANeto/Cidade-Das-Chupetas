using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityBackground : MonoBehaviour
{
    public Material material;
    public float bgSpeed;

    void Update()
    {
        material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0);
    }

}
