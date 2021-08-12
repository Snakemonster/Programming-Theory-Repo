using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Gun
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    protected override void Shoot()
    {
        if (CurrentGunConditions == GunConditions.FullReloading) return;
        StartCoroutine(RocketShoot());
    }

    IEnumerator RocketShoot()
    {
        yield return Instantiate(_bullet, _bulletSpawner.transform.position, _bulletSpawner.transform.rotation);
        Ammo--;
        Reload();
    }
}
