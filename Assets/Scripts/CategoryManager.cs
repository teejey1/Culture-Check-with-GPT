using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CategoryManager : MonoBehaviour
{
    public GameObject subCategoryPanel; // Assign in Inspector
    public GameObject subCategoryButtonPrefab; // Assign a prefab of a button in Inspector
    public Transform subCategoryButtonContainer; // Assign the parent container for buttons in Inspector
    private string selectedCategory;
    private Dictionary<string, List<string>> subCategories; // Holds subcategories for each category

    void Start()
    {
        subCategoryPanel.SetActive(false);
        InitializeSubCategories();
    }

    private void InitializeSubCategories()
    {
        // Example initialization - replace with your actual categories and subcategories
        subCategories = new Dictionary<string, List<string>>
        {
            { "Hip Hop", new List<string> { "Sub1", "Sub2", "Sub3" } },
            { "WWW", new List<string> { "Sub1", "Sub2" } }
            // Add more categories and their subcategories here
        };
    }

    public void SelectCategory(string category)
    {
        selectedCategory = category;
        ShowSubcategories(category);
    }

    private void ShowSubcategories(string category)
    {
        // Clear existing buttons
        foreach (Transform child in subCategoryButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // Create new buttons based on the selected category
        foreach (var subCategory in subCategories[category])
        {
            GameObject button = Instantiate(subCategoryButtonPrefab, subCategoryButtonContainer);
            button.GetComponentInChildren<Text>().text = subCategory;
            button.GetComponent<Button>().onClick.AddListener(() => SelectSubCategory(subCategory));
        }

        subCategoryPanel.SetActive(true);
    }

    public void SelectSubCategory(string subCategory)
    {
        // Logic to handle subcategory selection
        // ...
    }
}
