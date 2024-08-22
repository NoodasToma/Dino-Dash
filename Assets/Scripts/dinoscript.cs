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

    private Animator myAnimator;

    private bool drunk ;

    
   
    // Start is called before the first frame update
    void Start()
    {
      myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float currentY = GetComponent<Transform>().position.y;

        if(Input.GetKeyDown(KeyCode.Space) && dinoIsAlive){
            if(currentY < -3.26||drunk&&currentY > -3.26){ 
                dinosaur.velocity = Vector2.up*jump;
                myAnimator.SetBool("Jump",true);
                drunk=false;
                myAnimator.SetBool("Drunk",false);
            }
        }

        if(currentY > -3.26){
            myAnimator.SetBool("Jump",true);
        }
        else{
            myAnimator.SetBool("Jump",false);
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
        transform.Rotate(0,0,90);

    }

  


    bool isFalling(){
        if(dinosaur.velocity.y<0){
         
            return true;
        }
        return false;
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Beer"){
            drunk=true;
            myAnimator.SetBool("Drunk",true);
        }
    }

    

   
}
