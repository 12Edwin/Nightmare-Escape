using UHFPS.Runtime;
using UnityEngine;

public class Buscar : MonoBehaviour
{
    public void buscar()
    {
        GameObject objeto = GameObject.Find("FPView");
        objeto.GetComponent<CameraRotation>().StartRotation();

    }
}
