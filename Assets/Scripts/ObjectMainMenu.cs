using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMainMenu : MonoBehaviour
{
    private float max_x;
    private float max_y;
    private float min_x;
    private float min_y;
    private Transform _tr;
    Movement go;
    // Start is called before the first frame update
    void Awake()
    {
        go = GetComponent<Movement>();
        _tr = GetComponent<Transform>();
        max_x = -0.9f;
        min_x = -5f;
        max_y = 2.2f;
        min_y = -1.2f;
    }

// Update is called once per frame
    void Update()
    {
        if (_tr.position.x > max_x || _tr.position.x < min_x)
        {
                go._direction = new Vector3(-go._direction.x, go._direction.y);
        }
        if (_tr.position.y > max_y || _tr.position.y < min_y)
        {
                go._direction = new Vector3(go._direction.x, -go._direction.y);
        }

    }
}
