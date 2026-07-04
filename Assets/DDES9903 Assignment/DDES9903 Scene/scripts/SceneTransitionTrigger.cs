using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneTransitionTrigger : MonoBehaviour
{
    [Header("Scene Settings")]
    public string sceneToLoad = "TrainAccidentScene";
    public float delayBeforeLoad = 1.5f;

    [Header("Optional UI")]
    public TMP_Text storyText;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered)
        {
            return;
        }

        if (other.CompareTag("Player") || other.GetComponentInParent<CharacterController>() != null)
        {
            triggered = true;
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        if (storyText != null)
        {
            storyText.text = "The doors close behind you.\nSomething suddenly goes wrong.";
        }

        yield return new WaitForSeconds(delayBeforeLoad);

        SceneManager.LoadScene(sceneToLoad);
    }
}