using UnityEngine;
using UnityEngine.UI;

public class HealthBarMultiPlayer : MonoBehaviour
{
    public Slider sliderPlayer;
    public Gradient gradientPlayer;
    public Image fillPlayer;

    public void setMaxHealth(float health)
    {
        sliderPlayer.maxValue = health;

        sliderPlayer.value = health;

        fillPlayer.color = gradientPlayer.Evaluate(1f);
    }

    public void setHealthPlayer(float health)
    {
        sliderPlayer.value = health;

        fillPlayer.color = gradientPlayer.Evaluate(sliderPlayer.normalizedValue);
    }
}