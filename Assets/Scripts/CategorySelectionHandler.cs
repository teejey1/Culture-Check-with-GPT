using UnityEngine;
using UnityEngine.SceneManagement;

public class CategorySelectionHandler : MonoBehaviour
{
    public void SelectCategoryAndSubcategory(string category, string subCategory)
    {
        // Store the selections using PlayerPrefs
        PlayerPrefs.SetString("SelectedCategory", category);
        PlayerPrefs.SetString("SelectedSubCategory", subCategory);

        // After storing, you can start the game or load the game scene
        StartGameWithSelectedCategory();
    }

    private void StartGameWithSelectedCategory()
    {
        string category = PlayerPrefs.GetString("SelectedCategory");
        string subCategory = PlayerPrefs.GetString("SelectedSubCategory");

        // Assuming TriviaGameManager has a method to start the game with selected category
        TriviaGameManager.Instance.StartGameWithCategory(category, subCategory);
    }
}
