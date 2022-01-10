using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour //INHERITANCE - parent
{
    [SerializeField] protected Transform _bulletSpawner;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] private int _maxAmmo;
    public GunConditions CurrentGunConditions { get; private set; } //ENCAPSULATION
    public int Ammo { get; protected set; } //ENCAPSULATION
    public float TimeReload;
    public float TimeBetweenShoots;
    
    protected virtual void Shoot()
    {
        if (CurrentGunConditions is GunConditions.FullReloading or GunConditions.ReloadingBetweenShoots) return;
        StartCoroutine(Ammo > 0 ? Shooting() : FullReload());
    }

    public void Reload()
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

    protected IEnumerator FullReload()
    {
        CurrentGunConditions = GunConditions.FullReloading;
        yield return new WaitForSeconds(TimeReload);
        Ammo = _maxAmmo;
        CurrentGunConditions = GunConditions.Shoot;
    }

    private void ReloadAmmo()
    {
        Ammo = _maxAmmo;
    }
    
    protected void Start()
    {
        ReloadAmmo();
    }

}