using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField] private Health PlayerHealth;
    [SerializeField] private Image  totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        totalhealthBar.fillAmount = PlayerHealth.currentHealth / 10;
    }
    private void Update()
    {
        currenthealthBar.fillAmount = PlayerHealth.currentHealth / 10;
    }
}
