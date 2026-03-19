using UnityEngine;
using UnityEngine.UI;

public class HealthBarMultiEnemy : MonoBehaviour
{
    public Slider sliderEnemy;
    public Gradient gradientEnemy;
    public Image fillEnemy;

    public void setMaxHealth(float health)
    {
        sliderEnemy.maxValue = health;

        sliderEnemy.value = health;

        fillEnemy.color = gradientEnemy.Evaluate(1f);
    }

    public void setHealthEnemy(float health)
    {
        sliderEnemy.value = health;

        fillEnemy.color = gradientEnemy.Evaluate(sliderEnemy.normalizedValue);
    }
}