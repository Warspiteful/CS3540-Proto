using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{




public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void StartGame()
    {
        SceneManager.LoadScene("Area0");
        // Put the player at the start of the map
        player.transform.position = new Vector3(-45f, 0.5f, -13f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {


        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            NextLevel();
        }
    }




}
