using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimits : MonoBehaviour
{
    public Screen screen;
    public bool bounce = false;
    private float max_x;
    private float max_y;
    
    private Transform _tr;
    Movement go;

    void Awake()
    {
        go = GetComponent<Movement>();
        _tr = GetComponent<Transform>();
        max_x = screen.Width / 2f;
        max_y = screen.Height / 2f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_tr.position.x > max_x || _tr.position.x < -max_x)
        {
            if (bounce)
            {
                go._direction = new Vector3(-go._direction.x, go._direction.y);
            }
            else
            {
                _tr.position = new Vector3(-_tr.position.x,
                    _tr.position.y, _tr.position.z);
            }
        }
        
        if (_tr.position.y > max_y || _tr.position.y < -max_y)
        {
            if (bounce)
            {
                go._direction = new Vector3(go._direction.x,-go._direction.y);
            }
            else
            {
                _tr.position = new Vector3(_tr.position.x,
                    -_tr.position.y, _tr.position.z);
            }
        }        
        
    }
}
