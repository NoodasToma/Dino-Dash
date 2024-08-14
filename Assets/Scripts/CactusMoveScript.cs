using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 7;
    public float deadZone = -45;
    public Logic_Script logic;
    public dinoscript dino;
    // Start is called before the first frame update
    void Start()
    {
         logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
         dino = GameObject.FindGameObjectWithTag("Dino").GetComponent<dinoscript>();
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
