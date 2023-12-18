using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;

public class SceneExplorer : MonoBehaviour
{
    [Inject]
    DiContainer _container;

    public void Next() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void Back() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    public void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void Goto(string scene) => SceneManager.LoadScene(scene);
    public void Goto(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
    public void Exit() => Application.Quit();
    public void Pause(bool pause) => Time.timeScale = pause ? 0 : 1;

    public void AsyncClose() => SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    public void AsyncOpenScene(int index) => SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);


    public void AsyncCloseScene(int sceneIndex)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetAllScenes()[SceneManager.sceneCount - 1]);
    }
    public void AsyncCloseScene(string scene) => SceneManager.UnloadSceneAsync(scene);
}
