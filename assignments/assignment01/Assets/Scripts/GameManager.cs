using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _haveEatenText;
    [SerializeField] private TMP_Text _currentHealthText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _haveEatenText.text = PelletsController.GetHaveEaten().ToString();
        _currentHealthText.text = PlayerCollisionController.GetcurrentHealth().ToString();

        if (PelletsController.GetHaveEaten() >= 358)
        {

            Win();
        }

        if (PlayerCollisionController.GetIsGameOver())
        {
            GameOver();
        }
    }
    private void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        return;
    }

    private void GameOver()
    {
        if (PlayerCollisionController.GetIsGameOver())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            
        }
    }
}