using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private GunConditions _currentGunConditions;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private int _maxAmmo;
    public int Ammo { get; private set; }
    public float TimeReload;
    public float TimeBetweenShoots;
    
    protected void Shoot()
    {
        if (_currentGunConditions == GunConditions.Reloading) return;
        StartCoroutine(Ammo > 0 ? Shooting() : FullReload());
    }

    protected void Reload()
    {
        if (Ammo == _maxAmmo) return;
        StartCoroutine(FullReload());
    }
    
    private IEnumerator Shooting()
    {
        _currentGunConditions = GunConditions.Reloading;
        yield return Instantiate(_bullet, _bullet.transform.position, _bullet.transform.rotation);
        yield return new WaitForSeconds(TimeBetweenShoots);
        Ammo--;
        _currentGunConditions = GunConditions.Shoot;
    }

    private IEnumerator FullReload()
    {
        _currentGunConditions = GunConditions.Reloading;
        yield return new WaitForSeconds(TimeReload);
        Ammo = _maxAmmo;
        _currentGunConditions = GunConditions.Shoot;
    }

    protected void ReloadAmmo()
    {
        Ammo = _maxAmmo;
    }
    
    protected virtual void Start()
    {
        ReloadAmmo();
    }

}