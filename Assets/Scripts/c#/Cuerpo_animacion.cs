using UnityEngine;
using System.Collections;

public class Cuerpo_animacion : MonoBehaviour {

	public Animator an;
	int vida = 1000;

	void Start () {
	
	}
	
	void Update () {
		if((GameManager.getLife(3) < vida) == true)
		{
			vida = GameManager.getLife(3);
			an.SetTrigger("golpe");
		}
	}
}
