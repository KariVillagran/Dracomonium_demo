using UnityEngine;
using System.Collections;

public class Cuerpo_animacion5 : MonoBehaviour {

	public Animator an;
	int vida = 1000;

	void Start () {
	
	}
	
	void Update () {
		if((GameManager.getLife(1) < vida) == true)
		{
			vida = GameManager.getLife(1);
			an.SetTrigger("golpe");
		}
	}
}
