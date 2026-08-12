using UnityEngine;
using TMPro;

public class A2RouteChoiceTrigger : MonoBehaviour
{
    public TMP_Text storyText;

    public string routeName = "MainRoute";

    [TextArea(2, 4)]
    public string promptMessage = "You chose this route.";

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

            A2RouteState.chosenRoute = routeName;

            if (storyText != null)
            {
                storyText.text = promptMessage;
            }

            Debug.Log("Player chose route: " + routeName);
        }
    }
}