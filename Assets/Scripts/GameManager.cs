using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public CheckStability cs;

    private void Awake()
    {
        cs = this.GetComponent<CheckStability>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Refresh()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StabilityStart()
    {
        GameObject startBtn = GameObject.Find("Start");
        startBtn.SetActive(false);
        cs.active = true;
    }
}
