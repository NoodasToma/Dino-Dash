using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_Movement : MonoBehaviour
{
   // Start is called before the first frame update
    public float moveSpeed ;
    public float deadZone ;
    // Start is called before the first frame update
    void Start()
    {
        
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
