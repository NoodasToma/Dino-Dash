using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_Movement : MonoBehaviour
{
   // Start is called before the first frame update
    public float moveSpeed ;
    public float deadZone ;

    private bg_spawn spawner;

    private Logic_Script logic;

    private bool bgin=true;


    


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
        spawner =  GameObject.FindGameObjectWithTag("BG").GetComponent<bg_spawn>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if(transform.position.x < -212&&bgin){
            Debug.Log("spawned");
            spawner.Spawnbg();
            bgin=false;
        }
        if(transform.position.x < deadZone)
        {
            Debug.Log("bg deleted");
            Destroy(gameObject);
            bgin= true;
        }
    }
}
