using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicFader : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    public void StartFade(string volumeControlToFade, float duration, float targetVolume)
    {
        StartCoroutine(StartFadeCoroutine(volumeControlToFade, duration, targetVolume));
    }

    public IEnumerator StartFadeCoroutine(string volumeControlToFade, float duration, float targetVolume)
    {
        float currentTime = 0;
        float currentVol;
        audioMixer.GetFloat(volumeControlToFade, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            audioMixer.SetFloat(volumeControlToFade, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }
}
