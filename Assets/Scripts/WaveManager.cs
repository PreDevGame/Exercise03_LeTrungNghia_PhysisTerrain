using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitute = 1f;
    public float length = 2f;
    public float speedWave = 1f;
    public float offset = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Detroy");
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speedWave;
    }

    public float GetWaveHeight(float _x)
    {
        return amplitute * Mathf.Sin(_x / length + offset);
    }
}
