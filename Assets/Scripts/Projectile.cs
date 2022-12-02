using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Player_Manager pm;

    private void Start()
    {
        pm = transform.parent.GetComponent<Player_Manager>();
    }

    private void Update()
    {
        Vector3 position = transform.position;
        if (position.y < -25)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Unit") &&
            collider.transform.parent != transform.parent
        )
        {
            pm.score += 10;
            Destroy(gameObject);
        }
        if (!collider.gameObject.CompareTag(gameObject.tag))
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        
    }
}
