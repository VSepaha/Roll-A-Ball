using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Controller : MonoBehaviour {

    public float timer;
    public GameObject playerOne;
    public GameObject playerTwo;
    private Player1Controller player1;
    private Player2Controller player2;
    public GameObject startButton;
    private StartButton button;

    public Text timerText;
    public Text winText;
    public Text timeRemaining;

    // Use this for initialization
    void Start () {
        timer = 120; // In seconds
        winText.text = "";
        button = startButton.GetComponent<StartButton>();
        timeRemaining.text = "";
    }
	
	// Update is called once per frame
	void Update () {
       
        player1 = playerOne.GetComponent<Player1Controller>();
        player2 = playerTwo.GetComponent<Player2Controller>();
        button = startButton.GetComponent<StartButton>();

        if (button.startPressed == true)
        {
            timer -= Time.deltaTime;
            winText.text = "";
        }
        
        var t = Mathf.Abs(timer);

        int seconds = (int)t % 60;
        int minutes = (int)t / 60;
        var minSec = minutes + ":" + seconds;
        if (seconds < 10)
        {
            minSec = minutes + ":0" + seconds;
        }

        timeRemaining.text = "";
        if (timer <= 60 && timer >= 57)
        {
            timeRemaining.text = "1 Minute Remaining";
        }
        if (timer <= 30 && timer >= 27)
        {
            timeRemaining.text = "30 Seconds Remaining";
        }
        if (timer <= 10 && timer >= 7)
        {
            timeRemaining.text = "10 Seconds Remaining";
        }

        if (timer <= 0)
        {
           if (player1.getScore() > player2.getScore())
            {
                winText.text = "Player 1 Wins!";
            }
            else if (player1.getScore() < player2.getScore())
            {
                winText.text = "Player 2 Wins!";
            }
           else
            {
                winText.text = "It's a Tie!";
            }
            Stop();
        }
        timerText.text = minSec;
    }

    void Stop()
    {
        player1.rb.velocity = Vector3.zero;
        player2.rb.velocity = Vector3.zero;
        player1.stop = true;
        player2.stop = true;
        timer = 0;
    }
}
