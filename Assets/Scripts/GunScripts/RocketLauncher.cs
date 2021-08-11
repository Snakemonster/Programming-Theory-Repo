using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Gun
{
    protected override void Start() //POLYMORPHISM
    {
        ReloadAmmo();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }
}
