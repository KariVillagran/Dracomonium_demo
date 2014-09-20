using UnityEngine;
using System.Collections;

public class InitGame : MonoBehaviour {

	public static int preparate = 0;

	public static bool activaIzqAtaca = false;
	public static bool activaDraAtaca = false;

	public static int dragon_ejecutor = 1;
	public static int dragon_ejecutor2 = 0;
	public int paso = 0;
	public int paso2 = 0;

	public ArrayList dragonesA = new ArrayList();
	public ArrayList dragonesB = new ArrayList();

	void Awake()
	{
		GameManager.initGame();
		dragon_ejecutor = 1;
		dragon_ejecutor2 = 0;
		paso = 0;
		paso2 = 0;
		activaDraAtaca = false;
		activaIzqAtaca = false;
		preparate = 0;
	}

	void Start () {
		preparate = 0;
		dragonesA.Add (Codigo_dragon.Dragon_1_1);
		dragonesA.Add (Codigo_dragon.Dragon_2_1);
		dragonesA.Add (Codigo_dragon.Dragon_3_1);

		dragonesB.Add (Codigo_dragon.Dragon_1_2);
		dragonesB.Add (Codigo_dragon.Dragon_2_2);
		dragonesB.Add (Codigo_dragon.Dragon_3_2);
	}

	void Update () {
		ArrayList listaa = new ArrayList();
		ArrayList listab = new ArrayList();
		foreach(int draco in dragonesB)
		{
			if(GameManager.isLife(draco))
			{
				listab.Add(draco);
			}
		}
		foreach(int draco in dragonesA)
		{
			if(GameManager.isLife(draco))
			{
				listaa.Add(draco);
			}
		}
		dragonesB = listab;
		dragonesA = listaa;

		if(activaIzqAtaca)
		{
			activaIzqAtaca = false;
			if(dragon_ejecutor2 >= dragonesB.Count)
			{
				dragon_ejecutor2 = 0;
			}
			if(!GameManager.isLife((int)Codigo_dragon.Dragon_1_2) && paso == 0)
			{
				dragon_ejecutor2 = 0;
				paso = 1;
			}
			GameManager.setTurno((int)dragonesB[dragon_ejecutor2]);
			dragon_ejecutor2++;

		}
		if(activaDraAtaca)
		{
			activaDraAtaca = false;
			if(dragon_ejecutor >= dragonesA.Count)
			{
				dragon_ejecutor = 0;
			}
			if(!GameManager.isLife((int)Codigo_dragon.Dragon_1_1) && paso2 == 0)
			{
				dragon_ejecutor = 0;
				paso2 = 1;
			}
			GameManager.setTurno((int)dragonesA[dragon_ejecutor]);
			dragon_ejecutor++;
		}
		if(GameManager.getWin()== 1)
		{
			Application.LoadLevel(8);
		}
		if(GameManager.getWin() == 2)
		{
			Application.LoadLevel(7);
		}
	}	
}
