using UnityEngine;
using TMPro;

public class A2EndingRouteText : MonoBehaviour
{
    public TMP_Text endingTitleText;
    public TMP_Text endingBodyText;

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

            if (endingTitleText != null)
            {
                endingTitleText.text = "RESCUE FOUND";
            }

            if (endingBodyText != null)
            {
                if (A2RouteState.chosenRoute == "ServiceTunnel")
                {
                    endingBodyText.text = "You reached the rescue team through the emergency service tunnel.\nYour alternative route helped you avoid the damaged carriage.";
                }
                else
                {
                    endingBodyText.text = "You reached the rescue team through the damaged carriage route.\nYou followed the main escape path and found help.";
                }
            }

            Debug.Log("Ending route text updated: " + A2RouteState.chosenRoute);
        }
    }
}