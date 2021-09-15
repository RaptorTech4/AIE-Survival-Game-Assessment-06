using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController _Controller;
    public Transform MainCamera;

    public float Speed = 6.0f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void FixedUpdate()
    {
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");
        Vector3 _direction = new Vector3(_horizontal, 0f, _vertical).normalized;

        if (_direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + MainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _Controller.Move(moveDir.normalized * Speed * Time.deltaTime);
        }
    }
}
