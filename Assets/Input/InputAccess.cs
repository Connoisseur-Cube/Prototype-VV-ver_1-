using UnityEngine;

public class InputAccess : MonoBehaviour
{
    private PlayerIActions Input;

    [SerializeField]public Vector2 move;
    [SerializeField]public float jump;
    [SerializeField]public float attack;
    [SerializeField]public float item;


    void Awake()
    {
        Input = new PlayerIActions();
        Input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.Player.Movement.ReadValue<Vector2>();
        jump = Input.Player.Jump.ReadValue<float>();  
        attack = Input.Player.Attack.ReadValue<float>();
        item = Input.Player.Item.ReadValue<float>(); 
    }
}
