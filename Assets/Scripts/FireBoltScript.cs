using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBoltScript : MonoBehaviour
{

    public float moveSpeed;



   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
    }


   void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Opp"))
        {
        Debug.Log("trigged");
        other.gameObject.GetComponent<CactusMoveScript>().burn();
        Destroy(gameObject);
        
        }
   }
}
