using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteDelivery = 330f; // Adjust according to delivery time limit
    [SerializeField] float timeToStartGame = 3f; // Adjust according to time before game starts in the main menu

    public bool isGameStarted = false;
    public float fillFraction;

    float timerValue;

    public float RemainingTime
    {
        get { return timerValue; }
    }

    // Method to cancel/reset the timer
    public void CancelTimer()
    {
        timerValue = 0;
    }

    void Update()
    {
        Updatetimer();
    }

    void Updatetimer()
    {
        timerValue -= Time.deltaTime;

        if (!isGameStarted)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToStartGame;
            }
            else
            {
                isGameStarted = true;
                timerValue = timeToCompleteDelivery;
                // In this case, you might want to trigger the start of the game.
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteDelivery;
            }
            else
            {
                // Handle what happens when the time to complete the delivery runs out.
            }
        }

        Debug.Log((isGameStarted ? "Game Started" : "Waiting to Start") + ": " + timerValue + " = " + fillFraction);
    }
}

