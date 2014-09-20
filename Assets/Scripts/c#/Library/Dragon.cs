using UnityEngine;
using System.Collections;

[System.Serializable]
public class Dragon {

	string elemento;
	public string Elemento
	{
		get { return elemento; }
		set { elemento = value; }
	}
	int dano_base;
	public int Dano_base
	{
		get{ return dano_base; }
		set{ dano_base = value; }
	}
	int dano_critico;
	public int Dano_critico
	{
		get{ return dano_critico; }
		set { dano_critico = value; }
	}
	int dano_azar;
	public int Dano_azar
	{
		get{ return dano_azar; }
		set{ dano_azar = value;	}
	}
	int bono_elemento;
	public int Bono_elemento
	{
		get{ return bono_elemento; }
		set{ bono_elemento = value; }
	}
	string jugador_propietario;
	public string Jugador_propietario
	{
		get{ return jugador_propietario; }
		set{ jugador_propietario = value; }
	}
	bool turnoDragon;
	public bool TurnoDragon
	{
		get{ return turnoDragon; }
		set{ turnoDragon = value; }
	}
	int vida_dragon;
	public int Vida_dragon
	{
		get{ return vida_dragon; }
		set{ vida_dragon = value; }
	}
	bool isLive;
	public bool IsLive
	{
		get{ return isLive; }
		set{ isLive = value; }
	}
	
	public Dragon(string p_elemento, 
	              int p_dano_base, 
	              int p_dano_critico, 
	              int p_dano_azar, 
	              int p_bono_elemento, 
	              string p_jugador_propietario,
	              bool p_turno_dragon,
	              int p_vida)
	{
		this.Elemento = p_elemento;
		this.Dano_base = p_dano_base;
		this.Dano_critico = p_dano_critico;
		this.Dano_azar = p_dano_azar;
		this.Bono_elemento = p_bono_elemento;
		this.Jugador_propietario = p_jugador_propietario;
		this.TurnoDragon = p_turno_dragon;
		this.Vida_dragon = p_vida;
		this.IsLive = true;
	}
	
	public Dragon()
	{}
}

public enum Elementos {
	Fuego=1,
	Hielo=2,
	Sombra=3,
	Tierra=4
}

public enum Jugadores {
	Jugador_uno=1,
	Jugador_dos=2,
	Maquina=3
}

public enum Codigo_dragon{
	Dragon_1_1 = 0,
	Dragon_2_1 = 1,
	Dragon_3_1 = 2,
	Dragon_1_2 = 3,
	Dragon_2_2 = 4,
	Dragon_3_2 = 5,
}

