using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorInfo : MonoBehaviour {

    public MidiInput midiinput;
    public GameObject error;

	// Use this for initialization
	void Start () {

	 	midiinput = this.GetComponent<MidiInput>();
		error = GameObject.Find("error");
		error.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(midiinput.pitch==0&&midiinput.volume==0)
		{
			error.SetActive(true);
		}
		if(midiinput.pitch!=0&&midiinput.volume!=0){
       error.SetActive(false);
		}
	}
}

