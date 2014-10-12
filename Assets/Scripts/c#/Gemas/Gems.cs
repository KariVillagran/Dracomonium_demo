using UnityEngine;
using System.Collections;

public class Gems {
	public int Id {get; set;} 
	public string Nombre {get; set;}

	public Gems(int _id, string _nombre)
	{ 
		Id = _id;
		Nombre = _nombre;
	}
}

public enum Gemas{
	Topacio = 0,
	Rubi = 1,
	Diamante = 2,
	Caurzo = 3,
}
