using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int minValue = 500;
    [SerializeField] RectMask2D mask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EvaluateSlider(Random.Range(0f,1f));
        }
    }

    public void EvaluateSlider(float percentage)
    {
        float fillAmount = (1 - percentage)  *  minValue;
        Debug.Log(fillAmount);
        mask.padding = new Vector4(0,0, fillAmount, 0);
    }
}
