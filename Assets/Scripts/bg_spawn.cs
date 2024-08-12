using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_spawn : MonoBehaviour
{
    public GameObject bg;

    public float spawnrate;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float timer=0;

        if(timer<spawnrate){
            timer=Time.deltaTime;
        }
        else{
            Spawnbg();
        }
    }

    public void Spawnbg(){
        Instantiate(bg,new Vector3(transform.position.x,transform.position.y,0),transform.rotation);
    }
}
