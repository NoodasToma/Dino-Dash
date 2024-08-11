using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinoscript : MonoBehaviour
{
    public Rigidbody2D dinosaur;

    public float jump;

    public bool onGround = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && onGround ){
            dinosaur.velocity = Vector2.up * jump;
            onGround = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
