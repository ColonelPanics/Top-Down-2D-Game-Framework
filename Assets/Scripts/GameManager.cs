using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ///
    /// Handle settings and information that need to persist
    /// between scenes.
    ///

    // Settings



    // Game Data
    public Vector3 LastTransportPosition;
    public Transform player;




    // Ensure only one instance of game manager
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");

        if (objs.Length > 1 )
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        CheckForPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Functions and things for the manager to use
    /// </summary>
    private void CheckForPlayer()
    {
        if(!GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.Log("Spawning player at origin");
            Instantiate(player, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }
}
