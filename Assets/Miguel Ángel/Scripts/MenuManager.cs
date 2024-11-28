using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Método para cargar la escena
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); 
    }
}
