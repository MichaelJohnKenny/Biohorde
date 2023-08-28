using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float MaxShakeIntensity = 0.5f;

    public void Shake(float duration, float magnitude, bool impactFreeze)
    {
        //Time.timeScale = 0f;
        StartCoroutine(inShake(duration, magnitude, impactFreeze));
    }

    private IEnumerator inShake(float duration, float magnitude, bool impactFreeze)
    {
        Vector3 startPos = transform.localPosition;

        float elapsed = 0f;
        float freezeDuration = 0.016f;

        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(freezeDuration);

        Time.timeScale = 1f;

        while(elapsed < duration)
        {
            float x = Random.Range(-MaxShakeIntensity, MaxShakeIntensity) * magnitude;
            float y = Random.Range(-MaxShakeIntensity, MaxShakeIntensity) * magnitude;

            transform.localPosition += new Vector3(x, y, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = startPos;

    }
}
