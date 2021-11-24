using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float dirX = 2f;
    [SerializeField] float dirY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;

    //state
    Vector2 ballToPaddleDistance;
    bool hasStarted = false;

    // Cashed component reference
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleDistance = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        { 
            LockToPaddle();
            LaunchOnClick();
        }

    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(dirX, dirY);
            hasStarted = true;
        }
    }

    private void LockToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + ballToPaddleDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
             (Random.Range(0, randomFactor), 
            Random.Range(0, randomFactor));
        if (hasStarted)
        {
            myAudioSource.Play();
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (hasStarted)
    //    {
    //        AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
    //        myAudioSource.PlayOneShot(clip);
    //    }
    //}
}
