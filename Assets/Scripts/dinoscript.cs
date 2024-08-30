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

    public float maxJump;

    public float jumpMul;

    private bool inAir = false;

    private float jumpCount = 0;


    public AudioSource jumpAudio;

    public AudioSource fireAudio;

    public AudioSource itemAudio;

    public AudioSource deathAudio;

    public AudioSource mainAudio;

   
           
   
    // Start is called before the first frame update
    void Start()
    {
      myAnimator = GetComponent<Animator>();
      fireCount = GameObject.FindGameObjectWithTag("FireCount").GetComponent<Animator>();    

    }

    // Update is called once per frame
    void Update()
    {
        
        

        if((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0)) && dinoIsAlive){
            if(onGround()||drunk&&!onGround()){ 
                dinosaur.velocity = Vector2.up*jump;
                myAnimator.SetBool("Jump",true);
                drunk=false;
                myAnimator.SetBool("Drunk",false);
                inAir=true;
                jumpCount=0;
                jumpAudio.Play();
            }
        }

        if(dinosaur.velocity.y>0&&inAir){
            jumpCount+= Time.deltaTime;
            
            if(jumpCount>maxJump) inAir =false;

            dinosaur.velocity += new Vector2(0,-Physics2D.gravity.y)*jumpMul*Time.deltaTime;
        }



        

        if(Input.GetKeyUp(KeyCode.Space)||Input.GetKeyUp(KeyCode.Mouse0)){
            inAir = false;
        }

        if((Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.Mouse1))&&dinoIsAlive){
           if(shots.ToArray().Length!=0){
             if(shots.Pop()){
                
                Debug.Log("fired");
                myAnimator.SetTrigger("Fired");
                Instantiate(fire, transform.position, transform.rotation);
                FireCount();
                fireAudio.Play();
             }
         }
        }

        if(!onGround()){
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
        if(dinoIsAlive){
        transform.Rotate(0,0,90);
        deathAudio.Play();
        }
        
        dinoIsAlive = false;
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
            itemAudio.Play();
        }
        if(other.gameObject.tag=="Lobiani"&&shots.ToArray().Length<3){
            shots.Push(true);
            Debug.Log("appended");
            FireCount();
            itemAudio.Play();
        }
    }


    void FireCount(){
        fireCount.SetInteger("Count",shots.ToArray().Length);
         

    }

    bool onGround(){
        float currentY = GetComponent<Transform>().position.y;

        if(currentY < -3){
            return true;
        }

        return false ; 
    }

    
    

   
}
 

