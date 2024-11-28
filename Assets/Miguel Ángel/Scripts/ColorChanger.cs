using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color newColor = Color.red; // Color deseado

    void Start()
    {
        // Obtén el material del Mesh Renderer y cambia su color
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = newColor;
        }
    }
}
