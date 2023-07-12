using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector3 hMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.15f, 0);

    private const float maxLeft = -2.55f;
    private const float maxRight = 2.55f;

    public static List<GameObject> allAliens = new List<GameObject>();

    private bool movingRight;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;
    private float ShootTimer = 3f;
    private const float shotTime = 3f;

    private const float max_move_speed = 0.02f;
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(go);
        }
    }
    void Update()
    {
        if (moveTimer <= 0)
        {
            MoveEnemies();
        }
        if (ShootTimer <= 0)
        {
            Shoot();
        }
        moveTimer -= Time.deltaTime;
        ShootTimer -= Time.deltaTime;


    }
    private void MoveEnemies()
    {
        int hitMax = 0;
        if (allAliens.Count > 0)
        {
            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                {
                    allAliens[i].transform.position += hMoveDistance;
                }
                else
                {
                    allAliens[i].transform.position -= hMoveDistance;
                }
                if (allAliens[i].transform.position.x > maxRight || allAliens[i].transform.position.x < maxLeft)
                {
                    hitMax++;
                }
            }
            if (hitMax > 0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                {
                    allAliens[i].transform.position -= vMoveDistance;

                }
                movingRight = !movingRight;
            }
            moveTimer = GetMoveSpeed();
        }
    }
    private void Shoot()
    {
        Vector2 pos = allAliens[Random.Range(0, allAliens.Count)].transform.position;
        Instantiate(bulletPrefab, pos, Quaternion.identity);
        ShootTimer = shotTime;
    }
    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;
        if (f < max_move_speed)
        {
            return max_move_speed;
        }
        else
        {
            return f;
        }
    }

}
