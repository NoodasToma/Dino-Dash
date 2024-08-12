using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_spawn : MonoBehaviour
{
    public GameObject bg;

    public float spawnrate;
    private float timer=0;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bg,new Vector3((float)49.5, (float)1.2, 0),transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(timer<spawnrate){
            timer+=Time.deltaTime;
        }
        else{
            Spawnbg();
            timer=0;
        }
    }

    public void Spawnbg(){
        Instantiate(bg,new Vector3(transform.position.x,transform.position.y,0),transform.rotation);
    }
}
