using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRange : MonoBehaviour {

    public Text rangeText;
    public int Max;
    public int Min;
    public int tempMax;
    public int tempMin;
    public string pitchMax;
    public string pitchMin;
    public int rangecount;

	void Start () {
		
	}
	
	void Update () {

        if (Max == 0 )
        {
            Max = tempMax;
        }
        if (Min == 0)
        {
            Min = tempMin;
        }
        if (tempMax > Max)
        {
            Max = tempMax;
        }
        if (tempMin < Min)
        {
            Min = tempMin;
        }
        if (Max != 0 && Min != 0)
        {
            for (int i = Min; i < Max; i++)
            {
                string objName = i.ToString();
                GameObject obj = GameObject.Find(objName);
                obj.GetComponent<SpriteRenderer>().color = Color.green;
                rangecount = Max - Min + 1;
            }
            pitchMin = CheckPitchName(Min);
            pitchMax = CheckPitchName(Max);
            rangeText.text = "您的音域是 : " + pitchMin + " ~ " + pitchMax + "，共计" + rangecount + "个音";
        }
	}

    public string CheckPitchName(int pitch)
    {
        string pitchName = "";
        string firstName = "";
        string lastName = (Mathf.Floor(pitch / 12) - 1).ToString();

        if (pitch%12 == 0)
        {
            firstName = "C";
        }
        if (pitch % 12 == 1)
        {
            firstName = "C#";
        }
        if (pitch % 12 == 2)
        {
            firstName = "D";
        }
        if (pitch % 12 == 3)
        {
            firstName = "D#";
        }
        if (pitch % 12 == 4)
        {
            firstName = "E";
        }
        if (pitch % 12 == 5)
        {
            firstName = "F";
        }
        if (pitch % 12 == 6)
        {
            firstName = "F#";
        }
        if (pitch % 12 == 7)
        {
            firstName = "G";
        }
        if (pitch % 12 == 8)
        {
            firstName = "G#";
        }
        if (pitch % 12 == 9)
        {
            firstName = "A";
        }
        if (pitch % 12 == 10)
        {
            firstName = "A#";
        }
        if (pitch % 12 == 11)
        {
            firstName = "B";
        }

        pitchName = firstName + lastName;
        return pitchName;
    }
}
