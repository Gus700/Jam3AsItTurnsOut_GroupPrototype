using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform launchOffSet;
    [SerializeField] private Rigidbody2D bullet;
    [SerializeField] private float heavyShotShootForce = 1f;
    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        // vector that gives the position of the mouse cursor
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D bulletInstance = Instantiate(bullet, launchOffSet.position, weapon.rotation);
            Vector2 lookDirect = mousePos - (Vector2)weapon.position;
            bulletInstance.velocity = new Vector2(lookDirect.x * heavyShotShootForce, lookDirect.y *heavyShotShootForce);
        }
    }

    void FixedUpdate() 
    {
        // get the vector pointing between the cannon sprute and mouse
        Vector2 lookDir = mousePos - (Vector2)weapon.position;
        weapon.transform.right = lookDir; // moves angle of sprite toward the mouse
    }

}
