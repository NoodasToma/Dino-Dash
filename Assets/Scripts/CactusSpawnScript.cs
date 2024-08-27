using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cactus;

    public GameObject cactus2;

    private float spawnRte;
    private float timer = 0;
   
    public float min ;
    public float max ;

    public float offset ;

    public bool item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRte)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawnRte = Random.Range(min, max);
            spawnCactus();
        }
        
       
    }

    void spawnCactus()
    {
        float closestPoint = transform.position.x + offset;
        float furthestPoint = transform.position.x - offset ;

        float closestPointy = transform.position.y + offset;
        float furthestPointy = transform.position.y;

        if(item){
           if(Random.Range(0,2)==0){
            Instantiate(cactus, new Vector3(Random.Range(closestPoint, furthestPoint), Random.Range(closestPointy, furthestPointy), 0), transform.rotation);
          }
          else{
             Instantiate(cactus2, new Vector3(Random.Range(closestPoint, furthestPoint), Random.Range(closestPointy, furthestPointy), 0), transform.rotation);
          }
        }else{
            if(Random.Range(0,2)==0){
            Instantiate(cactus, new Vector3(Random.Range(closestPoint, furthestPoint), transform.position.y, 0), transform.rotation);
          }
          else{
             Instantiate(cactus2, new Vector3(Random.Range(closestPoint, furthestPoint), transform.position.y, 0), transform.rotation);
          }
        }

        

        
    }
}
