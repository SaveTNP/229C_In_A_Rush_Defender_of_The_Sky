using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
	public void LoadGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void LoadMainMenu()
	{
		Cursor.visible = true;
		SceneManager.LoadScene("MainMenu");
	}

	public void LoadCredit()
	{
		Cursor.visible = true;
		SceneManager.LoadScene("Credit");
	}
	public void QuitGame()
	{
		Application.Quit();
	}

	public void WinScene() 
	{ 
		Cursor.visible = true; 
		SceneManager.LoadScene("Win"); 
	}
	public void LoseScene()
	{
		Cursor.visible = true;
		SceneManager.LoadScene("GameOver");
	}
}

