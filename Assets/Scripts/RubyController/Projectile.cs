using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController e = other.transform.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
            Destroy(gameObject);
        }
        else
        {
            Invoke("hide", 5);
        }
    }
    private void hide()
    {
        Destroy(gameObject);

    }
}