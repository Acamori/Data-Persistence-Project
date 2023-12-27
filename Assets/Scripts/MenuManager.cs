using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class MenuManager:MonoBehaviour
	{

	private string playerName;

	[SerializeField] Button startButton;
	[SerializeField] Button exitButton;
	[SerializeField] TextMeshProUGUI bestScoreText;
	[SerializeField] TMP_InputField playerNameInputFied;

	private DataManager dataManager;

	// Start is called before the first frame update
	void Start()
		{

		if (DataManager.Instance.GetBestScorePlayer() != null)
			{
			bestScoreText.text = $"Best Score: {DataManager.Instance.GetBestScorePlayer()} : {DataManager.Instance.GetBestScore()}";
			}

		}

	public void StartGame()
		{
		DataManager.Instance.SetPlayerName(playerName);
		SceneManager.LoadScene(1);
		}

	public void ReadPlayerNameInputField()
		{
		playerName = playerNameInputFied.text;
		}

	public void ExitGame()
		{

		DataManager.Instance.SaveData();
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
		}

	}
