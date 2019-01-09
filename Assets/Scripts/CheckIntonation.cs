using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CheckIntonation : MonoBehaviour {

    public bool active = true;
    public MidiInput midiInput;
    public int number;
    public AudioSource audioSource;
    public AudioClip clip;
    public GameObject text;
    public GameObject score;
    public string pitch;
    public bool start;
    public float startTimer;
    public bool collect;
    public float collectTimer;
    public bool next;
    public float nextTimer;
    public int flagFalse;
    public int flagTrue;
    public int finalScore;
    public List<string> randomList = new List<string>();

    private void Awake()
    {
        midiInput = this.GetComponent<MidiInput>();
    }

    void Start () {
        GetRandoms(48, 60);
        audioSource = this.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            active = false;
            if (number < randomList.Count)
            {
                pitch = randomList[number];
                
                LoadAudioOnce(pitch);
                start = true;
            }
            else
            {
                score.SetActive(true);
                score.GetComponent<Text>().text = "总分\n" + finalScore + "/12";
                if (finalScore >= 11)
                {
                    score.GetComponent<Text>().text += "\n您的音准很好";
                    score.GetComponent<Text>().color = Color.green;
                }
                if (finalScore < 11 && finalScore >=8)
                {
                    score.GetComponent<Text>().text += "\n您的音准良好";
                    score.GetComponent<Text>().color = new Color(0,0.8f,08f);
                }
                if (finalScore < 8 && finalScore >= 6)
                {
                    score.GetComponent<Text>().text += "\n您的音准一般";
                    score.GetComponent<Text>().color = new Color(0.8f,0.8f,0);
                }
                if (finalScore < 6 && finalScore >= 4)
                {
                    score.GetComponent<Text>().text += "\n您的音准\n有问题";
                    score.GetComponent<Text>().color = new Color(0.7f,0,0.7f);
                }
                if (finalScore < 4)
                {
                    score.GetComponent<Text>().text += "\n您的音准\n有严重问题";
                    score.GetComponent<Text>().color = Color.red;
                }
            }
        }

        if (start)
        {
            if (startTimer >= 2.5)
            {
                startTimer = 0;
                start = false;
                collect = true;
                GameObject.Find(pitch).GetComponent<SpriteRenderer>().color = Color.yellow;
                GameObject.Find(pitch + "Text").GetComponent<Text>().color = Color.yellow;
            }
            else
            {
                startTimer += Time.deltaTime;
            }
        }

        if (collect)
        {
            if (collectTimer >= 2)
            {
                collectTimer = 0;
                collect = false;

                float result = (float)flagTrue / ((float)flagFalse + (float)flagTrue);

                GameObject obj = GameObject.Find(pitch);

                GameObject.Find(pitch + "Text").GetComponent<Text>().text += " " + (int)(result * 100);
                flagFalse = 0;
                flagTrue = 0;
                next = true;
                if (result >= 0.7)
                {
                    obj.GetComponent<SpriteRenderer>().color = Color.green;
                    GameObject.Find(pitch + "Text").GetComponent<Text>().color = Color.green;
                    finalScore++;
                }
                else
                {
                    obj.GetComponent<SpriteRenderer>().color = Color.red;
                    GameObject.Find(pitch + "Text").GetComponent<Text>().color = Color.red;
                }
            }
            else
            {
                collectTimer += Time.deltaTime;
                int stdpitch=Convert.ToInt32(pitch);
                float standard = (float)stdpitch;
                if ((midiInput.fpitch>=standard-0.2) && (midiInput.fpitch<=standard+0.2))
                {
                    flagTrue++;
                }
                if ((midiInput.fpitch<(standard-0.2)) || (midiInput.fpitch>standard+0.2))
                {
                    flagFalse++;
                }
            }
        }

        if (next)
        {

            if (nextTimer>=0.5)
            {
                nextTimer = 0;
                next = false;
                number++;
                active = true;
            }
            else
            {
                nextTimer += Time.deltaTime;
            }
        }
    }

    public void GetRandoms(int min, int max)
    {
        while (randomList.Count < (max - min))
        {
            int nValue = UnityEngine.Random.Range(min, max);

            if (!randomList.Contains(nValue.ToString()))
            {
                randomList.Add(nValue.ToString());
            }
        }
    }

    public void LoadAudioOnce(string audioName)
    {
        clip = Resources.Load("Audio/" + audioName) as AudioClip;
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void StartActive()
    {
        active = true;
        text.SetActive(true);
        GameObject.Find("play").SetActive(false);
    }

}
