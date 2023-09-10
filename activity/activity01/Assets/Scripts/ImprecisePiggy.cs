using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprecisePiggy : Piggy
{
    [SerializeField] float minError = -2;
    [SerializeField] float maxError = 2;


    public override void Launch(Vector3 direction)
    {
        Vector3 directionWithRandomness = direction + new Vector3(Random.Range(minError, maxError), 0, 0);

        GetComponent<Rigidbody2D>().AddForce(directionWithRandomness * forceMultiplicator, ForceMode2D.Force);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        transform.parent = null;
    }
}
