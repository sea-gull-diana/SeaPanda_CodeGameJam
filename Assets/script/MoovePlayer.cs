using UnityEngine;

public class MoovePlayer : MonoBehaviour
{

    public float moveSpeed;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed =500;
        }
        else
        {
            moveSpeed = 150;
        }
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);

        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        Flip(rb.velocity.x);

        float characterVelocityX = Mathf.Abs(rb.velocity.x);
        float characterVelocityY = Mathf.Abs(rb.velocity.y);

        animator.SetFloat("SpeedX", characterVelocityX);
        animator.SetFloat("SpeedY", rb.velocity.y);
        animator.SetFloat("PositionY", verticalMovement);
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < 0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
