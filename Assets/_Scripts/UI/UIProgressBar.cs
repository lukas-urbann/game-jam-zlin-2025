using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField] private RectMask2D mask;
    [SerializeField] private float maxWidth;
    private PlayerProgress _playerProgress;
    
    [SerializeField] private bool test;

    private void Start()
    {
        maxWidth = mask.rectTransform.rect.width;
    }

    private void OnDestroy()
    {
        if (_playerProgress != null)
        {
            _playerProgress.OnProgressChanged -= EvaluateSlider;
        }
    }

    private void LateUpdate()
    {
        if (test && Input.GetKeyDown(KeyCode.Space))
        {
            EvaluateSlider(Random.Range(0f, 1f));
        }
    }

    public void EvaluateSlider(float percentage)
    {
        float maskWidth = maxWidth * (1f - percentage);
        mask.padding = new Vector4(0f, 0f, maskWidth, 0f);
    }
}