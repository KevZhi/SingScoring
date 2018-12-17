using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System;

public class MidiInput : MonoBehaviour
{

    public int pitch;
    public int volume;

    void Start()
    {

    }

    void Update()
    {
        float pit = MidiMaster.GetKnob(1);
        pit = pit * 128;
        pitch = (int)pit + 1;
   
        float vol = MidiMaster.GetKnob(2);
        vol = vol * 128;
        volume = (int)vol;
    }
}