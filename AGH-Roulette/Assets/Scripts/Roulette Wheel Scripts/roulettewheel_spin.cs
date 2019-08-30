using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class roulettewheel_spin : MonoBehaviour
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

    //Betting Values
    public List<int> playerBets;
    public int winningBet;

    public ButtonState bS;

    // Is called when a player makes their bet
    public void PlayerBets()
    {

    }

    //Check results against hardcoded player bets
    private void CheckBets()
    {
        if (winner == false)
        {
            for (int i = 0; i < (playerBets.Count - 1); i++)
            {
                if (playerBets[i] == rouletteValue)
                {
                    winningBet = playerBets[i];
                    winner = true;
                }
            }
        }

        CheckIfWinner();
    }

    //Checks if the result is the same
    private void CheckIfWinner()
    {
        if (winner == true)
        {
            Winner(winningBet);
        }
        else
        {
            Loser(rouletteValue);
        }
        //This works when starting from the roulette wheel scene but no where else
        //bS.ShowButton();
    }

    //Is called when you win a game and the roulette value is the same as your bet
    private void Winner(int winning_bet)
    {
        resulttext_component.text = "You won the round with " + winning_bet + "!!!";
    }

    //Is called when you lose a game and the roulette value is not the same as your bet
    private void Loser(int roulette_value)
    {
        resulttext_component.text = "The ball landed on " + roulette_value + " meaning you lost this round...";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        winner = false;

        bS = FindObjectOfType<ButtonState>();

        //Result after the wheel spins
        rouletteValue = Random.Range(0, 36);

        //Wheel rotation values
        xAngle = 0;
        yAngle = 0;
        zAngle = 0;
        spinTimer = 0;
        wheelSpinning = true;

        //Player bets
        PlayerBets();
    }

    // Update is called once per frame
    void Update()
    {
        if (wheelSpinning == true)
        {
            if(spinTimer < 60)
            {
                //Wheel no spinning rotation code
                this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

                spinTimer += 1;
                zAngle -= 0.05f;
            }
            else if(spinTimer == 60 || spinTimer < 240)
            {
                //Wheel no spinning rotation code
                this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

                spinTimer += 1;
            }
            else if(spinTimer == 240 || spinTimer < 300)
            {
                //Wheel no spinning rotation code
                this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

                spinTimer += 1;
                zAngle += 0.04f;

                if(spinTimer == 300)
                {
                    wheelSpinning = false;
                }
            }
        }
        

        if(wheelSpinning == false)
        {
            this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
            CheckBets();
        }
    }
}
