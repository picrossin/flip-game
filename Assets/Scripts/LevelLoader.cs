﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    AudioManager am;
    public Animator transition;

    public float transitionTime = 1f;

    void Start()
    {
        am = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Restart"))
        {
            RestartLevel();
        }
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 15)
        {
            Destroy(am.gameObject);
            StartCoroutine(LoadLevel(0));
        }
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
