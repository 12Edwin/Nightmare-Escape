using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayVideoOnOpen : MonoBehaviour
{
    public void ChangeToVideoScene()
    {
        SceneManager.LoadScene("VIDEO");
    }

}