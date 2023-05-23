using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float duration;
    public Transform cameraTransform;
    private Vector3 originalPosition;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        originalPosition = cameraTransform.transform.position;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCam());
    }


    IEnumerator ShakeCam()
    {
        float x;
        float y;
        float timeLeft = Time.time;

        while ((timeLeft + duration) > Time.time)
        {
            x = Random.Range(-0.3f, 0.3f);
            y = Random.Range(-0.3f, 0.3f);

            cameraTransform.position = new Vector3(x, y, originalPosition.z);
            yield return new WaitForSeconds(0.025f);
        }

        cameraTransform.position = originalPosition;
    }
}
