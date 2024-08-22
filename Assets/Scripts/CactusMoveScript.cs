using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CactusMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed ;
    public float deadZone = -45;
    private Logic_Script logic;
    private dinoscript dino;

    private bool speedIncreased;

    private float timesIncreased=1;

    private Animator myAnimator;
    
    
    // Start is called before the first frame update
    void Start()
    {   
         logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
         dino = GameObject.FindGameObjectWithTag("Dino").GetComponent<dinoscript>();
         myAnimator = GameObject.FindGameObjectWithTag("Dino").GetComponent<Animator>();
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

    private void OnCollisionEnter2D(Collision2D collision) {
        logic.gameOver();
        dino.death();
        myAnimator.SetBool("Dead",true);
        
    }

    
}
