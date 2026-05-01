using UnityEngine.InputSystem;
using UnityEngine;

public class XRPlayerMovement : MonoBehaviour
{
    [SerializeField] InputAction PrimaryJoy;
    [SerializeField] Rigidbody PlayerBody;
    [SerializeField] GameObject PlayerDirection;
    [SerializeField] float mult = 1f;
    [SerializeField] float stepheight = 1f;
    [SerializeField] ForceMode forceMode = ForceMode.Force;

    void OnEnable()
    {
        PrimaryJoy.Enable();
    }

    void OnDisable()
    {
        PrimaryJoy.Disable();
    }

    void FixedUpdate()
    {
        Vector2 joy = PrimaryJoy.ReadValue<Vector2>();
        Vector3 input = new Vector3(joy.x, 0, joy.y);
        Vector3 dirinput = PlayerDirection.transform.TransformDirection(input);
        dirinput.y = 0f;

        if (dirinput.sqrMagnitude > 0f)
        {
            dirinput.Normalize();
            TryStepUp(dirinput);
            PlayerBody.AddForce(dirinput * mult * Time.fixedDeltaTime, forceMode);
        }
    }

    void TryStepUp(Vector3 direction)
    {
        Vector3 lowOrigin = transform.position + Vector3.up * 0.15f;
        Vector3 highOrigin = transform.position + Vector3.up * (stepheight + 0.15f);

        if (!Physics.Raycast(lowOrigin, direction, out RaycastHit lowHit, stepheight))
            return;

        if (Physics.Raycast(highOrigin, direction, stepheight))
            return;

        PlayerBody.MovePosition(Vector3.Lerp(PlayerBody.position, PlayerBody.position + Vector3.up * stepheight, Time.deltaTime));
    }
}
