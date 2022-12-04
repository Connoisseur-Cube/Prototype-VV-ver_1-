using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Basic Script. Will be changed later or never, depending on the life and complexity of this project.
    //This is a prototype to test multiple things, hence I will not "polish" any more than necessary

public class Player : MonoBehaviour
{
    public Vector2 m;
    private InputAccess Input;

    void Awake() 
    {
        Input = GetComponent<InputAccess>();
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        m = Input.move;  
    }
}
