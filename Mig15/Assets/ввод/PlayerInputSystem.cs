using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    private PlayerInput playerInput;
    private Main playerInputActions;
    public float movementSpeed = 1f;
    //private PlayerInputActions playerInputActions;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new Main();
        playerInputActions.gamePlain.Enable();
        playerInputActions.gamePlain.SmallShout.performed += SmallShout;
        
        /*
        player Input = GetComponent <PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Movement.performed += Movement_performed;
        */
    }
    private void Update()
    {
        Vector2 inputVector = playerInputActions.gamePlain.mouve.ReadValue<Vector2>();
        Vector2 movement = inputVector * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -3f, 3f);
        transform.position = newPosition;


    }
    void Start()
    {
        
    }


    public void SmallShout(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("shout");
        }
           
    }
}

