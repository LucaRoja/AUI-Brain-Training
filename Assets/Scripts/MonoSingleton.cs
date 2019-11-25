using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance = null;
    public static T Instance // Captical because this is a property 
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>(); // Create a new game object and add component type of T
                instance.Init();
            }

            return instance;

        }
    }

    public virtual void Init() { }
    private void Awake()
    {
        if (instance == null)
            instance = this as T; 
    }
   
}
