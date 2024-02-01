using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void StartGame()
    {
        // Call the LoadScene method from the SceneManager class
        SceneManager.LoadSceneAsync("Flappy Bird");
    }
}
