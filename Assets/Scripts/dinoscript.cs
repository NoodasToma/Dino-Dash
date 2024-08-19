using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class dinoscript : MonoBehaviour
{
    public Rigidbody2D dinosaur;

    public float jump;

    public bool dinoIsAlive = true;

    public float fallGravity;

    public float regularGravity;

    
   
    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
        float currentY = GetComponent<Transform>().position.y;

        if(Input.GetKeyDown(KeyCode.Space) && dinoIsAlive){
            if(currentY < -3.26){ 
                dinosaur.velocity = Vector2.up*jump;
                
            }
        }

        if(isFalling()){
        dinosaur.gravityScale = fallGravity;
        }
        else{
        dinosaur.gravityScale = regularGravity;
           
        }
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void death(){
        dinoIsAlive = false;

    }

  


    bool isFalling(){
        if(dinosaur.velocity.y<0){
         
            return true;
        }
        return false;
    }

    

   
}
