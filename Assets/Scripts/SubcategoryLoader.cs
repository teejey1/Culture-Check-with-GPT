using Firebase.Firestore;
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Extensions;
using UnityEngine.UI; // Required for UI Components

public class SubcategoryLoader : MonoBehaviour
{
    FirebaseFirestore db;
    public GameObject subcategoryButtonPrefab; // Assign in Inspector
    public Transform subcategoryContainer; // Assign in Inspector
    public GameObject subCategoryPanel; // Assign in Inspector

    void Awake()
    {
        db = FirebaseFirestore.DefaultInstance;
        // Ensure the subCategoryPanel is inactive when the game starts
        subCategoryPanel.SetActive(false);
    }

    // Call this method with the category ID to load its subcategories
    public void LoadSubcategoriesForCategory(string categoryId)
    {
        db.Collection("Categories").Document(categoryId).Collection("Subcategories").GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error fetching subcategories: " + task.Exception);
                return;
            }

            // Activate the subCategoryPanel when the subcategories are being loaded
            subCategoryPanel.SetActive(true);

            QuerySnapshot subcategoriesSnapshot = task.Result;
            foreach (DocumentSnapshot documentSnapshot in subcategoriesSnapshot.Documents)
            {
                string subcategoryName = documentSnapshot.GetValue<string>("name");
                GameObject buttonObj = Instantiate(subcategoryButtonPrefab, subcategoryContainer);
                buttonObj.GetComponentInChildren<Text>().text = subcategoryName;

                // Add an OnClick event listener to the instantiated button
                buttonObj.GetComponent<Button>().onClick.AddListener(() => OnSubcategorySelected(subcategoryName));
            }
        });
    }

    private void OnSubcategorySelected(string subcategoryName)
    {
        // Handle the subcategory selection here (e.g., storing the selected subcategory)
        Debug.Log("Subcategory selected: " + subcategoryName);
        // Optionally deactivate the subCategoryPanel if needed
        // subCategoryPanel.SetActive(false);
    }
}
