using UnityEngine;

public class EmissiveMaterial : MonoBehaviour
{
    public Material emissiveMaterial; // Asigna el material emisivo desde el Inspector
    public float flickerSpeed = 1.0f; // Velocidad de parpadeo (ajusta según tus necesidades)
    private bool isEmitting = false;

    void Start()
    {
        // Inicializa el estado del material
        emissiveMaterial.DisableKeyword("_EMISSION");
    }

    void Update()
    {
        // Cambia el estado del material emisivo
        if (Time.time % (2 * flickerSpeed) < flickerSpeed)
        {
            if (!isEmitting)
            {
                emissiveMaterial.EnableKeyword("_EMISSION");
                isEmitting = true;
            }
        }
        else
        {
            if (isEmitting)
            {
                emissiveMaterial.DisableKeyword("_EMISSION");
                isEmitting = false;
            }
        }
    }
   
}
