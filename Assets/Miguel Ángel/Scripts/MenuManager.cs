using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // M�todo para cargar la escena
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); 
    }
}
