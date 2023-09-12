using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    [Header("Health")]
    [SerializeField] private int maxHealth = 1;
    [SerializeField] private int currentHealth;

    private void Awake()
    {
        GetRefrences();
        currentHealth = maxHealth;
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


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Enemy caught the player, reduce health
            currentHealth--;
            Debug.Log(currentHealth);

            if (currentHealth <= 0)
            {
                // Player is defeated, remove the player
                RemovePlayer();
            }
        }
    }

    private void RemovePlayer()
    {
        // Handle player removal logic here (e.g., play death animation, show game over screen, etc.)

        // For this example, we'll simply reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



