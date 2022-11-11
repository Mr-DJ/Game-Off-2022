using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel("Hallway"));
        }
    }

    IEnumerator LoadLevel(string levelname)
    {
        transition.SetTrigger("Enter");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelname);

    }
    
}
