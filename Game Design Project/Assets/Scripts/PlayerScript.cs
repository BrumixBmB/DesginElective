using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    public RuntimeAnimatorController pHandgunController;
    public RuntimeAnimatorController pUnarmedController;
    public RuntimeAnimatorController pPumpController;
    public RuntimeAnimatorController pTommyController;
    public RuntimeAnimatorController Death;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("TutorialLevel");
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
        if(collision.gameObject.layer == 8)
        {
            anim.runtimeAnimatorController = pHandgunController as RuntimeAnimatorController;
        }

        if (collision.gameObject.layer == 9)
        {
            anim.runtimeAnimatorController = pPumpController as RuntimeAnimatorController;
        }

        if (collision.gameObject.layer == 10)
        {
            anim.runtimeAnimatorController = pTommyController as RuntimeAnimatorController;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            anim.runtimeAnimatorController = Death as RuntimeAnimatorController;
        }
    }

    public void PlayerDeath()
    {
        moveSpeed = 0f;
    }
}
