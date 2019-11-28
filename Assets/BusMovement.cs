///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class BusMovement : MonoSingleton<BusMovement>
public class BusMovement : MonoBehaviour

{
    public float speed = 5f;
    public float stops = 5f;
    public bool go = true;
    private float x = -12.99f;
    public int currentstop = 0;
    public SpawnManagerBus manager;

    void Start()
    {
        x = transform.position.x + 102.38f / (stops);

    }
// Update is called once per frame

    void Update()
    {
        
            
        if (currentstop < stops && go == true)
        {
            
            if(transform.position.x < x)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                go = false;
                manager.TestSpawn();
                currentstop++;
                x = transform.position.x + 102.38f / (stops);
                }

        }
    }
}
//*/

/*
using UnityEngine;
using System.Collections;
using UnityEngine;

public class BusMovement : MonoBehaviour

{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }
    }
}
*/
