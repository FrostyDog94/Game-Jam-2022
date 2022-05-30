using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 10.0f;
    public float currentTime;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        currentTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        slider.value = currentTime / timer;
    }
}
