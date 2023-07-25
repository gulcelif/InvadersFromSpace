using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public int scoreValue;

    private const float Max_Left = -5;
    private float speed = 5;
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (transform.position.x <= Max_Left)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            UIManager.UpdateScore(scoreValue);
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
