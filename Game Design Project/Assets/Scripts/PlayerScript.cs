using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    public RuntimeAnimatorController pHandgunController;
    public RuntimeAnimatorController pUnarmedController;
    public RuntimeAnimatorController pPumpController;
    public RuntimeAnimatorController pTommyController;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;
    public Weapon weapon;
    public Transform firePoint;

    Vector2 movement;
    Vector2 mousePosition;


    public void Update()
    {
        moving();

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //switch when player picks up gun
            anim.runtimeAnimatorController = pHandgunController as RuntimeAnimatorController;
        }
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void moving()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(weapon.bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * weapon.bulletForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Diana Raptor 4")
        {
            anim.runtimeAnimatorController = pHandgunController as RuntimeAnimatorController;
        }

        if (collision.gameObject.name == "Shotgun")
        {
            anim.runtimeAnimatorController = pPumpController as RuntimeAnimatorController;
        }

        if (collision.gameObject.name == "M1A1 Thompson")
        {
            anim.runtimeAnimatorController = pTommyController as RuntimeAnimatorController;
        }
    }
}
