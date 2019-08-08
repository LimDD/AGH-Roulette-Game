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

    //Result Text
    public GameObject resulttext_object;
    public Text resulttext_mesh;
    public string resulttext;

    //Betting Values
    public List<int> player_bets;
    public int winning_bet;

    // Start is called before the first frame update
    void Start()
    {
        //Result after the wheel spins
        roulette_value = Random.Range(0, 36);

        //Wheel rotation values
        xAngle = 0;
        yAngle = 0;
        zAngle = -0.75f;

        //Result Text
        resulttext_object = GameObject.Find("Result Text");
        resulttext_mesh = resulttext_object.GetComponent<Text>();
        
        //Player bets
        player_bets.Add(7);
        player_bets.Add(10);
        player_bets.Add(25);
        player_bets.Add(32);

        winner = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Wheel rotation code
        this.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

        if(winner == false)
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
        else if (winner == true)
        {
            Winner(winning_bet);
        }
        else
        {
            Loser();
        }
    }

    //Is called when you win a game and the roulette value is the same as your bet
    public void Winner(int winning_bet)
    {
        resulttext = "You won the round with " + winning_bet + "!!!";
        resulttext_mesh.text = resulttext;
    }

    //Is called when you lose a game and the roulette value is not the same as your bet
    public void Loser()
    {
        resulttext = "You lost the round...";
        resulttext_mesh.text = resulttext;
    }
}
