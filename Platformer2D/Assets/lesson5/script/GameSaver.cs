using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaver : MonoBehaviour
{
    [SerializeField] Hero hero;

    private void OnApplicationQuit()
    {
        GameLoader.SaveGame(SceneManager.GetActiveScene().buildIndex, hero);
    }


}
