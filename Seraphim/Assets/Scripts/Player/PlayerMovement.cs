using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 10f;
    private InputAction moveAction;
    private Vector2 moveValue;
    private Vector3 moveDirection;
    private CharacterController cc;

    private void Awake()
    {
        moveAction = new InputAction();
        moveAction = InputSystem.actions.FindAction("Move");
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (GameStateManager.GetGameState() == GameStateManager.GAMESTATE.PLAYING)
        {
            moveValue = moveAction.ReadValue<Vector2>();
            moveDirection = transform.right * moveValue.x + transform.forward * moveValue.y;
            //print(transform.forward + " " + moveValue.y);
        }
    }
    

    private void FixedUpdate()
    {
        if (GameStateManager.GetGameState() == GameStateManager.GAMESTATE.PLAYING)
        {
            moveCharacter(moveDirection);
        }
    }

    void moveCharacter(Vector3 direction)
    {
        if (GameStateManager.GetGameState() == GameStateManager.GAMESTATE.PLAYING)
        {
            if(cc.isGrounded)
            {
                cc.SimpleMove(moveDirection * moveSpeed /** Time.deltaTime*/);
            }
            else
            {
                cc.SimpleMove(Vector3.zero);
            }
        }
    }
    
}