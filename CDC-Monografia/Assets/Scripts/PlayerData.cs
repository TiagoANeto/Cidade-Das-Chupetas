using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Gravity")]
    public float gravityStrength;
    public float gravityScale;
    public float fallGravityMult;

    [Space(20)]

    [Header("Jump")]

    public float jumpHeigth;
    public float jumpTime;
    public float jumpForce;

    private void OnChecks()
    {
        gravityStrength = -(2 * jumpHeigth) / (jumpTime * jumpTime);
        gravityScale = gravityStrength / Physics2D.gravity.y;
        jumpForce = Mathf.Abs(gravityStrength) * jumpTime;
    }

}
