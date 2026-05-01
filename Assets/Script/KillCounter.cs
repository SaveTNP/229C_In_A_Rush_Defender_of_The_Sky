using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillCounter : MonoBehaviour
{
    public int target = 250;
    private int current = 0;

    public TextMeshProUGUI killCountText;

    private MenuController sceneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = FindFirstObjectByType<MenuController>();
        UpdateKillUI();
    }

    // Update is called once per frame
    public void KillCount()
    {
        current++;
        UpdateKillUI();
        if (current >= target)
        {
            sceneManager.WinScene();
        }
    }

	private void UpdateKillUI()
	{
        killCountText.text = "Score : " + current + "/" + target;
	}
}
