using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private int _maxAmmo;
    [SerializeField] private GunConditions _currentGunConditions;
    [SerializeField] protected GunMode _currentGunMode;
    public int Ammo;
    public float TimeReload;
    public float TimeBetweenShoots;
    public GameObject _Bullet;


    protected void Shoot()
    {
        if (_currentGunConditions == GunConditions.Reloading) return;
        StartCoroutine(Ammo > 0 ? Shooting() : ReloadAmmo());
    }

    protected void Reload()
    {
        if (Ammo == _maxAmmo) return;
        StartCoroutine(ReloadAmmo());
    }
    
    private IEnumerator Shooting()
    {
        _currentGunConditions = GunConditions.Reloading;
        yield return Instantiate(_Bullet, _Bullet.transform.position, _Bullet.transform.rotation);
        yield return new WaitForSeconds(TimeBetweenShoots);
        Ammo--;
        _currentGunConditions = GunConditions.Shoot;
    }

    private IEnumerator ReloadAmmo()
    {
        _currentGunConditions = GunConditions.Reloading;
        yield return new WaitForSeconds(TimeReload);
        _currentGunConditions = GunConditions.Shoot;
        Ammo = _maxAmmo;
    }
    
}