using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Gun
{
    //need to add radius of damage
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }
}
