using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioClip hoverSound; // Sonido que se reproducir� al pasar el mouse sobre el bot�n
    public AudioClip clickSound; // Sonido que se reproducir� al hacer clic en el bot�n

    private Button button; // Referencia al componente Button del bot�n
    private AudioSource audioSource; // Referencia al componente AudioSource para reproducir sonidos
    private bool hasPlayedSound = false; // Indica si el sonido de hover ya se ha reproducido

    void Start()
    {
        // Obtener la referencia al componente Button del bot�n
        button = GetComponent<Button>();


        // Asegurarse de que hay un AudioClip asignado al sonido de hover
        if (hoverSound == null)
        {
            Debug.LogError("No se ha asignado ning�n AudioClip para el sonido de hover en el bot�n.");
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

    // Se ejecuta cuando el mouse entra en el �rea del bot�n
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Si el sonido de hover no se ha reproducido, reproducirlo
        if (!hasPlayedSound)
        {
            audioSource.PlayOneShot(hoverSound);
            hasPlayedSound = true; // Marcar que el sonido de hover se ha reproducido
        }
    }

    // Se ejecuta cuando el mouse sale del �rea del bot�n
    public void OnPointerExit(PointerEventData eventData)
    {
        // Reiniciar la bandera de reproducci�n de sonido de hover cuando el mouse sale del bot�n
        hasPlayedSound = false;
    }

    // Se ejecuta cuando se hace clic en el bot�n
    public void OnPointerClick(PointerEventData eventData)
    {
        // Reproducir el sonido de clic si est� asignado
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
