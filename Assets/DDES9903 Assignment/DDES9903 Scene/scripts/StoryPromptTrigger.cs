using UnityEngine;
using TMPro;

public class StoryPromptTrigger : MonoBehaviour
{
    public TMP_Text storyText;

    [TextArea(2, 4)]
    public string promptMessage = "Follow the emergency signs.";

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

            if (storyText != null)
            {
                storyText.text = promptMessage;
            }
        }
    }
}