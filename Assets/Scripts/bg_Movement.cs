using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_Movement : MonoBehaviour
{
   // Start is called before the first frame update
    public float moveSpeed ;
    public float deadZone ;

    private Logic_Script logic;
     private float timesIncreased=1;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
        timesIncreased=logic.playerScore/20;
        moveSpeed += timesIncreased;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if(transform.position.x < deadZone)
        {
            Debug.Log("bg deleted");
            Destroy(gameObject);
        }
    }
}
