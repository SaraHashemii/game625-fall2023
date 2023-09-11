using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{

    protected Animator anim;
    protected bool isMoving;
    protected bool isGoingRight;
    protected bool isGoingLeft;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void Idle()
    {

    }

    protected void Walk()
    {

    }

    protected void TurnRight()
    {

    }

    protected void TrunLeft()
    {

    }
}
