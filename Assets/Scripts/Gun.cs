using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour //INHERITANCE - parent
{
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private int _maxAmmo;
    public GunConditions CurrentGunConditions { get; private set; } //ENCAPSULATION
    public int Ammo { get; private set; } //ENCAPSULATION
    public float TimeReload;
    public float TimeBetweenShoots;
    
    protected void Shoot()
    {
        if (CurrentGunConditions == GunConditions.FullReloading || CurrentGunConditions == GunConditions.ReloadingBetweenShoots) return;
        StartCoroutine(Ammo > 0 ? Shooting() : FullReload());
    }

    protected void Reload()
    {
        if (Ammo == _maxAmmo) return;
        StartCoroutine(FullReload());
    }
    
    private IEnumerator Shooting()
    {
        CurrentGunConditions = GunConditions.ReloadingBetweenShoots;
        yield return Instantiate(_bullet, _bulletSpawner.transform.position, _bulletSpawner.transform.rotation);
        yield return new WaitForSeconds(TimeBetweenShoots);
        Ammo--;
        CurrentGunConditions = GunConditions.Shoot;
    }

    private IEnumerator FullReload()
    {
        CurrentGunConditions = GunConditions.FullReloading;
        yield return new WaitForSeconds(TimeReload);
        Ammo = _maxAmmo;
        CurrentGunConditions = GunConditions.Shoot;
    }

    protected void ReloadAmmo()
    {
        Ammo = _maxAmmo;
    }
    
    protected virtual void Start() //POLYMORPHISM
    {
        ReloadAmmo();
    }

}