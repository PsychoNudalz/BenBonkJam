using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Coroutine shake;
    public static CameraShake current;

    private void Awake()
    {
        current = this;
    }

    public void PlayShake(float duration, float magnitude)
    {
        if (shake!=null)
        {
            StopCoroutine(shake);
        }
        shake = StartCoroutine(Shake(duration, magnitude));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            //print("Shake");
            yield return null;
        }
        transform.localPosition = originalPos;
    }

}
