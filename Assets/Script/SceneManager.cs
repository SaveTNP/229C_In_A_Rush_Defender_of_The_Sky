using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	public void LoadGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void WinScene() => SceneManager.LoadScene("Win");
	public void LoseScene() => SceneManager.LoadScene("GameOver");
}

