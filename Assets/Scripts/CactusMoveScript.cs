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
    
    
    // Start is called before the first frame update
    void Start()
    {   
         logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
         dino = GameObject.FindGameObjectWithTag("Dino").GetComponent<dinoscript>();

         timesIncreased=logic.playerScore/10;
         moveSpeed +=2*timesIncreased;
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
        
        
    }

    
}
