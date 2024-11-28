using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public float waitTime = 10f; // Tiempo de espera antes de permitir reiniciar
    private bool canRestart = false; // Controla si se puede reiniciar

    void Start()
    {
        // Inicia un temporizador para habilitar el reinicio
        Invoke("EnableRestart", waitTime);
    }

    void Update()
    {
        // Permitir reiniciar solo si ha pasado el tiempo
        if (canRestart && Input.anyKeyDown)
        {
            RestartGame();
        }
    }

    void EnableRestart()
    {
        canRestart = true; // Permitir reinicio
        Debug.Log("Ahora puedes reiniciar la partida presionando cualquier tecla.");
    }

    void RestartGame()
    {
        // Cambiar a la escena del juego
        SceneManager.LoadScene("Game");
    }
}
