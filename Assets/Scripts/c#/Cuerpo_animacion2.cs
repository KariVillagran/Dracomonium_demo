using UnityEngine;
using System.Collections;

public class Cuerpo_animacion2 : MonoBehaviour {

	public Animator an;
	int vida = 1000;

	void Start () {
	
	}
	
	void Update () {
		if((GameManager.getLife(4) < vida) == true)
		{
			vida = GameManager.getLife(4);
			an.SetTrigger("golpe");
		}
	}
}
