using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera fpsCam;
    public Transform fpsHold;
    public CharacterController controller;
    public bool IsLockCursor;
    public float MouseSensitivity = 10;
    public float WalkSpeed = 3;
    public float RunSpeed = 6;
    public float JumpForce = 8;
    public float Gravity = 18;
    [Tooltip("The sensitivity between input and moving"), Range(0f, 0.25f)]
    public float MoveSmoothTime = 0.1f;
    [Tooltip("The sensitivity between input and rotating"), Range(0f, 0.25f)]
    public float RotationSmoothTime = 0.1f;
    public Vector2 PitchMinMax = new Vector2(-40, 85);
    [Space]
    private float yaw;
    private float pitch;

    float smoothYaw;
    float smoothPitch;
    float yawSmoothV;
    float pitchSmoothV;
    float verticalVelocity;
    Vector3 velocity;
    Vector3 smoothV;

    bool jumping;
    float lastGroundedTime;

    void Start()
    {
        if (IsLockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        controller = GetComponent<CharacterController>();
        yaw = fpsCam.transform.localEulerAngles.y;
        pitch = this.transform.localEulerAngles.x;
        smoothYaw = yaw;
        smoothPitch = pitch;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }
        else
        {
            if (IsLockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        CalculateCamera();
        CalculatePosition();
        CalculateHold();
    }

    void CalculateCamera()
    {
        // Camera
        float mX = Input.GetAxisRaw("Mouse X");
        float mY = Input.GetAxisRaw("Mouse Y");
        float mMag = Mathf.Sqrt(mX * mX + mY * mY);

        if (mMag > 5)
        {
            mX = 0;
            mY = 0;
        }

        yaw += mX * MouseSensitivity;
        pitch -= mY * MouseSensitivity;
        pitch = Mathf.Clamp(pitch, PitchMinMax.x, PitchMinMax.y);
        smoothPitch = Mathf.SmoothDampAngle(smoothPitch, pitch, ref pitchSmoothV, RotationSmoothTime);
        smoothYaw = Mathf.SmoothDampAngle(smoothYaw, yaw, ref yawSmoothV, RotationSmoothTime);

        fpsCam.transform.localEulerAngles = Vector3.right * smoothPitch;
        this.transform.localEulerAngles = Vector3.up * smoothYaw;
    }

    void CalculateHold()
    {
        Vector3 targetEulers = new Vector3(fpsCam.transform.eulerAngles.x, fpsCam.transform.eulerAngles.y);
        // targetEulers.x = Mathf.Clamp(targetEulers.x, -40, 40);
        var targetRotation = Quaternion.Euler(targetEulers.x, targetEulers.y, 0);
        fpsHold.rotation = Quaternion.Slerp(fpsHold.rotation, targetRotation, 30f * Time.deltaTime);
    }

    void CalculatePosition()
    {
        var forward = Vector3.Cross(this.transform.right, Vector3.up).normalized;
        var right = Vector3.Cross(this.transform.forward, Vector3.up).normalized;
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 dir = -right * input.x + forward * input.y;
        // Vector3 worldInputDir = transform.TransformDirection(dir);

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;
        Vector3 targetVelocity = dir * currentSpeed;
        velocity = Vector3.SmoothDamp(velocity, targetVelocity, ref smoothV, MoveSmoothTime);

        verticalVelocity -= Gravity * Time.deltaTime;
        velocity = new Vector3(velocity.x, verticalVelocity, velocity.z);

        var flags = controller.Move(velocity * Time.deltaTime);
        if (flags == CollisionFlags.Below)
        {
            jumping = false;
            lastGroundedTime = Time.time;
            verticalVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float timeSinceLastTouchedGround = Time.time - lastGroundedTime;
            if (controller.isGrounded || (!jumping && timeSinceLastTouchedGround < 0.15f))
            {
                jumping = true;
                verticalVelocity = JumpForce;
            }
        }
    }
}