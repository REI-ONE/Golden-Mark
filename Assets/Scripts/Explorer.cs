using UnityEngine.SceneManagement;
using UnityEngine;

namespace Game
{
    public interface IExplorer
    {
        public void Next();
        public void Back();
        public void GoTo(int index);
        public void Refresh();
        public void Exite();
    }

    public class Explorer : MonoBehaviour, IExplorer
    {
        public void Back()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void Exite()
        {
            Application.Quit();
        }

        public void GoTo(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void Next()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void Refresh()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}