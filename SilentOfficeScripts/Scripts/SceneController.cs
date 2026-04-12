using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // 轉跳至 IntroduceMenu 場景
    public void GoToIntroduceMenu()
    {
        SceneManager.LoadScene("IntroduceMenu");
    }

    // 重新載入當前場景
    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}

