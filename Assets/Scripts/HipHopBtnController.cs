using UnityEngine;

public class HipHopBtnController : MonoBehaviour
{
    private CategoryManager categoryManager;

    void Start()
    {
        // Find the CategoryManager in the scene
        categoryManager = FindObjectOfType<CategoryManager>();
    }

    public void OnHipHopButtonClicked()
    {
        // Call SelectCategory on the CategoryManager with "Hip Hop"
        if (categoryManager != null)
        {
            categoryManager.SelectCategory("Hip Hop");
        }
        else
        {
            Debug.LogError("CategoryManager not found in the scene.");
        }
    }
}
