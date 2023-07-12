using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private const float maxX = 2.5f;
    private const float minX = -2.6f;

    private float speed = 3f;
    private bool isShooting;
    private float cooldown = 0.5f;
    [SerializeField] private ObjectPool objectPool = null;
    void Start()
    {

    }


    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            transform.Translate(speed * Time.deltaTime * Vector2.left);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
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
        yield return new WaitForSeconds(cooldown);

        isShooting = false;
    }
}
