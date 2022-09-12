using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy obstacle when it goes off the left of the screen.
        if (transform.position.x < Camera.main.transform.position.x - 10)
        {
            Destroy(gameObject);
        }
    }
}
