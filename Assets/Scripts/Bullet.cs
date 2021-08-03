using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float TimeLive;
    public float Speed;

    protected void LaunchBullet()
    {
        StartCoroutine(TimeLiveBullet());
    }

    private IEnumerator TimeLiveBullet()
    {
        yield return new WaitForSeconds(TimeLive);
        Destroy(gameObject);
    }

    protected void Update()
    {
        transform.Translate(Vector3.forward * Speed /** Time.deltaTime*/);
    }
}
