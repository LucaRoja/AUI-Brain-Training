using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    private float speed = -2;
    public GameObject bus;
    public bool firstspawned = false; // only destroy objects coming from right (spawn) 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        //Debug.Log(bus.GetComponent<Transform>().position.x);
        if (bus.GetComponent<Transform>().position.x + 1.5f  >= transform.position.x && firstspawned)
            gameObject.SetActive(false);
        else if (transform.position.x < bus.GetComponent<Transform>().position.x - 10)
            {
            Destroy(gameObject);
        }
    }
    void unspawnpoint()
    {
        //gameObject.GetComponent<Transform>().position.x = bus.GetComponent<Transform>().position.x;
    }
}
