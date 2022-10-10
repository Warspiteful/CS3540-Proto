using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;
    
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Scene transitions 
    // https://youtu.be/CE9VOZivb3I
    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        StartCoroutine(LoadLevel(nextSceneIndex));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // play
        transition.SetTrigger("Start");
        
        // wait
        yield return new WaitForSeconds(transitionTime);

        // load scene
        SceneManager.LoadScene(levelIndex);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            NextLevel();
        }
    }




}
