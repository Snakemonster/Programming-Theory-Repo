using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleGun : Gun
{
    //TODO: Need to fix spamming bullets when still clicking LMB after start reloading gun
    private void Update()
    {
        if (Input.GetMouseButton(0) && Ammo > 0) Shoot();
        if (Input.GetKeyDown(KeyCode.R) || Ammo == 0) Reload();
    }
}
