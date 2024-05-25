using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
