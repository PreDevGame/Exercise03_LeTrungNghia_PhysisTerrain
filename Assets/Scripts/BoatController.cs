using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float boatSpeed = 10f;

    public float buttonController;
    public GameObject theBoat;

    void Update()
    {
       if (buttonController == Input.GetAxis("Horizontal"))
        {
            theBoat.transform.position = Vector3.up * buttonController * boatSpeed * Time.deltaTime;
        }
    }
}
