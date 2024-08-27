using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class dinoscript : MonoBehaviour
{
    public Rigidbody2D dinosaur;

    public GameObject fire;

    public float jump;

    private bool dinoIsAlive = true;

    public float fallGravity;

    public float regularGravity;

    private Animator myAnimator;

    private bool drunk ;

    private Stack<bool> shots = new Stack<bool>();

    private Animator fireCount;

    

   
           
   
    // Start is called before the first frame update
    void Start()
    {
      myAnimator = GetComponent<Animator>();
      fireCount = GameObject.FindGameObjectWithTag("FireCount").GetComponent<Animator>();    

    }

    // Update is called once per frame
    void Update()
    {
        float currentY = GetComponent<Transform>().position.y;

        if((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0)) && dinoIsAlive){
            if(currentY < -3.26||drunk&&currentY > -3.26){ 
                dinosaur.velocity = Vector2.up*jump;
                myAnimator.SetBool("Jump",true);
                drunk=false;
                myAnimator.SetBool("Drunk",false);
            }
        }

        if((Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.Mouse1))&&dinoIsAlive){
           if(shots.ToArray().Length!=0){
             if(shots.Pop()){
                
                Debug.Log("fired");
                myAnimator.SetTrigger("Fired");
                Instantiate(fire, transform.position, transform.rotation);
                FireCount();
             }
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
        if(other.gameObject.tag=="Lobiani"&&shots.ToArray().Length<3){
            shots.Push(true);
            Debug.Log("appended");
            FireCount();
        }
    }


    void FireCount(){
        fireCount.SetInteger("Count",shots.ToArray().Length);
       

    }
    

   
}
 

