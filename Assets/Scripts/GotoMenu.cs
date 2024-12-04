using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GotoMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PlayVideo());
    }

    public IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("MainMenu");
    }
}
