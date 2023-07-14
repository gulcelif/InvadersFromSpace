using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private const float maxX = 2.5f;
    private const float minX = -2.6f;

    //private float speed = 3f;
    private bool isShooting;
    //private float cooldown = 0.5f;
    [SerializeField] private ObjectPool objectPool = null;

    public ShipStats shipStats;
    private Vector2 offscreenPos = new Vector2(0, -20f);
    private Vector2 startPos = new Vector2(0, -4.5f);

    void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLifes = shipStats.maxLifes;
        transform.position = startPos;
    }


    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            transform.Translate(shipStats.shipSpeed * Time.deltaTime * Vector2.left);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());
        }


#endif
    }
    private IEnumerator Shoot()
    {
        isShooting = true;
        GameObject obj = objectPool.GetPooledObjects();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(shipStats.fireRate);

        isShooting = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("player hit.");
            collision.gameObject.SetActive(false);
            TakeDamage();
        }
    }

    private IEnumerator Respawn()
    {
        transform.position = offscreenPos;
        yield return new WaitForSeconds(2);
        shipStats.currentHealth = shipStats.maxHealth;
        transform.position = startPos;
    }

    private void TakeDamage()
    {
        shipStats.currentHealth--;

        if (shipStats.currentHealth <= 0)
        {
            shipStats.currentLifes--;

            if (shipStats.currentLifes <= 0)
            {
                Debug.Log("Game Over");
            }
            else
            {
                //Debug.Log("Respawn");
                StartCoroutine(Respawn());
            }
        }

    }
}
