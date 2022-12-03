using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAccess : MonoBehaviour
{
    private PlayerIActions Input;

    [SerializeField]public Vector2 move;
    [SerializeField]public float jump;
    [SerializeField]public float attack;
    [SerializeField]public float item;

    private InputAction m;

    void Awake()
    {
        Input = new PlayerIActions();
        Input.Enable();
        m = Input.Player.Movement;
    }

    // Update is called once per frame
    void Update()
    {
        move = m.ReadValue<Vector2>();
        jump = Input.Player.Jump.ReadValue<float>();  
        attack = Input.Player.Attack.ReadValue<float>();
        item = Input.Player.Item.ReadValue<float>(); 
    }
}
