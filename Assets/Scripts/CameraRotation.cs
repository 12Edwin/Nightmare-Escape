using System.Collections;
using UHFPS.Runtime;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform targetObject;  // El objeto al que la cámara debe voltear.
    public float rotationSpeed = 1.0f; // Velocidad de la rotación suave.
    public float rotationDuration = 2.0f; // Duración de la rotación (en segundos).

    private bool isRotating = false;

    // Método para iniciar la rotación cuando el jugador recoge el objeto
    public void StartRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCamera());
        }
    }

    // Corutina que maneja la rotación suave
    private IEnumerator RotateCamera()
    {
        this.gameObject.GetComponent<LookController>().enabled = false;
        isRotating = true;

        Quaternion initialRotation = transform.rotation; // Guarda la rotación inicial de la cámara
        Quaternion targetRotation = Quaternion.LookRotation(targetObject.position - transform.position); // Calcula la rotación hacia el objetivo

        float elapsedTime = 0;

        // Realiza la rotación hacia el objetivo durante el tiempo especificado
        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, (elapsedTime / rotationDuration) * rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegura que la rotación final quede en el objetivo
        transform.rotation = targetRotation;

        // Pausa opcional para mantener la rotación final por un momento
        yield return new WaitForSeconds(0.5f);

        // Regresa a la rotación inicial de forma suave
        elapsedTime = 0;
        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(targetRotation, initialRotation, (elapsedTime / rotationDuration) * rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegura que la rotación final quede en la inicial
        transform.rotation = initialRotation;

        // Después de la rotación, se puede permitir que el jugador siga controlando normalmente
        isRotating = false;
        this.gameObject.GetComponent<LookController>().enabled = true;
    }
}
