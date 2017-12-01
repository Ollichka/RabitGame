using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour {

	public static FruitController current;

	public UILabel fruitsLabel, totalFruitsLabel;

	public HashSet<int> collectedFruits;
	public int totalFruits;

	public void addFruit(int fruitId) {
		this.collectedFruits.Add (fruitId);
	}

	// Use this for initialization
	void Start () {
		LevelStatistic stats = LevelStatistic.load (LevelController.current.level);
		collectedFruits = new HashSet<int>(stats.collectedFruits);

		Fruit[] allFruits = GameObject.FindObjectsOfType<Fruit>();
		this.totalFruits = allFruits.Length;
		totalFruitsLabel.text = totalFruits.ToString();	
	}

	void Update() {
		fruitsLabel.text = (this.collectedFruits.Count).ToString();
	}

	void Awake () {
		current = this;
	}

}
