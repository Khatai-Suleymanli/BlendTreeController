using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Animation Stuff")]
    public Animator animator;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;
    public float maxWalkVelocity = 0.3f;
    public float maxRunVelocity = 1.0f;

    private int velocityZHash;
    private int velocityXHash;
    private float velocityX = 0.0f;
    private float velocityZ = 0.0f;

    private void Start()
    {
        InitializeAnimator();
    }

    private void InitializeAnimator()
    {
        animator = GetComponent<Animator>();
        velocityZHash = Animator.StringToHash("vertical");
        velocityXHash = Animator.StringToHash("horizontal");
    }

    private void Update()
    {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool aiming = Input.GetKey(KeyCode.Mouse1);

        float currentMaxVelocity = runPressed && !aiming ? maxRunVelocity : maxWalkVelocity;

        UpdateVelocity(forwardPressed, leftPressed, rightPressed, runPressed, backPressed, currentMaxVelocity);
        LockOrResetVelocity(forwardPressed, leftPressed, rightPressed, runPressed, backPressed, currentMaxVelocity);

        UpdateAnimator();
    }

    private void UpdateVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, bool backPressed, float currentMaxVelocity)
    {
        // Update the Z-axis velocity (forward/backward movement).
        velocityZ = UpdateAxisVelocity(velocityZ, forwardPressed, backPressed, currentMaxVelocity);

        // Update the X-axis velocity (sideways movement).
        velocityX = UpdateAxisVelocity(velocityX, rightPressed, leftPressed, currentMaxVelocity);
    }

    private float UpdateAxisVelocity(float currentVelocity, bool positiveKeyPressed, bool negativeKeyPressed, float currentMaxVelocity)
    {
        float targetVelocity = 0.0f;

        // Determine the target velocity based on input.
        if (positiveKeyPressed && currentVelocity < currentMaxVelocity)
        {
            targetVelocity = currentMaxVelocity; // Accelerate in positive direction.
        }
        else if (negativeKeyPressed && currentVelocity > -currentMaxVelocity)
        {
            targetVelocity = -currentMaxVelocity; // Accelerate in negative direction.
        }

        // Accelerate or decelerate towards the target velocity.
        if (currentVelocity < targetVelocity)
        {
            currentVelocity += Time.deltaTime * acceleration;
            currentVelocity = Mathf.Min(currentVelocity, targetVelocity); // Limit the velocity to the target.
        }
        else if (currentVelocity > targetVelocity)
        {
            currentVelocity -= Time.deltaTime * acceleration;
            currentVelocity = Mathf.Max(currentVelocity, targetVelocity); // Limit the velocity to the target.
        }

        // Decelerate if no movement keys are pressed.
        if (!positiveKeyPressed && !negativeKeyPressed)
        {
            currentVelocity = Mathf.Lerp(currentVelocity, 0.0f, Time.deltaTime * deceleration);
        }

        return currentVelocity;
    }

    private void LockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool runPressed, bool backPressed, float currentMaxVelocity)
    {
        // Lock or reset the Z-axis velocity based on input.
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ = Mathf.Lerp(velocityZ, 0
