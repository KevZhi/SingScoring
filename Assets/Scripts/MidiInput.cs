using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System;

public class MidiInput : MonoBehaviour
{

    public int pitch;
    public int volume;
    public int cent;
    public float fpitch;

    void Start()
    {

    }

    void Update()
    {
        float pit = MidiMaster.GetKnob(1);
        pit = pit * 128;
        pitch = (int)pit;
   
        float vol = MidiMaster.GetKnob(2);
        vol = vol * 128;
        volume = (int)vol;

        float cen = MidiMaster.GetKnob(3);
        cen = cen * 128;
        cent = (int)cen;
    
        fpitch = pitch + (float)cent / 100;;
    }
}