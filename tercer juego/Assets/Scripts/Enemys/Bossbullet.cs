using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossbullet : MonoBehaviour
{
    [Header("Velocidad y tiempo de destrucción")]
    public float velocidad;
    public float timeDestroy;
    public int damage = 10;

    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    void Update()
    {
        transform.position -= transform.up * Time.deltaTime * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }


    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject);
    }
}
