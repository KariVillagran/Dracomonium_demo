using UnityEngine;
using System.Collections;

public class CameraMov : MonoBehaviour {

	public static int turno = 0;
	public int momento;
	public Animator anim;

	void Update() {
		momento = turno;
		if (momento == 1){
			anim.SetInteger("turnos",0);
			Detener(2f);
			anim.SetInteger("turnos",turno);
			Dispara();
		}
		if (momento == 2){
			anim.SetInteger("turnos",0);
			Detener(2f);
			anim.SetInteger("turnos",turno);
			Dispara();
		}
		if (momento == 3){
			anim.SetInteger("turnos",0);
			Detener(2f);
			anim.SetInteger("turnos",turno);
			Dispara();
		}
		if (momento == 4){
			anim.SetInteger("turnos",0);
			Detener(2f);
			anim.SetInteger("turnos",turno);
			Dispara();
		}
		if (momento == 5){
			anim.SetInteger("turnos",0);
			Detener(2f);
			anim.SetInteger("turnos",turno);
			Dispara();
		}
		if (momento == 6){
			anim.SetInteger("turnos",0);
			Detener(2f);
			anim.SetInteger("turnos",turno);
			Dispara();
		}
	}

	void Dispara() {
		if (Input.GetMouseButtonUp(0) == true) {
				anim.SetInteger ("turnos", 0);
				Detener(0.75f);
		}
	}

	IEnumerator Detener(float seconds){
		yield return new WaitForSeconds(seconds);
	}
}
