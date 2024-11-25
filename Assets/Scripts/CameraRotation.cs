using System.Collections;
using UHFPS.Runtime;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform targetObject;  // El objeto al que la c�mara debe voltear.
    public float rotationSpeed = 1.0f; // Velocidad de la rotaci�n suave.
    public float rotationDuration = 2.0f; // Duraci�n de la rotaci�n (en segundos).

    private bool isRotating = false;

    // M�todo para iniciar la rotaci�n cuando el jugador recoge el objeto
    public void StartRotation()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCamera());
        }
    }

    // Corutina que maneja la rotaci�n suave
    private IEnumerator RotateCamera()
    {
        this.gameObject.GetComponent<LookController>().enabled = false;
        isRotating = true;

        Quaternion initialRotation = transform.rotation; // Guarda la rotaci�n inicial de la c�mara
        Quaternion targetRotation = Quaternion.LookRotation(targetObject.position - transform.position); // Calcula la rotaci�n hacia el objetivo

        float elapsedTime = 0;

        // Realiza la rotaci�n hacia el objetivo durante el tiempo especificado
        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, (elapsedTime / rotationDuration) * rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegura que la rotaci�n final quede en el objetivo
        transform.rotation = targetRotation;

        // Pausa opcional para mantener la rotaci�n final por un momento
        yield return new WaitForSeconds(0.5f);

        // Regresa a la rotaci�n inicial de forma suave
        elapsedTime = 0;
        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(targetRotation, initialRotation, (elapsedTime / rotationDuration) * rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegura que la rotaci�n final quede en la inicial
        transform.rotation = initialRotation;

        // Despu�s de la rotaci�n, se puede permitir que el jugador siga controlando normalmente
        isRotating = false;
        this.gameObject.GetComponent<LookController>().enabled = true;
    }
}
