using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PelletsController : MonoBehaviour
{
    private static int _haveEaten = 0;
    public static int GetHaveEaten() { return _haveEaten; }
    public static void SetHaveEaten(int value) { _haveEaten = value; }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _haveEaten++;
            Destroy(gameObject);
        }
    }
}
