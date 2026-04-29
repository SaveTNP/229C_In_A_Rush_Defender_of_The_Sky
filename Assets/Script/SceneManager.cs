using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}

