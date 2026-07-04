using UnityEngine;
using TMPro;

public class EndingTrigger : MonoBehaviour
{
    public TMP_Text storyText;
    public GameObject endingPanel;

    private bool triggered = false;

    private void Start()
    {
        if (endingPanel != null)
        {
            endingPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered)
        {
            return;
        }

        if (other.CompareTag("Player") || other.GetComponentInParent<CharacterController>() != null)
        {
            triggered = true;

            if (storyText != null)
            {
                storyText.text = "Rescue workers are ahead.";
            }

            if (endingPanel != null)
            {
                endingPanel.SetActive(true);
            }
        }
    }
}