using UnityEngine;
using System.Collections;

public class Decision {

	public float distancia;

	public float Distancia {
		get {
			return distancia;
		}
		set {
			distancia = value;
		}
	}

	public string debilidad;

	public string Debilidad {
		get {
			return debilidad;
		}
		set {
			debilidad = value;
		}
	}

	public bool obstaculo;

	public bool Obstaculo {
		get {
			return obstaculo;
		}
		set {
			obstaculo = value;
		}
	}

	public int hP;

	public int HP {
		get {
			return hP;
		}
		set {
			hP = value;
		}
	}

	public Decision()
	{
		}





	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
