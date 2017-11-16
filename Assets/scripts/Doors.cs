using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : Collectable {
	public int level = 1;

	protected override void OnRabitHit(HeroRabit rabit) {
		if(level == 1 || LevelStatistic.load(level-1).levelPassed)
			SceneManager.LoadScene ("Level" + level);
	}

}
