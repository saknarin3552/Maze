using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public static PlayerHp singletion;
    public float currenHealth;
    public float maxHealth = 100f;

    private void Awake()
    {
        singletion = this;
    }
    void Start()
    {
        currenHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage)
    {
        currenHealth -= damage;
    }
}
