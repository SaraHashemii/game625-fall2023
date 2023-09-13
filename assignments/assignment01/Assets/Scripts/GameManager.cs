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
        _haveEatenText.text = "Points " + PelletsController.GetHaveEaten().ToString() + " /358";
        _currentHealthText.text = "Health " + PlayerCollisionController.GetcurrentHealth().ToString() + " /3";

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