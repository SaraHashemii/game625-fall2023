using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController playerController;

    [Header("Movement Variables")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotationSpeed = 120;

    private Vector3 _movement;


    [Header("Animations")]
    private Animator _anim;
    private bool _isWalking;

    private void Awake()
    {
        GetRefrences();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();


    }

    private void GetRefrences()
    {
        playerController = GetComponent<CharacterController>();
        _anim = GetComponent<Animator>();
    }

    private void Movement()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionZ = Input.GetAxisRaw("Vertical");
        Vector3 _movement = new Vector3(directionX, 0, directionZ);
        _movement.Normalize();

        if (_movement == Vector3.zero)
        {
            _anim.SetBool("_isWalking", false);
        }
        else
        {
            _anim.SetBool("_isWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(_movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }

        playerController.Move(_movement * _speed * Time.deltaTime);
        //Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed );



    }
}


