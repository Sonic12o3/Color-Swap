using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5;
    private Material defaultMaterial;
    new private Renderer renderer;
    public Material red;
    public Material blue;
    public Material yellow;
    public bool isJumping = false;
    private string currentMaterial = "Default";
    [SerializeField] private bool isGrounded;

    public Image palatteSelectorBlack;
    public Image palatteSelectorRed;
    public Image palatteSelectorBlue;
    public Image palatteSelectorYellow;

    private AudioSource jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        defaultMaterial = renderer.material;
        jumpSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Movement
        MoveHorizontal();


        //Jumps if space is pressed
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            isGrounded = false;
            Jump();
        }

        //Changes color according to number press
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeColor("Default");
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeColor("Red");
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeColor("Blue");
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeColor("Yellow");

        //Game Over Check
        if(rb.transform.position.y <= -10)
        {
            GameManager.gameOver();
        }

    }


    //Abstraction
    void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveAmount = horizontalInput * speed;
        rb.velocity = new Vector3(moveAmount, rb.velocity.y, 0);
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
        jumpSound.Play();
    }

    //ABSTRACTION
    void ChangeColor(string newColor)
    {
        PalatteSelect(newColor);
        currentMaterial = newColor;
        Material newColorMat;

        //Changes the physics layer and material of the player
        switch (newColor)
        {
            case "Red":
                newColorMat = red;
                gameObject.layer = 10;
                renderer.material = newColorMat;
                break;
            case "Blue":
                newColorMat = blue;
                gameObject.layer = 11;
                renderer.material = newColorMat;
                break;
            case "Yellow":
                newColorMat = yellow;
                gameObject.layer = 12;
                renderer.material = newColorMat;
                break;
            case "Default":
                newColorMat = defaultMaterial;
                gameObject.layer = 9;
                renderer.material = newColorMat;
                break;
        }
        
        Debug.Log("Changed color to " + newColor);

    }

    // ENCAPSULATION
    public string getMaterial()
    {
        return currentMaterial;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    //You might want to get rid of this? Kinda finicky
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ground") && isJumping == true)
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    //Sets the Palatte Selector of the specific color on, while turning the others off
    private void PalatteSelect(string color)
    {
        switch (color)
        {
            case "Red":
                palatteSelectorRed.gameObject.SetActive(true);
                palatteSelectorBlue.gameObject.SetActive(false);
                palatteSelectorYellow.gameObject.SetActive(false);
                palatteSelectorBlack.gameObject.SetActive(false);
                break;
            case "Blue":
                palatteSelectorRed.gameObject.SetActive(false);
                palatteSelectorBlue.gameObject.SetActive(true);
                palatteSelectorYellow.gameObject.SetActive(false);
                palatteSelectorBlack.gameObject.SetActive(false);
                break;
            case "Yellow":
                palatteSelectorRed.gameObject.SetActive(false);
                palatteSelectorBlue.gameObject.SetActive(false);
                palatteSelectorYellow.gameObject.SetActive(true);
                palatteSelectorBlack.gameObject.SetActive(false);
                break;
            case "Default":
                palatteSelectorRed.gameObject.SetActive(false);
                palatteSelectorBlue.gameObject.SetActive(false);
                palatteSelectorYellow.gameObject.SetActive(false);
                palatteSelectorBlack.gameObject.SetActive(true);
                break;
        }
    }

   
}
