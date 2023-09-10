using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPiggy : Piggy
{


    public override void Launch(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * forceMultiplicator, ForceMode2D.Force);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
