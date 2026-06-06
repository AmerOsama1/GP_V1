using UnityEngine;

public class GridTile : MonoBehaviour
{
    [HideInInspector] public int tileIndex;
    [HideInInspector] public bool isPartOfShape;

    private Renderer tileRenderer;
    private Color originalColor;

    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;

    void Start()
    {
        tileRenderer = GetComponent<Renderer>();
        originalColor = tileRenderer.material.color;
    }

    public void SetGreen()
    {
        tileRenderer.material.color = correctColor;
    }

    public void SetRed()
    {
        tileRenderer.material.color = wrongColor;
    }

    public void Reset()
    {
        tileRenderer.material.color = originalColor;
    }
}