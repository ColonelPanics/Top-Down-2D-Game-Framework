using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string gotoScene;
    public BoxCollider2D entrance;

    private GameObject player;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            if (Input.GetButtonDown("Action"))
            {
                StartCoroutine(LoadScene());
            }
        }
    }

    // Set inRange
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player can enter " + gotoScene);
            inRange = true;
        }
    }

    // Set Out of Range
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    // Load Scene
    IEnumerator LoadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Load scene in background
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gotoScene, LoadSceneMode.Additive);

        // Wait until load is complete
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move player to new scene
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(gotoScene));

        // Unload previous scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
