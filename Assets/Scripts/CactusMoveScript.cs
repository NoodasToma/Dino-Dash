using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 7;
    public float deadZone = -45;
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
            Debug.Log("Wolfgang deleted.");
            Destroy(gameObject);
        }
    }
}
