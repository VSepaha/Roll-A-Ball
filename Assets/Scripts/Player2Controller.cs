using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Controller : MonoBehaviour
{

    public Rigidbody rb;
    private bool onGround;
    private int score;
    private Vector3 movement;
    private StartButton button;
    private Player2Controller player1;

    public GameObject playerOne;
    public GameObject startButton;
    public float speed;
    public float jumpHeight;
    public Text scoreText;
    public bool stop;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        button = startButton.GetComponent<StartButton>();
        onGround = true;
        score = 0;
        SetScoreText();
        stop = false;
        button.startPressed = false;
    }

    void Update()
    {
        player1 = playerOne.GetComponent<Player2Controller>();
        button = startButton.GetComponent<StartButton>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stop == false && button.startPressed == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector3.right * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector3.left * speed);
            }
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector3.forward * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(Vector3.back * speed);
            }

            if (Input.GetKey(KeyCode.Q) && onGround == true)
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
        scoreText.text = "Player Two Score = " + score.ToString();
    }
}
