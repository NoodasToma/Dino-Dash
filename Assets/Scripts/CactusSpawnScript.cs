using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cactus;
    private float spawnRte;
    private float timer = 0;
    public float widthOffset = 1.5F;
    public float min = 2.5f;
    public float max = 3f;
    // Start is called before the first frame update
    void Start()
    {
        spawnCactus();
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
        float closestPoint = transform.position.x - widthOffset;
        float furthestPoint = transform.position.x + widthOffset;
        Instantiate(cactus, new Vector3(Random.Range(closestPoint, furthestPoint), transform.position.y, 0), transform.rotation);
    }
}
