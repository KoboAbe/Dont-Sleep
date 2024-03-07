using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioClip hoverSound; // Sonido que se reproducirá al pasar el mouse sobre el botón
    public AudioClip clickSound; // Sonido que se reproducirá al hacer clic en el botón

    private Button button; // Referencia al componente Button del botón
    private AudioSource audioSource; // Referencia al componente AudioSource para reproducir sonidos
    private bool hasPlayedSound = false; // Indica si el sonido de hover ya se ha reproducido

    void Start()
    {
        // Obtener la referencia al componente Button del botón
        button = GetComponent<Button>();

        // Asegurarse de que hay un AudioClip asignado al sonido de hover
        if (hoverSound == null)
        {
            Debug.LogError("No se ha asignado ningún AudioClip para el sonido de hover en el botón.");
            return;
        }

        // Obtener o agregar un componente AudioSource al objeto
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asignar el AudioClip al AudioSource
        audioSource.clip = hoverSound;
    }

    // Se ejecuta cuando el mouse entra en el área del botón
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Si el sonido de hover no se ha reproducido, reproducirlo
        if (!hasPlayedSound)
        {
            audioSource.PlayOneShot(hoverSound);
            hasPlayedSound = true; // Marcar que el sonido de hover se ha reproducido
        }
    }

    // Se ejecuta cuando el mouse sale del área del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        // Reiniciar la bandera de reproducción de sonido de hover cuando el mouse sale del botón
        hasPlayedSound = false;
    }

    // Se ejecuta cuando se hace clic en el botón
    public void OnPointerClick(PointerEventData eventData)
    {
        // Reproducir el sonido de clic si está asignado
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
