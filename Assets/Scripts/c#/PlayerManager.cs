using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerManager {

	public List<Dragon> dragonesPartida = new List<Dragon>();

	public PlayerManager() {}

	public void initGame()
	{
		resetGame ();
		Dragon dragon_01 = new Dragon(Elementos.Fuego.ToString(),
		                              200, // daño base
		                              Random.Range(0,20), // daño critico
		                              Random.Range(0,50), // daño azar
		                              0, // bono elemento
		                              Jugadores.Jugador_uno.ToString(), // jugador propietario
		                              true, // turno
		                              1000); // vida
		Dragon dragon_02 = new Dragon(Elementos.Hielo.ToString(),
		                              200, // daño base
		                              Random.Range(0,20), // daño critico
		                              Random.Range(0,50), // daño azar
		                              0, // bono elemento
		                              Jugadores.Jugador_uno.ToString(), // jugador propietario
		                              false, // turno
		                              1000); // vida
		Dragon dragon_03 = new Dragon(Elementos.Sombra.ToString(),
		                              200, // daño base
		                              Random.Range(0,20), // daño critico
		                              Random.Range(0,50), // daño azar
		                              0, // bono elemento
		                              Jugadores.Jugador_uno.ToString(), // jugador propietario
		                              false, // turno
		                              1000); // vida
		
		Dragon dragon_04 = new Dragon(Elementos.Fuego.ToString(),
		                              200, // daño base
		                              Random.Range(0,20), // daño critico
		                              Random.Range(0,50), // daño azar
		                              0, // bono elemento
		                              Jugadores.Jugador_dos.ToString(), // jugador propietario
		                              false, // turno
		                              1000); // vida
		Dragon dragon_05 = new Dragon(Elementos.Hielo.ToString(),
		                              200, // daño base
		                              Random.Range(0,20), // daño critico
		                              Random.Range(0,50), // daño azar
		                              0, // bono elemento
		                              Jugadores.Jugador_dos.ToString(), // jugador propietario
		                              false, // turno
		                              1000); // vida
		Dragon dragon_06 = new Dragon(Elementos.Sombra.ToString(),
		                              200, // daño base
		                              Random.Range(0,20), // daño critico
		                              Random.Range(0,50), // daño azar
		                              0, // bono elemento
		                              Jugadores.Jugador_dos.ToString(), // jugador propietario
		                              false, // turno
		                              1000); // vida

		dragonesPartida.Add (dragon_01);
		dragonesPartida.Add (dragon_02);
		dragonesPartida.Add (dragon_03);
		dragonesPartida.Add (dragon_04);
		dragonesPartida.Add (dragon_05);
		dragonesPartida.Add (dragon_06);
	}

	public bool getTurno(int dragon)
	{
		bool turno = false;
		turno = dragonesPartida [dragon].TurnoDragon;
		return turno;		
	}
	
	public void setTurno(int dragonObt)
	{
		dragonesPartida[0].TurnoDragon = false;
		dragonesPartida[1].TurnoDragon = false;
		dragonesPartida[2].TurnoDragon = false;
		dragonesPartida[3].TurnoDragon = false;
		dragonesPartida[4].TurnoDragon = false;
		dragonesPartida[5].TurnoDragon = false;
		switch (dragonObt)
		{
			case 0:
				dragonesPartida[0].TurnoDragon = true;
				break;
			case 1:
				dragonesPartida[1].TurnoDragon = true;
				break;
			case 2:	
				dragonesPartida[2].TurnoDragon = true;
				break;
			case 3:
				dragonesPartida[3].TurnoDragon = true;
				break;
			case 4:
				dragonesPartida[4].TurnoDragon = true;
				break;
			case 5:
				dragonesPartida[5].TurnoDragon = true;
				break;
		}		
	}

	public void Score(int ataque, int dragon)
	{
		dragonesPartida [dragon].Vida_dragon = dragonesPartida [dragon].Vida_dragon - ataque;
	}

	public bool isDead(int dragon)
	{
		if(dragonesPartida [dragon].Vida_dragon <= 0)
		{
			dragonesPartida [dragon].IsLive = false;
		}
		return dragonesPartida [dragon].IsLive;
	}

	public int getLife(int dragon)
	{
		return dragonesPartida [dragon].Vida_dragon;
	}
	
	public int getWin()
	{	
		int mensaje = 0;
		if (!dragonesPartida [0].IsLive && !dragonesPartida [1].IsLive && !dragonesPartida [2].IsLive)
		{
			mensaje = 1;
		}
		if (!dragonesPartida [3].IsLive && !dragonesPartida [4].IsLive && !dragonesPartida [5].IsLive)
		{
			mensaje = 2;
		}
		return mensaje;
	}


	public void resetGame()
	{
		dragonesPartida = new List<Dragon>();
	}

	public int getVida(int draco)
	{
		return dragonesPartida[draco].Vida_dragon;
	}

}
