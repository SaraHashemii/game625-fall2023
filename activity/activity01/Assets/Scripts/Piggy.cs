using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piggy : MonoBehaviour
{
    protected float weight;
    protected float forceMultiplicator = 100;



    public abstract void Launch(Vector3 direction);

}
