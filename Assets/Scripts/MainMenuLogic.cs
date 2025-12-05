using UnityEngine;
using UnityEngine.SceneManagement; // Wajib ada untuk pindah scene

public class MainMenuLogic : MonoBehaviour
{
    public void StartGame()
    {
        // Pastikan nama scene di dalam tanda kutip SAMA PERSIS dengan nama file scene kamu
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }
}