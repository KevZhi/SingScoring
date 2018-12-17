using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    private void Awake()
    {
    Screen.SetResolution(800, 480, false);
    }

    void Start () {
		 
	}

	void Update () {
		
	}

    public void Refresh()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToScene()
    {
        string sceneName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(sceneName);
    }
}
