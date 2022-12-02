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
    [SerializeField] private AudioSource shootingSfx;
    private Vector2 mousePos;

    public Unit_Manager um;
    public int mouseButton;

    private void Start()
    {
        um = GetComponentInParent<Unit_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (um.itsTurn)
        {
            // vector that gives the position of the mouse cursor
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(mouseButton))
            {
                shootingSfx.Play();
                // creat an instance of the bullet 
                Rigidbody2D bulletInstance = Instantiate(bullet, launchOffSet.position, weapon.rotation);
                Vector2 lookDirect = mousePos - (Vector2)weapon.position;
                // add the directional position of the mouse cursor to the velocity of the buller rb
                bulletInstance.velocity = new Vector2(lookDirect.x * heavyShotShootForce, lookDirect.y * heavyShotShootForce);
                
                um.IncIndex();
            }
        }
    }

    void FixedUpdate() 
    {
        // get the vector pointing between the cannon sprute and mouse
        Vector2 lookDir = mousePos - (Vector2)weapon.position;
        weapon.transform.right = lookDir; // moves angle of sprite toward the mouse
    }

}
