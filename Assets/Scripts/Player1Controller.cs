using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player1Controller : MonoBehaviour {

    public Rigidbody rb;
    private bool onGround;
    private int score;
    private Player2Controller player2;
    private StartButton button;

    public GameObject startButton;
    public float speed;
    public float jumpHeight;
    public Text scoreText;
    public GameObject playerTwo;
    public bool stop;
    public Text colliderText;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        button = startButton.GetComponent<StartButton>();
        onGround = true;
        score = 0;
        SetScoreText();
        stop = false;
        button.startPressed = false;
        colliderText.text = "";
	}

    void Update()
    {
        player2 = playerTwo.GetComponent<Player2Controller>();
        button = startButton.GetComponent<StartButton>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (stop == false && button.startPressed == true)
        {
            //Movement with the arrow keys
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(Vector3.right * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(Vector3.left * speed);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.AddForce(Vector3.forward * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(Vector3.back * speed);
            }

            if (Input.GetKey(KeyCode.RightControl) && onGround == true)
            {
                rb.AddForce(Vector3.up * jumpHeight);
                onGround = false;
            }
        }
        

        if (onGround == false && this.transform.position.y == 0.5)
        {
            onGround = true;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            score--;
            SetScoreText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player")){
            if(score > player2.getScore())
            {
                player2.setScore(player2.getScore() - 1);
                colliderText.text = "Last Collision: Player 1 Won";
            }
            if(score < player2.getScore())
            {
                score--;
                SetScoreText();
                colliderText.text = "Last Collision: Player 2 Won";
            }
        }
    }

    public int getScore()
    {
        return score;
    }
    public void setScore(int newScore)
    {
        score = newScore;
        SetScoreText();
    }
    void SetScoreText()
    {
        scoreText.text = "Player One Score = " + score.ToString();
    }
}
