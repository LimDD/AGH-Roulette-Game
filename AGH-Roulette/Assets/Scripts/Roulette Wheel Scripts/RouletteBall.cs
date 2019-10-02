using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBall : MonoBehaviour
{
    //The Roulette Wheel
    public GameObject rouletteWheel;
    public GameObject ball;
    public RouletteWheelSpin wheelScript;

    public AudioSource narrate;

    //Roulette Wheel result
    public int rouletteValue;

    //Where the ball starts spinning from
    public bool startSpin;
    public float startRotation;

    //Ball rotation values
    public float xAngle, yAngle, zAngle;
    
    //Spin Timer from other script
    public int spinTimer;
    public bool wheelSpinning;

    // Start is called before the first frame update
    void Start()
    {
        rouletteWheel = GameObject.Find("Roulette Wheel");
        ball.SetActive(false);
        wheelScript = rouletteWheel.GetComponent<RouletteWheelSpin>();
        startSpin = true;
        
        //Ball rotation values
        xAngle = 0;
        yAngle = 0;
        zAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {

        rouletteValue = wheelScript.rouletteValue;
        spinTimer = wheelScript.spinTimer;
        wheelSpinning = wheelScript.wheelSpinning;

        if (startSpin)
        {
            startSpin = false;
            startRotation = wheelScript.SetBallPosition();
            transform.Rotate(xAngle, yAngle, startRotation, Space.Self);
        }
  
        if (!narrate.isPlaying)
        {

            if (spinTimer < 240)
            {
                zAngle = 4.0f;

                //Wheel no spinning rotation code
                transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
            }
            else if (spinTimer == 240 || spinTimer < 300)
            {
                //Wheel no spinning rotation code
                transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

                zAngle -= 0.066f;
            }

            if (!wheelSpinning)
            {
                zAngle = 0.0f;
                transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
            }

        }
       
    }
}
