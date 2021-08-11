using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour //INHERITANCE - parent
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) Destroy(gameObject);
    }

    protected void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
