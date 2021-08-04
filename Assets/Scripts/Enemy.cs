using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float xMin;
    [SerializeField] private float xMax;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        if (rb.position.x < xMin)
        {
            Debug.Log("turn1");
            speed = -speed;
            rb.position = new Vector3(xMin + 0.1f, rb.position.y, 0);
        }
        else if (rb.position.x > xMax)
        {
            Debug.Log("turn2");
            speed = -speed;
            rb.position = new Vector3(xMax - 0.1f, rb.position.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Collision(other);
    }

    public virtual void Collision(Collider other)
    {
        GameObject collider = other.gameObject;
        if(collider.CompareTag("Player"))
        {
            //Gets PlayerControlelr script
            PlayerController pc = collider.GetComponent<PlayerController>();
            //If player isn't jumping then it's a game over, but if it is then destroy enemy
            if (!pc.isJumping)
                GameManager.gameOver();
            else
            {
                Destroy(gameObject);
                pc.Jump();
            }
        }
    }

}
