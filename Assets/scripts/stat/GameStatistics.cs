using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameStatistics {

	public List<LevelStatistic> levelStats = new List<LevelStatistic>();

	public int collectedCoins = 0;

	public static GameStatistics load() {
		GameStatistics stats = JsonUtility.FromJson<GameStatistics>(PlayerPrefs.GetString("stats", null));
		if (stats == null) return new GameStatistics();
		return stats;
	}

	public void save() {
		Debug.Log ("JsonUtility.ToJson(this) = " + JsonUtility.ToJson (this));
		PlayerPrefs.SetString("stats", JsonUtility.ToJson(this));
	}

}
