using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControler : MonoBehaviour
{
    Sprite[] walking;
    SpritesContainer sc;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpritesContainer>();
        //walking = sc.getPlayerUnarmedWalk();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
    }
}
