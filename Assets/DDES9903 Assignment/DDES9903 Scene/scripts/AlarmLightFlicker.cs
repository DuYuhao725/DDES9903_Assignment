using UnityEngine;

public class AlarmLightFlicker : MonoBehaviour
{
    public Light alarmLight;
    public float minIntensity = 0.2f;
    public float maxIntensity = 2.5f;
    public float flickerSpeed = 5f;

    void Update()
    {
        if (alarmLight == null)
        {
            return;
        }

        float flickerValue = Mathf.PingPong(Time.time * flickerSpeed, 1f);
        alarmLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, flickerValue);
    }
}