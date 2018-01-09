using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour {

    string sceneName;
    public GameObject player;
    private static GameObject playerInstance;
    bool isPaused;
    public GameObject pauseScreen;
    private static bool gameStartUp = true;

    private void Awake()
    {
        DontDestroyOnLoad(player);

        if (playerInstance == null)
        {
            playerInstance = player;
        }
        else
        {
            DestroyObject(player);
        }
        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            playerInstance.GetComponent<Transform>().position = new Vector2(100, 100);
            playerInstance.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            playerInstance.GetComponent<Transform>().position = new Vector2(0, -1.5f);
            playerInstance.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (gameStartUp)
        {
            gameStartUp = false;
            loadGame();
            Debug.Log("save loaded");
        }
    }

	// Use this for initialization
	void Start () {
        sceneName = SceneManager.GetActiveScene().name;
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            reloadScene();
        }
        if (Input.GetKeyDown(KeyCode.P) && !sceneName.Equals("Menu"))
        {
            pause();
        }
	}

    public void goToScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    void reloadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    void pause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        } else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }

    public void saveGame()
    {
        Game.current = new global::Game();
        saveData.Save();
    }

    public void loadGame()
    {
        saveData.Load();
        playerController con = player.GetComponent<playerController>();
        int num;
        if (saveData.savedGame != null)
        {
            num = saveData.savedGame.candyNum;
        } else
        {
            num = 0;
        }
        con.setCandy(num);
    }

    public void resetGame()
    {
        player.GetComponent<playerController>().setCandy(0);
        Game.current = new global::Game();
        saveData.Save();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
