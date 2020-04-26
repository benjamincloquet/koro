﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    GameObject player;
    Vector3 startPosition;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("More than one instance of GameManager");

        player = GameObject.FindGameObjectWithTag("Player");

        startPosition = GameObject.FindGameObjectWithTag("Start").transform.position;
        player.transform.position = startPosition;
    }

    void InitPlayer()
    {
        player.GetComponent<Player>().Init();
        player.GetComponent<Health>().Init();
        player.transform.position = startPosition;
    }

    public void PlayerDead()
    {
        player.GetComponent<Player>().enabled = false;
        Invoke("InitPlayer", 1f);
    }

    public void EndLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = (currentLevelIndex == SceneManager.sceneCountInBuildSettings - 1) ? 0 : currentLevelIndex + 1;

        MenuManager.instance.GoToScene(nextIndex);
    }
}