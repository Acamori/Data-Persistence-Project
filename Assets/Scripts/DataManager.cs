using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DataManager:MonoBehaviour
	{

	// TODO - сохранения данных в файл и их чтение

	public static DataManager Instance;
	public static string playerName;

	public static int bestScore;
	public static string bestScorePlayer;

	// Start is called before the first frame update
	void Awake()
		{

		if (Instance != null)
			{
			Destroy(gameObject);
			return;
			}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		LoadData();

		}

	void Update()
		{

		}

	public void SetPlayerName(string s)
		{
		playerName = s;
		}

	public string GetPlayerName()
		{
		return playerName;
		}


	public void SetBestScore(int score, string player)
		{
		bestScore = score;
		bestScorePlayer = player;
		}

	public string GetBestScorePlayer()
		{
		return bestScorePlayer;
		}

	public int GetBestScore()
		{
		return bestScore;
		}

	[System.Serializable]
	class BestScoreData
		{

		public string bestScorePlayer;
		public int bestScore;

		}

	public void SaveData()
		{

		BestScoreData data = new BestScoreData();

		data.bestScorePlayer = GetBestScorePlayer();
		data.bestScore = GetBestScore();

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
		
		}

	public void LoadData()
		{

		string path = Application.persistentDataPath + "/savefile.json";

		if (File.Exists(path))
			{
			string json = File.ReadAllText(path);
			BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);

			SetBestScore(data.bestScore, data.bestScorePlayer);
			}
		else
			{
			SetBestScore(0, null);
			}

		}

	}
