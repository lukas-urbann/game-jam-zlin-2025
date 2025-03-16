using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class OutlineEffect : MonoBehaviour
{
    public Color outlineColor = Color.black;
    public float outlineWidth = 0.02f;

    private GameObject outlineObject;

    void Start()
    {
        CreateOutline();
    }

    void CreateOutline()
    {
        // Create new child object
        outlineObject = new GameObject("Outline");
        outlineObject.transform.parent = transform;
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localRotation = Quaternion.identity;
        outlineObject.transform.localScale = Vector3.one * (1f + outlineWidth);

        // Copy Mesh
        MeshFilter meshFilter = outlineObject.AddComponent<MeshFilter>();
        meshFilter.mesh = GetComponent<MeshFilter>().mesh;

        // Add Renderer
        MeshRenderer meshRenderer = outlineObject.AddComponent<MeshRenderer>();

        // Create simple material
        Material outlineMat = new Material(Shader.Find("Unlit/Color"));
        outlineMat.color = outlineColor;
        outlineMat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Front); // Cull front faces

        meshRenderer.material = outlineMat;
    }
}
