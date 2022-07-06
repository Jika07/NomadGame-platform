using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SceneLoader : MonoBehaviour
{
    public GameObject PauseMenuScreen;
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuScreen.SetActive(false);
    } 
    public void RestartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      Time.timeScale = 1;
   }
   public void QuitGame()
   {
       Debug.Log("Exit");
       Application.Quit();
   }
   [SerializeField]private int homeLevelIndex;
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(homeLevelIndex);
    }
    public void Setting()
    {
        Time.timeScale = 0;
        PauseMenuScreen.SetActive(true);
    }
}
