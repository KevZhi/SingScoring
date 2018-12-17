using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckStability : MonoBehaviour
{
    public MidiInput midiInput;
    public int volume;
    public bool active;
    public bool once = true;
    public float variance;
    public float average;
    public float sum;
    public float squareSum;
    public List<int> list = new List<int>();
    private float timer;
    private float startTimer;
    public Text varianceText;
    public GameObject circle;
    public float speed;
    private float x;
    private int flag;

    private void Awake()
    {
        midiInput = this.GetComponent<MidiInput>();
    }

    void Start()
    {

    }

    void Update()
    {
        volume = midiInput.volume;
        if (once)
        {
            if (volume >= 70)
            {
                flag = 0;
            }
            else
            {
                if (flag >= 60)
                {
                    startTimer = 0;
                }
                flag++;
            }
            if (startTimer >= 2)
            {
                startTimer = 0;
                active = true;
                once = false;
            }
            else
            {
                startTimer += Time.deltaTime;
            }
        }
        if (active)
        {
            if (timer >= 6)
            {
                timer = 0;
                active = false;
                foreach (var item in list)
                {
                    sum += item;
                }
                average = sum / list.Count;
                foreach (var item in list)
                {
                    squareSum += (item - average) * (item - average);
                }
                variance = squareSum / list.Count;
                CheckScore((int)variance);
            }
            else
            {
                list.Add(volume);
                timer += Time.deltaTime;
                circle.transform.Translate(Vector3.right * speed * Time.deltaTime);
                x = circle.transform.position.x;
                circle.transform.position = new Vector3(x, (float)((volume - 30) * 0.03), 0);
            }
        }
    }

    public void CheckScore(int number)
    {
        if (number <= 8)
        {
            varianceText.text = "发声稳定性优秀，抖动为" + number;
            varianceText.color = Color.green;
        }
        if (number > 8 && number <= 16)
        {
            varianceText.text = "发声稳定性良好，抖动为" + number;
            varianceText.color = new Color(0,0.8f,08f);
        }
        if (number > 16 && number <= 32)
        {
            varianceText.text = "发声稳定性一般，抖动为" + number;
            varianceText.color = new Color(0.8f,0.8f,0);
        }
        if (number > 32 && number <= 64)
        {
            varianceText.text = "发声稳定性较差，抖动为" + number;
            varianceText.color = new Color(0.7f,0,0.7f);
        }
        if (number > 64)
        {
            varianceText.text = "发声稳定性极差，抖动为" + number;
            varianceText.color = Color.red;
        }
    }
}