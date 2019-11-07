using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class The8PuzzleHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void The8PuzzleSpawn()
    {
        if (!SceneManager.GetSceneByName("The8Puzzle").isLoaded)
        {
            SceneManager.LoadScene("The8Puzzle", LoadSceneMode.Additive);    
        }
        else
        {
            SceneManager.UnloadSceneAsync("The8Puzzle");
        }
    }
}