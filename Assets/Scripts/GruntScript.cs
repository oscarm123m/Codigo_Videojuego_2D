using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{   
    public GameObject John;
    public GameObject BulletPrefab;

    private int Health = 3;
    private float LastShoot;

    private void Update()
    {
        
        if (John == null) return;

        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}
