using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoriesButtonScript : MonoBehaviour
{
    public void OnCategoriesButtonClick()
    {
        SceneManager.LoadScene("CategoryScene"); // Make sure the scene name matches exactly
    }
}
