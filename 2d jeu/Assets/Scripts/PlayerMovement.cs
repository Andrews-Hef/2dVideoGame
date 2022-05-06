using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isJumping;
    public bool isGrounded;
    public Transform GroundCheckLeft;
    public Transform GroundCheckRight;

    public Rigidbody2D Rb;
    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer SpriteRenderer;
    private float horizontalMovement;
   
        void Update()
    {

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }



        Flip(Rb.velocity.x);

        //recuperer la valeur absolue de character velocity(juste la valeur pas les signes) 
        float characterVelocity = Mathf.Abs(Rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

    }
    void FixedUpdate()
    {
        //permet de verifier si le personnage est au sol pour pas qu'il y ai de double saut woula
        isGrounded = Physics2D.OverlapArea(GroundCheckLeft.position, GroundCheckRight.position);

        MovePlayer(horizontalMovement);
    }
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, Rb.velocity.y);
        //le mouvement du personnage
        Rb.velocity = Vector3.SmoothDamp(Rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {

            Rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
    //faire tourner le personnage quand il change de direction 
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            SpriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            SpriteRenderer.flipX = true;
        }
    }
}
