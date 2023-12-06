using UnityEngine;

public class WWWBtnController : MonoBehaviour
{
    private CategoryManager categoryManager;

    void Start()
    {
        // Find the CategoryManager in the scene
        categoryManager = FindObjectOfType<CategoryManager>();
    }

    public void OnWWWButtonClicked()
    {
        // Call SelectCategory on the CategoryManager with "WWW"
        if (categoryManager != null)
        {
            categoryManager.SelectCategory("WWW");
        }
        else
        {
            Debug.LogError("CategoryManager not found in the scene.");
        }
    }
}
