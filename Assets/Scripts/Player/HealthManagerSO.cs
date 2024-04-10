using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HealthManagerSO", menuName = "HealthManager")]
public class HealthManagerSO : ScriptableObject
{
    public int health = 100;


    [SerializeField] private int maxHealth = 100;

    [System.NonSerialized] private UnityEvent<int> healthChangeEvent;

    private void OnEnable()
    {
        health = maxHealth;
        if(healthChangeEvent == null)
            healthChangeEvent = new UnityEvent<int>();
    }

    public void DecreaseHealth(int amountHealth)
    {
        health -= amountHealth;
        healthChangeEvent?.Invoke(health);
    }
}
