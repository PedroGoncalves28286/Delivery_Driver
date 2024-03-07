using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        if (timer.isGameStarted)
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount, 0);

            if (timer.RemainingTime <= 0)
            {
                Debug.Log("Time's up! Game Over!");
                // Perform game over actions here
            }
        }
        else
        {
            Debug.Log("Waiting for game to start...");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            ScoreManager.Instance.AddScore(5);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
}

