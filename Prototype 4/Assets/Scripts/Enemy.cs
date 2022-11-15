using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody EnemyRb;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookVector = (player.transform.position - transform.position).normalized;
        EnemyRb.AddForce(lookVector * speed * Time.deltaTime);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
