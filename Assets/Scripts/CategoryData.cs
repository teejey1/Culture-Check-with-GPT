using System.Collections.Generic;
using UnityEngine;

public class CategoryData : MonoBehaviour
{
    public static CategoryData Instance;

    public Dictionary<string, List<string>> categoryToSubcategories;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeCategories();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeCategories()
    {
        categoryToSubcategories = new Dictionary<string, List<string>>()
        {
            { "Hip Hop", new List<string> { "Sub1", "Sub2", "Sub3" } },
            { "WWW", new List<string> { "Sub1", "Sub2" } }
            // Add more categories and subcategories here
        };
    }
}
