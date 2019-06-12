using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] Paddle p1;
    [SerializeField] float xvect = 2f;
    [SerializeField] float yvect = 15f;
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    AudioSource audioSource;
    Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddleToBallVector = transform.position - p1.transform.position;
        audioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
        else
        {
        }
    }
    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(p1.transform.position.x, p1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    public void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xvect, yvect);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
       
    }

}
