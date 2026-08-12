using UnityEngine;
using TMPro;

public class A2EmergencyCallPanel : MonoBehaviour
{
    public static bool emergencySignalSent = false;

    [Header("UI")]
    public TMP_Text storyText;

    [Header("Panel Visuals")]
    public TMP_Text panelText;
    public Renderer statusLightRenderer;
    public Light statusPointLight;

    [Header("Materials")]
    public Material inactiveMaterial;
    public Material activeMaterial;

    [Header("Audio")]
    public AudioSource callAudio;

    private bool playerInside = false;
    private bool used = false;

    private void Start()
    {
        emergencySignalSent = false;

        if (panelText != null)
        {
            panelText.text = "EMERGENCY CALL PANEL\nPress E to send rescue signal";
        }

        if (statusLightRenderer != null && inactiveMaterial != null)
        {
            statusLightRenderer.material = inactiveMaterial;
        }

        if (statusPointLight != null)
        {
            statusPointLight.enabled = false;
        }
    }

    private void Update()
    {
        if (playerInside && !used && Input.GetKeyDown(KeyCode.E))
        {
            SendEmergencySignal();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (used)
        {
            return;
        }

        if (other.CompareTag("Player") || other.GetComponentInParent<CharacterController>() != null)
        {
            playerInside = true;

            if (storyText != null)
            {
                storyText.text = "Press E to send an emergency signal.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponentInParent<CharacterController>() != null)
        {
            playerInside = false;

            if (!used && storyText != null)
            {
                storyText.text = "You are inside the emergency service tunnel.\nFind the rescue point.";
            }
        }
    }

    private void SendEmergencySignal()
    {
        used = true;
        emergencySignalSent = true;

        if (storyText != null)
        {
            storyText.text = "Emergency signal sent.\nRescue team has received your location.";
        }

        if (panelText != null)
        {
            panelText.text = "SIGNAL SENT\nRescue team notified";
        }

        if (statusLightRenderer != null && activeMaterial != null)
        {
            statusLightRenderer.material = activeMaterial;
        }

        if (statusPointLight != null)
        {
            statusPointLight.enabled = true;
        }

        if (callAudio != null)
        {
            callAudio.Play();
        }

        Debug.Log("Emergency signal sent.");
    }
}