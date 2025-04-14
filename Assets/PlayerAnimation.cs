using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    public float smoothing = 10f;
    private Animator animator;
    private Vector3 lastPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate movement velocity
        Vector3 currentPosition = transform.position;
        Vector3 delta = currentPosition - lastPosition;
        float speed = delta.magnitude / Time.deltaTime;

        // Smooth out sudden changes
        float currentSpeed = animator.GetFloat("Speed");
        float smoothedSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime * smoothing);

        // Set animation parameter
        animator.SetFloat("Speed", smoothedSpeed);

        lastPosition = currentPosition;
    }
}
