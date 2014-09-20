using UnityEngine;
using System.Collections;

public class Mueren : MonoBehaviour {
	
	public int identificador;

	void Update () {
		if (GameManager.getVida(identificador) <= 0) {
			Destroy(gameObject); // animacion de muerte x.x
		}
	}
}
