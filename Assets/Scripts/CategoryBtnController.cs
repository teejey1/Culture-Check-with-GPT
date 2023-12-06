using UnityEngine;

public class CategoryButtonController : MonoBehaviour
{
    private CategoryManager categoryManager;
    public string categoryName; // Set this in the Inspector for each category button

    void Start()
    {
        categoryManager = FindObjectOfType<CategoryManager>();
    }

    public void OnCategoryButtonClicked()
    {
        if (categoryManager != null)
        {
            categoryManager.SelectCategory(categoryName);
        }
        else
        {
            Debug.LogError("CategoryManager not found in the scene.");
        }
    }
}
