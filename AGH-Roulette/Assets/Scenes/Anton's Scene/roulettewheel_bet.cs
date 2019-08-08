using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class roulettewheel_bet : MonoBehaviour
{
    //Result of the bet compared to the roulette wheel value
    public bool winner;

    //Result after the wheel spins
    public int roulette_value;
    
    //Wheel rotation values
    public float xAngle, yAngle, zAngle;
    public int spintimer;
    public bool wheelspinning;

    //Result Text
    public Text resulttext_component;
    public string resulttext;

    //Betting Values
    public List<int> player_bets;
    public int winning_bet;

    //Check results against hardcoded player bets
    private void CheckBets()
    {
        if (winner == false)
        {
            for (int i = 0; i < (player_bets.Count - 1); i++)
            {
                if (player_bets[i] == roulette_value)
                {
                    winning_bet = player_bets[i];
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
            Winner(winning_bet);
        }
        else
        {
            Loser(roulette_value);
        }
    }

    //Is called when you win a game and the roulette value is the same as your bet
    private void Winner(int winning_bet)
    {
        resulttext_component.text = "You won the round with " + winning_bet + "!!!";
    }

    //Is called when you lose a game and the roulette value is not the same as your bet
    private void Loser(int roulette_value)
    {
        resulttext_component.text = "The wheel landed on " + roulette_value + " meaning you lost this round...";
    }

    // Start is called before the first frame update
    void Start()
    {
        winner = false;

        //Result after the wheel spins
        roulette_value = Random.Range(0, 36);

        //Wheel rotation values
        xAngle = 0;
        yAngle = 0;
        zAngle = 0;
        spintimer = 0;
        wheelspinning = true;

        //Player bets
        player_bets.Add(7);
        player_bets.Add(10);
        player_bets.Add(25);
        player_bets.Add(32);
    }

    // Update is called once per frame
    void Update()
    {
        if(spintimer < 60)
        {
            //Wheel no spinning rotation code
            this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

            spintimer += 1;
            zAngle -= 0.2f;
        }
        else if(spintimer == 60 || spintimer < 240)
        {
            //Wheel no spinning rotation code
            this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

            spintimer += 1;
        }
        else if(spintimer == 240 || spintimer < 300)
        {
            //Wheel no spinning rotation code
            this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

            spintimer += 1;
            zAngle += 0.2f;

            if(spintimer == 300)
            {
                wheelspinning = false;
            }
        }

        if(wheelspinning == false)
        {
            CheckBets();
        }
    }
}
