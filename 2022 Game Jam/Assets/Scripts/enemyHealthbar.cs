using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthbar : MonoBehaviour
{

    public Enemy enemy;
    public float maxHealth = 100;
    Slider slider;
    GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemy.health / maxHealth;
        transform.LookAt(cam.transform);
    }
}
