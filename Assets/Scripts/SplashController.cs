using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    public float delayTime = 3f; // Time in seconds to wait before switching scene

    void Start()
    {
        StartCoroutine(LoadLoginSceneAfterDelay());
    }

    IEnumerator LoadLoginSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayTime); // Wait for the specified delay time
        SceneManager.LoadScene("LoginScene"); // Replace with your login scene name
    }
}
