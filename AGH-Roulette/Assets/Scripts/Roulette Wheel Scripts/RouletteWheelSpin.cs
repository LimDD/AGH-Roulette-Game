using UnityEngine.UI;
using UnityEngine;

public class RouletteWheelSpin : MonoBehaviour
{
    //Result of the bet compared to the roulette wheel value
    public bool winner;

    //Result after the wheel spins
    public int rouletteValue;
        
    //Wheel rotation values
    public float xAngle, yAngle, zAngle;
    public int spinTimer;
    public bool wheelSpinning;

    //Result Text
    public Text resulttext_component;
    public string resulttext;

    bool check;
    SpinResult sR;
    public Button back;
    public AudioSource narrate;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        sR = FindObjectOfType<SpinResult>();

        winner = false;
        check = false;

        //Result after the wheel spins
        rouletteValue = 23;
        //rouletteValue = Random.Range(0, 36);

        //Wheel rotation values
        xAngle = 0;
        yAngle = 0;
        zAngle = 0;
        spinTimer = 0;
        wheelSpinning = true;
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!narrate.isPlaying)
        {
            if (spinTimer == 4)
            {
                ball.SetActive(true);
            }

            if (wheelSpinning)
            {
                if (spinTimer < 60)
                {
                    //Wheel no spinning rotation code
                    transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

                    spinTimer += 1;
                    zAngle -= 0.05f;
                }
                else if (spinTimer == 60 || spinTimer < 240)
                {
                    //Wheel no spinning rotation code
                    this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

                    spinTimer += 1;
                }
                else if (spinTimer == 240 || spinTimer < 300)
                {
                    //Wheel no spinning rotation code
                    this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

                    spinTimer += 1;
                    zAngle += 0.04f;

                    if (spinTimer == 300)
                    {
                        wheelSpinning = false;
                    }
                }
            }

            if (!wheelSpinning)
            {
                zAngle = 0.0f;
                transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

                if (!check)
                {
                    check = true;
                    sR.CheckIfWinner();
                }
            }
        }
    }

    public int SetBallPosition()
    {
        int startRotation = 0;

        switch (rouletteValue)
        {
            case 0:
                startRotation = 190;
                break;
            case 1:
                startRotation = 326;
                break;
            case 2:
                startRotation = 131;
                break;
            case 3:
                startRotation = 209;
                break;
            case 4:
                startRotation = 150;
                break;
            case 5:
                startRotation = 5;
                break;
            case 6:
                startRotation = 92;
                break;
            case 7:
                startRotation = 248;
                break;
            case 8:
                startRotation = 34;
                break;
            case 9:
                startRotation = 287;
                break;
            case 10:
                startRotation = 15;
                break;
            case 11:
                startRotation = 53;
                break;
            case 12:
                startRotation = 228;
                break;
            case 13:
                startRotation = 72;
                break;
            case 14:
                startRotation = 306;
                break;
            case 15:
                startRotation = 170;
                break;
            case 16:
                startRotation = 345;
                break;
            case 17:
                startRotation = 111;
                break;
            case 18:
                startRotation = 267;
                break;
            case 19:
                startRotation = 160;
                break;
            case 20:
                startRotation = 316;
                break;
            case 21:
                startRotation = 140;
                break;
            case 22:
                startRotation = 277;
                break;
            case 23:
                startRotation = 24;
                break;
            case 24:
                startRotation = 355;
                break;
            case 25:
                startRotation = 121;
                break;
            case 26:
                startRotation = 199;
                break;
            case 27:
                startRotation = 82;
                break;
            case 28:
                startRotation = 238;
                break;
            case 29:
                startRotation = 258;
                break;
            case 30:
                startRotation = 43;
                break;
            case 31:
                startRotation = 296;
                break;
            case 32:
                startRotation = 180;
                break;
            case 33:
                startRotation = 335;
                break;
            case 34:
                startRotation = 101;
                break;
            case 35:
                startRotation = 219;
                break;
            case 36:
                startRotation = 62;
                break;
        }

        startRotation -= 7;

        return startRotation;
    }

    //Is called when you win a game and the roulette value is the same as your bet
    //Changed int winning_bet to roulette_value
    public void Winner(int roulette_value)
    {
        //resulttext_component.text = "You won the round with " + winning_bet + "!!!";
        resulttext_component.text = "The ball landed on " + roulette_value + "! You have won!!";
        ShowButtons();
    }

    //Is called when you lose a game and the roulette value is not the same as your bet
    public void Loser(int roulette_value)
    {
        resulttext_component.text = "The ball landed on " + roulette_value + " meaning you lost this round...";
        ShowButtons();
    }

    public void ShowButtons()
    {
        back.interactable = true;
    }
}

