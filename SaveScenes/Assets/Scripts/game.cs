using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game
{

    public static Game current;
    public int candyNum;

    public Game()
    {
        candyNum = GameObject.Find("Player").GetComponent<playerController>().checkCandy();
    }

}
