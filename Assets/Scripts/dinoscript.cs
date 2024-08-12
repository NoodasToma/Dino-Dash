using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinoscript : MonoBehaviour
{
    public Rigidbody2D dinosaur;

    public float jump;

    public Logic_Script logic;

    

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)){
            dinosaur.velocity = Vector2.up * jump;
            
        }
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

     private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        
        
    }
}
