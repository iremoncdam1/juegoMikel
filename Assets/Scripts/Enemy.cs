using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //MOVIMIENTO
    public float speed = 1f;
    public float changeTime = 1f;
    float timer;
    int direction;

    //ANIMACIÓN
    Animator animator;

    void Start()
    {
        direction = 1;
        timer = changeTime;
        animator = GetComponent<Animator>();
        animator.SetFloat("X_direction", direction);
    }


    void Update()
    {
        movement();
    }


    void movement()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            direction = direction * -1;
            timer = changeTime;
            animator.SetFloat("X_direction", direction);
        }

        Vector2 position = transform.position;
        position.x = position.x + speed * direction * Time.deltaTime;

        
        transform.position = position;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*ContactPoint2D cp = collision.GetContact(0);
        if (cp != null)
        {
            Debug.Log("Auch" + collision);
            player.changeHealth(-1);
            //Destroy(gameObject);
        }*/
        Debug.Log("a: " + collision.gameObject.name);


    }
}
