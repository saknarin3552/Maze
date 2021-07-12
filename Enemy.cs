using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;

    public float damage;

    public GameObject playerTriggered;

    private Slider healthbarSlider;

    void Start()
    {

    }

    void Update()
    {
        Die();
    }
    
    public void Die()
    {
        if (health <= 0)
            Destroy(this.gameObject);
    }

    

    /*private void SetHealthbarUi()
    {
        //healthbarSlider.value = 
    }

    private float CalculateHealthPercentage()
    {
        return ((float)health / )
    }*/
}
