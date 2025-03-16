using UnityEngine;

public class zmenBarvu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private Color baseColor;
    void Start()
    {
        baseColor = GetComponent<MeshRenderer>().materials[1].GetColor("_OulineColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetInteractiveColor();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ResetColor();
        }
    }

    public void SetInteractiveColor()
    {
        Material mat = transform.GetComponent<MeshRenderer>().materials[1];
        mat.SetColor("_OulineColor", Color.green);
    }

    public void ResetColor()
    {
        transform.GetComponent<MeshRenderer>().materials[1].SetColor("_OulineColor", baseColor);
    }




}
