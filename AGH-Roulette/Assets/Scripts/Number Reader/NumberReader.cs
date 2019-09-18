using UnityEngine;
using System.Collections.Generic;

public class NumberReader : MonoBehaviour {

	public AudioClip[] singleDigits;
	public AudioClip[] tennerDigits;
	public AudioClip[] s_TennerDigits;
	public AudioClip[] non_Digits;
	public AudioClip minus;
	public AudioClip tooLong;
	public AudioClip point;
	AudioClip[] numToRead;

    AudioClip[] ReadNegativeNumber(long negativeNum)
    {
        long posNum = -negativeNum;
        AudioClip[] positiveVer = GetNumberAudio(posNum);
        AudioClip[] output = new AudioClip[positiveVer.Length + 1];
        for (int i = 1; i < output.Length; i++)
        {
            output[i] = positiveVer[i - 1];
        }
        output[0] = minus;
        return output;
    }

    public AudioClip[] GetNumberAudio(long num)
    {
        numToRead = new AudioClip[1];
        if (num < 0)
        {
            return ReadNegativeNumber(num);
        }
        else if (num == 0)
        {
            numToRead[0] = singleDigits[0];
        }
        else if (num < 1000)
        {
            numToRead = ReadThreeDigitsNew(num);
        }
        else if (num == 1000)
        {
            numToRead = new AudioClip[2];
            numToRead[0] = singleDigits[1];
            numToRead[1] = non_Digits[1];
        }
        else if (num == 1000000)
        { // 1 million.
            numToRead = new AudioClip[2];
            numToRead[0] = singleDigits[1];
            numToRead[1] = non_Digits[2];
        }
        else if (num == 1000000000)
        {
            numToRead = new AudioClip[2];
            numToRead[0] = singleDigits[1];
            numToRead[1] = non_Digits[3]; //Billion
        }
        else if (num == 1000000000000)
        {
            numToRead = new AudioClip[2];
            numToRead[0] = singleDigits[1];
            numToRead[1] = non_Digits[4];  //Trillion
        }
        else if (num == 1000000000000000)
        {
            numToRead[0] = non_Digits[5]; //Quadrillion
        }
        else if (num < 1000000000000000)
        { // the number is upto 15 digits. max num = 999,999,999,999,999

            string number = "" + num;

            int numDigit = number.Length;

            int trillionsDigit = 0;
            int billionsDigit = 0;
            int millionsDigit = 0;
            int thousandsDigit = 0;
            int hundredsDigit = 0;

            switch (numDigit)
            {
            case 4:
                thousandsDigit = int.Parse(number.Substring(0, 1));
                hundredsDigit = int.Parse(number.Substring(1, 3));
                break;
            case 5:
                thousandsDigit = int.Parse(number.Substring(0, 2));
                hundredsDigit = int.Parse(number.Substring(2, 3));
                break;
            case 6:
                thousandsDigit = int.Parse(number.Substring(0, 3));
                hundredsDigit = int.Parse(number.Substring(3, 3));
                break;
            case 7:
                millionsDigit = int.Parse(number.Substring(0, 1));
                thousandsDigit = int.Parse(number.Substring(1, 3));
                hundredsDigit = int.Parse(number.Substring(4, 3));
                break;
            case 8:
                millionsDigit = int.Parse(number.Substring(0, 2));
                thousandsDigit = int.Parse(number.Substring(2, 3));
                hundredsDigit = int.Parse(number.Substring(5, 3));
                break;
            case 9:
                millionsDigit = int.Parse(number.Substring(0, 3));
                thousandsDigit = int.Parse(number.Substring(3, 3));
                hundredsDigit = int.Parse(number.Substring(6, 3));
                break;

            case 10:
                billionsDigit = int.Parse(number.Substring(0, 1));
                millionsDigit = int.Parse(number.Substring(1, 3));
                thousandsDigit = int.Parse(number.Substring(4, 3));
                hundredsDigit = int.Parse(number.Substring(7, 3));
                break;

            case 11:
                billionsDigit = int.Parse(number.Substring(0, 2));
                millionsDigit = int.Parse(number.Substring(2, 3));
                thousandsDigit = int.Parse(number.Substring(5, 3));
                hundredsDigit = int.Parse(number.Substring(8, 3));
                break;
            case 12:
                billionsDigit = int.Parse(number.Substring(0, 3));
                millionsDigit = int.Parse(number.Substring(3, 3));
                thousandsDigit = int.Parse(number.Substring(6, 3));
                hundredsDigit = int.Parse(number.Substring(9, 3));
                break;
            case 13:
                trillionsDigit = int.Parse(number.Substring(0, 1));
                billionsDigit = int.Parse(number.Substring(1, 3));
                millionsDigit = int.Parse(number.Substring(4, 3));
                thousandsDigit = int.Parse(number.Substring(7, 3));
                hundredsDigit = int.Parse(number.Substring(10, 3));
                break;
            case 14:
                trillionsDigit = int.Parse(number.Substring(0, 2));
                billionsDigit = int.Parse(number.Substring(2, 3));
                millionsDigit = int.Parse(number.Substring(5, 3));
                thousandsDigit = int.Parse(number.Substring(8, 3));
                hundredsDigit = int.Parse(number.Substring(11, 3));
                break;
            case 15:
                trillionsDigit = int.Parse(number.Substring(0, 3));
                billionsDigit = int.Parse(number.Substring(3, 3));
                millionsDigit = int.Parse(number.Substring(6, 3));
                thousandsDigit = int.Parse(number.Substring(9, 3));
                hundredsDigit = int.Parse(number.Substring(12, 3));
                break;
            }

            AudioClip[] hundreds = ReadThreeDigitsNew(hundredsDigit);
            AudioClip[] thousands = ReadThreeDigitsNew(thousandsDigit);
            AudioClip[] millions = ReadThreeDigitsNew(millionsDigit);
            AudioClip[] billions = ReadThreeDigitsNew(billionsDigit);
            AudioClip[] trillions = ReadThreeDigitsNew(trillionsDigit);

            int length = hundreds.Length + thousands.Length + millions.Length + billions.Length + trillions.Length;

            if (trillions.Length != 0)
            {
                length++;
            }

            if (billions.Length != 0)
            {
                length++;
            }

            if (millions.Length != 0)
            {
                length++;
            }

            if (thousands.Length != 0)
            {
                length++;
            }

            numToRead = new AudioClip[length];

            for (int i = 0; i < trillions.Length; i++)
            {
                numToRead[i] = trillions[i];
            }

            if (trillions.Length != 0)
            { //The number is over 12 digits. 13-15 digits.

                numToRead[trillions.Length] = non_Digits[4]; // Read Trillions. e.g. xxx,000,000,000,000

                for (int i = 0; i < billions.Length; i++)
                {
                    numToRead[i + 1 + trillions.Length] = billions[i];
                }

                if (billions.Length != 0)
                { //e.g. numbers with format such as xxx,xxx,xxx,xxx,xxx
                    numToRead[1 + trillions.Length + billions.Length] = non_Digits[3]; //Read Billions e.g. xxx,xxx,000,000,000 

                    for (int i = 0; i < millions.Length; i++)
                    {
                        numToRead[i + 2 + trillions.Length + billions.Length] = millions[i];
                    }

                    if (millions.Length != 0)
                    { //e.g. xxx,xxx,xxx,xxx,xxx
                        numToRead[millions.Length + billions.Length + trillions.Length + 2] = non_Digits[2]; //Read "Million"

                        for (int i = 0; i < thousands.Length; i++)
                        {
                            numToRead[millions.Length + billions.Length + trillions.Length + 3 + i] = thousands[i];
                        }

                        if (thousands.Length != 0)
                        { //e.g. xxx,xxx,xxx,xxx,xxx
                            numToRead[thousands.Length + millions.Length + billions.Length + trillions.Length + 3] = non_Digits[1]; //Read "Thousand"
                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[thousands.Length + millions.Length + billions.Length + trillions.Length + 4 + i] = hundreds[i];
                            }

                        }
                        else
                        { //e.g. xxx,xxx,xxx,000,xxx

                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[millions.Length + billions.Length + trillions.Length + 3 + i] = hundreds[i];
                            }

                        }

                    }
                    else
                    { //e.g. xxx,xxx,000,xxx,xxx

                        for (int i = 0; i < thousands.Length; i++)
                        {
                            numToRead[billions.Length + trillions.Length + 2 + i] = thousands[i];
                        }

                        if (thousands.Length != 0)
                        { //e.g. xxx,xxx,000,xxx,xxx
                            numToRead[billions.Length + trillions.Length + thousands.Length + 2] = non_Digits[1]; //Read "Thousand".
                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[thousands.Length + billions.Length + trillions.Length + 3 + i] = hundreds[i];
                            }

                        }
                        else
                        { //e.g. xxx,xxx,000,000,xxx

                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[billions.Length + trillions.Length + 2 + i] = hundreds[i];
                            }
                        }

                    }

                }
                else
                { // E.g. numbers with format such as xxx,000,xxx,xxx,xxx
                    for (int i = 0; i < millions.Length; i++)
                    {
                        numToRead[i + 1 + trillions.Length] = millions[i];
                    }

                    if (millions.Length != 0)
                    { //e.g. xxx,000,xxx,xxx,xxx
                        numToRead[millions.Length + trillions.Length + 1] = non_Digits[2]; //Read "Million"

                        for (int i = 0; i < thousands.Length; i++)
                        {
                            numToRead[millions.Length + trillions.Length + 2 + i] = thousands[i];
                        }

                        if (thousands.Length != 0)
                        { //e.g. xxx,000,xxx,xxx,xxx
                            numToRead[thousands.Length + millions.Length + trillions.Length + 2] = non_Digits[1]; //Read "Thousand"

                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[thousands.Length + millions.Length + trillions.Length + 3 + i] = hundreds[i];
                            }

                        }
                        else
                        { // xxx,000,xxx,000,xxx
                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[millions.Length + trillions.Length + 2 + i] = hundreds[i];
                            }
                        }


                    }
                    else
                    { //e.g. xxx,000,000,xxx,xxx

                        for (int i = 0; i < thousands.Length; i++)
                        {
                            numToRead[trillions.Length + 1 + i] = thousands[i];
                        }

                        if (thousands.Length != 0)
                        { //e.g. xxx,000,000,xxx,xxx
                            numToRead[thousands.Length + trillions.Length + 1] = non_Digits[1]; //Read "Thousand"

                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[thousands.Length + trillions.Length + 2 + i] = hundreds[i];
                            }

                        }
                        else
                        {
                            //e.g. xxx,000,000,000,xxx
                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[trillions.Length + 1 + i] = hundreds[i];
                            }
                        }

                    }

                }

            }
            else
            { //The number is over 9 digits. 10-12 digits. e.g. 000,xxx,xxx,xxx,xxx

                for (int i = 0; i < billions.Length; i++)
                {
                    numToRead[i] = billions[i];
                }

                if (billions.Length != 0)
                { //e.g. xxx,xxx,xxx,xxx
                    numToRead[billions.Length] = non_Digits[3];//Read "Billion"

                    for (int i = 0; i < millions.Length; i++)
                    {
                        numToRead[billions.Length + 1 + i] = millions[i];
                    }

                    if (millions.Length != 0)
                    { //e.g. xxx,xxx,xxx,xxx
                        numToRead[billions.Length + millions.Length + 1] = non_Digits[2]; //Read "Million"

                        for (int i = 0; i < thousands.Length; i++)
                        {
                            numToRead[billions.Length + millions.Length + 2 + i] = thousands[i];
                        }

                        if (thousands.Length != 0)
                        { //e.g. xxx,xxx,xxx,xxx

                            numToRead[billions.Length + millions.Length + thousands.Length + 2] = non_Digits[1]; //Read Thousand

                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[billions.Length + millions.Length + thousands.Length + 3 + i] = hundreds[i];
                            }
                        }
                        else
                        { //e.g. xxx,xxx,000,xxx
                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[billions.Length + millions.Length + 2 + i] = hundreds[i];
                            }
                        }

                    }
                    else
                    { //e.g. xxx,000,xxx,xxx
                        for (int i = 0; i < thousands.Length; i++)
                        {
                            numToRead[billions.Length + 1 + i] = thousands[i];
                        }

                        if (thousands.Length != 0)
                        { //e.g. xxx,xxx,xxx,xxx
                            numToRead[billions.Length + thousands.Length + 1] = non_Digits[1]; //Read Thousand

                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[billions.Length + thousands.Length + 2 + i] = hundreds[i];
                            }
                        }
                        else
                        { //e.g. xxx,xxx,000,xxx
                            for (int i = 0; i < hundreds.Length; i++)
                            {
                                numToRead[billions.Length + 1 + i] = hundreds[i];
                            }
                        }
                    }

                }
                else
                { // 000,xxx,xxx,xxx
                    for (int i = 0; i < millions.Length; i++)
                    {
                        numToRead[i] = millions[i];
                    }

                    if (millions.Length != 0)
                    {

                        numToRead[millions.Length] = non_Digits[2]; //millions

                        for (int i = 0; i < thousands.Length; i++)
                        {
                            numToRead[i + 1 + millions.Length] = thousands[i];
                        }

                        if (thousands.Length != 0)
                        {

                            numToRead[thousands.Length + millions.Length + 1] = non_Digits[1]; //Thousand

                            for (int i = 0; i < hundreds.Length; i++)
                            { //Last 3 digits.
                                numToRead[thousands.Length + millions.Length + 2 + i] = hundreds[i];
                            }
                        }
                        else
                        {
                            for (int i = 0; i < hundreds.Length; i++)
                            { //Last 3 digits.
                                numToRead[thousands.Length + millions.Length + 1 + i] = hundreds[i];
                            }
                        }

                    }
                    else
                    { //The number is less than 7 digits.
                        for (int i = 0; i < thousands.Length; i++)
                        {
                            numToRead[i] = thousands[i];
                        }

                        if (thousands.Length != 0)
                        {

                            numToRead[thousands.Length] = non_Digits[1]; //Thousand

                            for (int i = 0; i < hundreds.Length; i++)
                            { //Last 3 digits.
                                numToRead[thousands.Length + 1 + i] = hundreds[i];
                            }
                        }
                        else
                        {
                            for (int i = 0; i < hundreds.Length; i++)
                            { //Last 3 digits.
                                numToRead[i] = hundreds[i];
                            }
                        }
                    }
                }
            }
        }
        else
        {
            return null; //The number is out side the range.
        }
        return numToRead;
    }
    //------------------------------- NEW VOICE ------------------------

    AudioClip[] ReadThreeDigitsNew(long num)
    {
        string number = "" + num;

        numToRead = new AudioClip[1];
        if (num == 0)
        {
            numToRead = new AudioClip[0];
        }
        else if (num <= 9)
        {
            numToRead[0] = singleDigits[num];
        }
        else if (num == 10)
        {
            numToRead[0] = tennerDigits[0];

        }
        else if (num < 20)
        { //This is when the numbers are from 11 to 19 inclusive.
            numToRead[0] = s_TennerDigits[num - 11];

        }
        else if (num < 100)
        { //This is when the numbers are from 20 to 99 inclusive. 
          //First digit.
            int firstDigit = int.Parse(number.Substring(0, 1));

            //Second digit.

            int secondDigit = int.Parse(number.Substring(1, 1));

            if (secondDigit == 0)
            {
                numToRead[0] = tennerDigits[firstDigit - 1];

            }
            else
            {
                numToRead = new AudioClip[2];
                numToRead[0] = tennerDigits[firstDigit - 1];
                numToRead[1] = singleDigits[secondDigit];
            }

        }
        else if (num == 100)
        {
            numToRead = new AudioClip[2];
            numToRead[0] = singleDigits[1];
            numToRead[1] = non_Digits[0];

        }
        else if (num < 1000)
        { //This is when the numbers are from 101 to 999 inclusive.

            //First Digit
            int firstDigit = int.Parse(number.Substring(0, 1));

            //Second Digit
            int secondDigit = int.Parse(number.Substring(1, 1));

            //Third Digit
            int thirdDigit = int.Parse(number.Substring(2, 1));

            if (secondDigit == 0)
            { // for the numbers 101 ... 109, 200 ... 209, ... , 900... 909.

                if (thirdDigit == 0)
                { //For the numbers 200, 300, 400 ... 900
                    numToRead = new AudioClip[2];
                    numToRead[0] = singleDigits[firstDigit];
                    numToRead[1] = non_Digits[0]; //hundred

                }
                else
                { // For the numbers 101 ... 109, 201 ... 209, 301 ... 309, ... ,901 ... 909
                    numToRead = new AudioClip[3];
                    numToRead[0] = singleDigits[firstDigit];
                    numToRead[1] = non_Digits[0]; //hundred
                    numToRead[2] = singleDigits[thirdDigit];
                }

            }
            else if (secondDigit == 1)
            { //for the numbers such as 110-119, 210-219, 310-319 etc.
                if (thirdDigit == 0)
                { // 110, 210, 310 ... 910
                    numToRead = new AudioClip[3];
                    numToRead[0] = singleDigits[firstDigit]; //first digit
                    numToRead[1] = non_Digits[0]; //hundred
                    numToRead[2] = tennerDigits[0]; // 10

                }
                else
                { // 111 ... 119, 211 ... 219, ... 919
                    numToRead = new AudioClip[3];
                    numToRead[0] = singleDigits[firstDigit];
                    numToRead[1] = non_Digits[0]; //hundred
                    numToRead[2] = s_TennerDigits[thirdDigit - 1]; //special digits e.g. 11, 12					
                }

            }
            else
            { //The numbers upto 999 inclusive that are not above.

                if (thirdDigit == 0)
                {
                    numToRead = new AudioClip[3];
                    numToRead[0] = singleDigits[firstDigit]; //First digit
                    numToRead[1] = non_Digits[0]; //Hundred
                    numToRead[2] = tennerDigits[secondDigit - 1]; //Second digit.
                }
                else
                {
                    numToRead = new AudioClip[4];

                    numToRead[0] = singleDigits[firstDigit]; //First digit
                    numToRead[1] = non_Digits[0]; //Hundred
                    numToRead[2] = tennerDigits[secondDigit - 1]; //Second digit.
                    numToRead[3] = singleDigits[thirdDigit]; //Third digit.
                }

            }

        }

        return numToRead;
    }

    public AudioClip[] GetNumberAudio(float num)
    {
        List<AudioClip> output = new List<AudioClip>();

        string number = num.ToString("F2"); // Rounds the number to 2 decimal places.
        int numberBeforePoint = int.Parse(number.Substring(0, number.Length - 3));

        AudioClip[] clips = GetNumberAudio(numberBeforePoint);

        for (int i = 0; i < clips.Length; i++)
        {
            output.Add(clips[i]);
        }

        int numberAfterPoint = int.Parse(number.Substring(number.Length - 2, 2));

        if (numberAfterPoint == 0)
        {
            return output.ToArray();
        }

        output.Add(point);

        clips = GetNumberAudio(numberAfterPoint);

        for (int i = 0; i < clips.Length; i++)
        {
            output.Add(clips[i]);
        }

        return output.ToArray();

    }

}

