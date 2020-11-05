using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    private Vector3 savedScale;

    public Vector3 scaleMultiplier = new Vector3(1.5f, 1.2f, 1.5f);
    private float timeScale = 4f;
    private float offset;

    private float yTimeMult = 2f;

    private void Start()
    {
        offset = 0;//= Random.Range(-1, 1f);
        savedScale = transform.localScale;
    }

    private void Update()
    {
        float sin = (Mathf.Sin(Time.time * timeScale + offset) + 1) / 2;
        float ySin = (Mathf.Sin(Time.time * timeScale + offset * yTimeMult) + 1) / 2;

        transform.localScale = new Vector3
            (Mathf.Lerp(savedScale.x, savedScale.x * scaleMultiplier.x, sin)
            , Mathf.Lerp(savedScale.y, savedScale.y * scaleMultiplier.y, ySin)
            , Mathf.Lerp(savedScale.z, savedScale.z * scaleMultiplier.z, 1 - sin)
            ); ;
    }

}
