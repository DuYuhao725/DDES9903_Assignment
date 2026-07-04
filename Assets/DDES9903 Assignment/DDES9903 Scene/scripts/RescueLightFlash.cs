using UnityEngine;

public class RescueLightFlash : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;

    public float flashSpeed = 2f;
    public float highIntensity = 3f;
    public float lowIntensity = 0.2f;

    void Update()
    {
        if (redLight == null || blueLight == null)
        {
            return;
        }

        float flash = Mathf.PingPong(Time.time * flashSpeed, 1f);

        redLight.intensity = Mathf.Lerp(lowIntensity, highIntensity, flash);
        blueLight.intensity = Mathf.Lerp(highIntensity, lowIntensity, flash);
    }
}