using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTriggerScript : MonoBehaviour
{
    private Logic_Script logic;
    
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
    
        
    }



    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 3){
            logic.addScore(1);
        }

         
    }
}
