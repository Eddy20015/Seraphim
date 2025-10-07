using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensX = 1f;
    [SerializeField] private float sensY = 1f;

    [SerializeField] private float pitchRestraint = 15f;
    [SerializeField] private float yawRestraint = 15f;
    [SerializeField] private bool enableYawRestraint;

    [SerializeField] private Transform orientation;

    private float xRotation;
    private float yRotation;

    private InputAction lookAction;
    private Vector2 lookValue;

    void Awake()
    {
        lookAction = new InputAction();
        lookAction = InputSystem.actions.FindAction("Look");

        ToggleCursor(true);
    }

    private void Update()
    {
        if (GameStateManager.GetGameState() == GameStateManager.GAMESTATE.PLAYING)
        {
            enableYawRestraint = false;

            // Get mouse input
            lookValue = lookAction.ReadValue<Vector2>();
            float mouseX = lookValue.x * sensX * Time.deltaTime;
            float mouseY = lookValue.y * sensY * Time.deltaTime;

            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -pitchRestraint, pitchRestraint);
            yRotation = enableYawRestraint ? Mathf.Clamp(yRotation, -yawRestraint, yawRestraint) : yRotation;

            // Rotate camera and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
        else if (GameStateManager.GetGameState() == GameStateManager.GAMESTATE.TALKING)
        {
            enableYawRestraint = true;

            // Get mouse input
            lookValue = lookAction.ReadValue<Vector2>();
            float mouseX = lookValue.x * sensX * Time.deltaTime;
            float mouseY = lookValue.y * sensY * Time.deltaTime;

            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -pitchRestraint, pitchRestraint);
            yRotation = enableYawRestraint ? Mathf.Clamp(yRotation, -yawRestraint, yawRestraint) : yRotation;

            // Rotate camera and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
            
    }

    public void ToggleCursor(bool lockCursor)
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
