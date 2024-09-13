using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_spawn : MonoBehaviour
{
    public GameObject bg;

   
  

    public float spawnX;

    public float spawnY;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bg,new Vector3((float)1.74, (float)-0.3300205, 0),transform.rotation);
        
    }

    
    

    public void Spawnbg(){
        Instantiate(bg,new Vector3(spawnX,spawnY,0),transform.rotation);
    }
}
