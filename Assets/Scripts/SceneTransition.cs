using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : CollisionBase
{
    public string gotoScene;
    public BoxCollider2D entrance;
    public Vector3 spawnPosition;

    private GameObject player;

    public override void DoThing() {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(LoadScene());
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
        player.transform.position = spawnPosition;
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(gotoScene));

        // Unload previous scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
