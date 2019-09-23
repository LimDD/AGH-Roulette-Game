using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteBall : MonoBehaviour
{
    //The Roulette Wheel
    public GameObject rouletteWheel;
    public RouletteWheelSpin wheelScript;

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

        if (startSpin && spinTimer == 0)
        {
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
                    startRotation = 101;
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
                    startRotation = 82;
                    break;
                case 35:
                    startRotation = 219;
                    break;
                case 36:
                    startRotation = 62;
                    break;
            }

            startSpin = false;
            transform.Rotate(xAngle, yAngle, startRotation, Space.Self);
        }
        
        if (spinTimer < 240)
        {
            zAngle = 6.5f;

            //Wheel no spinning rotation code
            transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        }
        else if (spinTimer == 240 || spinTimer < 300)
        {
            //Wheel no spinning rotation code
            transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

            zAngle -= 0.1f;
        }

        if (!wheelSpinning)
        {
            zAngle = -0.0f;
            transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        }
    }
}
