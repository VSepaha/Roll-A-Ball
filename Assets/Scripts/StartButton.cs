using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour {

    public GameObject timer;
    private Controller time;

    public GameObject playerOne;
    public GameObject playerTwo;
    private Player1Controller player1;
    private Player2Controller player2;

    public GameObject pickUps1;
    public GameObject pickUps2;
    public GameObject pickUps3;
    public GameObject pickUps4;
    public GameObject pickUps5;
    public GameObject pickUps6;
    public GameObject pickUps7;
    public GameObject pickUps8;
    public GameObject pickUps9;
    public GameObject pickUps10;
    public GameObject pickUps11;
    public GameObject pickUps12;
    public GameObject pickUps13;
    public GameObject pickUps14;
    public GameObject pickUps15;
    public GameObject pickUps16;
    public GameObject pickUps17;
    public GameObject pickUps18;
    public GameObject pickUps19;
    public GameObject pickUps20;
    public GameObject pickUps21;
    public GameObject pickUps22;
    public GameObject pickUps23;
    public GameObject pickUps24;
    public GameObject pickUps25;
    public GameObject pickUps26;

    public bool startPressed;
    public Text buttonText;

    // Use this for initialization
    void Start () {
        startPressed = false;
        buttonText.text = "Start";
	}
	
	// Update is called once per frame
	void Update () {
        time = timer.GetComponent<Controller>();
        player1 = playerOne.GetComponent<Player1Controller>();
        player2 = playerTwo.GetComponent<Player2Controller>();
        if (time.timer <= 0)
        {
            buttonText.text = "Start";
        }
    }

    public void OnButtonClick()
    {
        time.timer = 120;
        player1.stop = false;
        player2.stop = false;
        player1.rb.velocity = Vector3.zero;
        player1.setScore(0);
        player1.transform.position = new Vector3(20, 0.5f, 0);
        player2.rb.velocity = Vector3.zero;
        player2.setScore(0);
        player2.transform.position = new Vector3(-20, 0.5f, 0);
        startPressed = true;
        buttonText.text = "Reset";
        time.timeRemaining.text = "";
        player1.colliderText.text = "";
        pickUps1.SetActive(true);
        pickUps2.SetActive(true);
        pickUps3.SetActive(true);
        pickUps4.SetActive(true);
        pickUps5.SetActive(true);
        pickUps6.SetActive(true);
        pickUps7.SetActive(true);
        pickUps8.SetActive(true);
        pickUps9.SetActive(true);
        pickUps10.SetActive(true);
        pickUps11.SetActive(true);
        pickUps12.SetActive(true);
        pickUps13.SetActive(true);
        pickUps14.SetActive(true);
        pickUps15.SetActive(true);
        pickUps16.SetActive(true);
        pickUps17.SetActive(true);
        pickUps18.SetActive(true);
        pickUps19.SetActive(true);
        pickUps20.SetActive(true);
        pickUps21.SetActive(true);
        pickUps22.SetActive(true);
        pickUps23.SetActive(true);
        pickUps24.SetActive(true);
        pickUps25.SetActive(true);
        pickUps26.SetActive(true);
    }
}
