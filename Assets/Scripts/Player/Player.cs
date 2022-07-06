using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    public Animator animator;
    private Vector2 direction;
    private Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = joystick.Horizontal;
        direction.y = joystick.Vertical;

       animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rg.MovePosition(rg.position + direction * speed * Time.fixedDeltaTime);
    }
}
