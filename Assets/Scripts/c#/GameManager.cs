using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static PlayerManager pm = new PlayerManager();

	public static void score(int dano, int dragon)
	{
		pm.Score (dano, dragon);
	}

	public static bool getTurno(int dragon)
	{
		return pm.getTurno (dragon);
	}

	public static void initGame()
	{
		pm.initGame ();
	}

	public static bool isLife(int dragon)
	{
		return pm.isDead (dragon);
	}

	public static int getLife(int dragon)
	{
		return pm.getLife (dragon);
	}

	public static bool isTurno(int dragon)
	{
		return false;
	}

	public static void setTurno(int cede)
	{
		pm.setTurno (cede);
	}

	public static int getWin()
	{
		return pm.getWin ();
	}

	public static int getVida(int draco)
	{
		return pm.getVida(draco);
	}
}
