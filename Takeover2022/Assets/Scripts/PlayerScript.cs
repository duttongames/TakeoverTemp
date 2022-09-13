using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Variables
    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * playerSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Collide with obstacle and game over.
        if (collision.gameObject.layer == 7)
        {
            gameOver.SetActive(true);
            gameObject.SetActive(false);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(100, 0, 0));
        }
    }
}
