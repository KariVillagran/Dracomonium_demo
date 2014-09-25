using UnityEngine;
using System.Collections;

public class Cuerpo_animacion4 : MonoBehaviour {

	public Animator an;
	int vida = 1000;

	void Start () {
	
	}
	
	void Update () {
		if((GameManager.getLife(0) < vida) == true)
		{
			vida = GameManager.getLife(0);
			an.SetTrigger("golpe");
		}
		//Debug.Log(an.GetCurrentAnimatorStateInfo(0).IsName("Golpeado"));
	}
}
