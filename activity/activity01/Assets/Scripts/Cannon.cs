using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Piggy[] piggies;

    // Start is called before the first frame update
    void Start()
    {

    }

    int whichPiggy = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseInWorldSpace = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -(Camera.main.transform.position.z)));
        //direction from the cannon to mouse position
        Vector3 direction = mouseInWorldSpace - transform.position;



        float angle = Mathf.Acos(Vector3.Dot(Vector3.right, direction.normalized)) * Mathf.Rad2Deg;


        if (angle <= 80 && angle >= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (Input.GetMouseButtonUp(0))
        {
            piggies[whichPiggy % piggies.Length].Launch(direction);
            whichPiggy++;
        }

    }
}
