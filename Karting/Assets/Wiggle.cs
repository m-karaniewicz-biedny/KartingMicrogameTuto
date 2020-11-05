using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    private Vector3 savedScale;

    internal Vector3 scaleMultiplier = new Vector3(2f, 2f, 2f);
    internal bool randomOffsetOn = true;
    
    private float timeScale = 2f;
    private float yTimeMult = 0.5f;

    private float offset;

    private void Start()
    {
        offset = randomOffsetOn ? Random.Range(-1, 1f) : 0;
        savedScale = transform.localScale;
    }

    private void Update()
    {
        float XZSin = (Mathf.Sin(Time.time * timeScale + offset) + 1) / 2;
        float ZSin = (Mathf.Sin(Time.time * timeScale * yTimeMult + offset) + 1) / 2;

        transform.localScale = new Vector3
            (Mathf.Lerp(savedScale.x, savedScale.x * scaleMultiplier.x, XZSin)
            , Mathf.Lerp(savedScale.y, savedScale.y * scaleMultiplier.y, ZSin)
            , Mathf.Lerp(savedScale.z, savedScale.z * scaleMultiplier.z, 1 - XZSin)
            );
    }

}
