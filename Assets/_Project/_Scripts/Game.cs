using UnityEngine.SceneManagement;

namespace _Project._Scripts
{
    public class Game
    {
        private readonly Wish _wish;

        public Game(IEndPanel endPanel, Wish wish)
        {
            _wish = wish;
            endPanel.OnNext += OnNext;
            endPanel.OnRestart += OnRestart;
        }

        private void OnRestart()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }

        private void OnNext()
        {
            _wish.MoveNext();
            SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }
}