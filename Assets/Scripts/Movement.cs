using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMoving = true;

    public float _lower_velocity = 3.0f;
    public float _upper_velocity = 6.0f;

    private float velocity = 5.0f;

    private Transform _tr;

    public Vector3 _direction;

    void Awake()
    {
        _tr = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        float angle = UnityEngine.Random.value * 2 * Mathf.PI;
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);

        _direction = new Vector2(x, y);

        velocity =
            UnityEngine.Random.Range(_lower_velocity, _upper_velocity);

    }

    // Update is called once per frame
    void Update()
    {
        // used for debugging and testing purposes
        if (isMoving)
            _tr.position =
                _tr.position + _direction * velocity * Time.deltaTime;
    }

    public void Destroy()
    {
        // AudioManager.Instance.ExplosionSound();
        Destroy(gameObject);
    }
}
