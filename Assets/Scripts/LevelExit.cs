using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] float levelExitSlowFactor = 0.2f;

    bool exiting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!exiting)
        {
            exiting = true;
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        Time.timeScale = levelExitSlowFactor;
        yield return new WaitForSeconds(levelLoadDelay * levelExitSlowFactor);

        Time.timeScale = 1f;
        Destroy(FindObjectOfType<ScenePersist>().gameObject);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
