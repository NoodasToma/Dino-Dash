using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CactusMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed ;
    public float deadZone ;
    private Logic_Script logic;
    private dinoscript dino;

    private float timesIncreased=1;

    private Animator myAnimator;

    private Animator oppAnimator;
    
    
    // Start is called before the first frame update
    void Start()
    {   
         logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
         dino = GameObject.FindGameObjectWithTag("Dino").GetComponent<dinoscript>();
         myAnimator = GameObject.FindGameObjectWithTag("Dino").GetComponent<Animator>();
         oppAnimator = GetComponent<Animator>();
         timesIncreased=logic.playerScore/10;
         moveSpeed += timesIncreased;
    }

    // Update is called once per frame
    void Update()
    {

    
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
       
        if(transform.position.x < deadZone)
        {
            Debug.Log("Wolfgang deleted.");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        
        if(collision.gameObject.tag=="Dino"){
         logic.gameOver();
         dino.death();
         myAnimator.SetBool("Dead",true);
        }

        
       
        
    }


  

    

    public void burn(){
        gameObject.GetComponent<Collider2D>().enabled = false;
        oppAnimator.SetBool("Burnt",true);
        Debug.Log("Burnt");
        
             
    }

    
}
