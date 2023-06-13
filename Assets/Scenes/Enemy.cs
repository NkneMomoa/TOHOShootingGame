using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;

    public GameObject exploPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * moveSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<UIManeger>().Takedamage();
            TakeDamage();
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            FindObjectOfType<UIManeger>().Takedamage();
            Destroy(gameObject);
        }
    }

    void TakeDamage()
    {
        GameObject Explo = Instantiate(exploPrefab, transform.position, Quaternion.identity);
        FindObjectOfType<UIManeger>().GetScore(500);
        Destroy(Explo,0.333f);
        Destroy(gameObject);
    }
}
