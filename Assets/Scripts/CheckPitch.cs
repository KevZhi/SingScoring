using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckPitch : MonoBehaviour {

    public GameObject gm;
    public MidiInput midiInput;
    public CheckRange checkRange;
    public string scale;
    public string pitch;
    private int flag;
    private float timer;

    private void Awake()
    {
        gm = GameObject.Find("GameManager");
        midiInput = gm.GetComponent<MidiInput>();
        checkRange = gm.GetComponent<CheckRange>();
        scale = this.name;
    }

    void Start () {
		
	}
	
	void Update () {

        pitch = midiInput.pitch.ToString();

        if (pitch != scale)
        {
            flag++;
            if (flag >= 10)
            {
                flag = 0;
                timer = 0;
            }
        }

        if (timer >= 1)
        {
            timer = 0;
            this.GetComponent<SpriteRenderer>().color = Color.green;
            int a = Convert.ToInt32(scale);
            checkRange.tempMax = a;
            checkRange.tempMin = a;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
