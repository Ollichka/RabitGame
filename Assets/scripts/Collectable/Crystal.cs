using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {

	public bool isCollected = false;

	public Type type;

	public enum Type {
		RED, GREEN, BLUE
	}

	protected override void OnRabitHit(HeroRabit rabit) {
		this.CollectedHide();
		LevelController.current.addCrystal (this);
	}

	void Start () {
		LevelStatistic stats = LevelStatistic.load(LevelController.current.level);
		isCollected = stats.collectedCrystals.Contains(type);
		if (isCollected) {
			SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
			Color tmp = sr.color;
				tmp.a = 0.5f;
				sr.color = tmp;
		}
	}

	public void CollectedHide () {
		isCollected = true;
	//	SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
	//	Color tmp = sr.color;
	//	tmp.a = 0.5f;
	//	sr.color = tmp;
		Destroy(this.gameObject);
	}

}
