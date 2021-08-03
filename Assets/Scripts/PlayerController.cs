using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5;
    private Material defaultMaterial;
    private Renderer renderer;
    public Material red;
    public Material blue;
    public Material yellow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Movement
        MoveHorizontal();

        //Jumps if space is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Changes color according to number press
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeColor("default");
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeColor("Red");
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeColor("Blue");
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeColor("Yellow");
    }

    void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveAmount = horizontalInput * speed;
        rb.velocity = new Vector3(moveAmount, rb.velocity.y, 0);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
    }

    void ChangeColor(string newColor)
    {
        Material newColorMat;
        if (newColor == "Red")
        {
            newColorMat = red;
            gameObject.layer = 10;
        }
        else if (newColor == "Blue")
        {
            newColorMat = blue;
            gameObject.layer = 11;
        }
        else if (newColor == "Yellow")
        {
            newColorMat = yellow;
            gameObject.layer = 12;
        }
        else
        { 
            newColorMat = defaultMaterial;
            gameObject.layer = 9;
        }
        renderer.material = newColorMat;
        Debug.Log("Changed color to " + newColor);

    }

}
