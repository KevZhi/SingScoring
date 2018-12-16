using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStability : MonoBehaviour {

    public MidiInput midiInput;

    public int volume;

    public bool active;

    public float variance;
    public float average;
    public float sum;
    public float squareSum;

    public List<int> list = new List<int>();

    private float timer;

    public GameObject circle;

    public float speed;
    private float x;


    private void Awake()
    {
        midiInput = this.GetComponent<MidiInput>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        volume = midiInput.volume;

        if (active)
        {
            if (timer >= 6)
            {
                timer = 0;
                active = false;

                //print(list.Count);

                foreach (var item in list)
                {
                    //print(item);
                    sum += item;
                }

                average = sum / list.Count;

                foreach (var item in list)
                {
                    squareSum += (item - average) * (item - average);
                }

                variance = squareSum / list.Count;
            }
            else
            {     
                list.Add(volume);
                timer += Time.deltaTime;

                circle.transform.Translate(Vector3.right * speed * Time.deltaTime);
                x = circle.transform.position.x;
                circle.transform.position = new Vector3(x, (float)((volume - 30) * 0.1), 0);


            }

            //print(volume);
        }


    }
}
