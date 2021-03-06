using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class WhiteEnemy : Enemy
{
    // POLYMORPHISM
    public override void Collision(Collider other)
    {
        GameObject collider = other.gameObject;
        if (collider.CompareTag("Player"))
        {
            Debug.Log("got here");
            //Gets PlayerControllr script
            PlayerController pc = collider.GetComponent<PlayerController>();

            //If player isn't jumping then it's a game over, but if it is then destroy enemy\
            //The material has to be different, and also not the default material
            if (pc.isJumping && pc.getMaterial() == "Default")
            {
                Destroy(gameObject);
                pc.Jump();
            }
            else
                GameManager.gameOver();
        }
    }
}
