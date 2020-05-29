using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string MaterialTest = "MaterialTest";

   public void PlayGame()
    {
        SceneManager.LoadScene(MaterialTest);
    }

    public void QuitGame()
    {

        Application.Quit();
    }
}
