using UnityEngine;
using UnityEngine.UI;

public class CooldownVisualize : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void EvaluateSlider(float percentage)
    {
        slider.value = percentage;
    }
}
