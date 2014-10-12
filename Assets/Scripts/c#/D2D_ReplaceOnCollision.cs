using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Destructible 2D/D2D Replace On Collision")]
public class D2D_ReplaceOnCollision : MonoBehaviour
{
	public float RelativeVelocityRequired;
	public GameObject Spawn;
	public static int lado = 0 ;
	public static int disparo_curso = 1;
	public int find_gem;
	public int option_gem;
	public string tipo_gema;

	void Awake()
	{
		find_gem = 0;
		option_gem = 0;
		lado = 0;
		disparo_curso = 0;
		tipo_gema = "";
	}
	
	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
		//find_gem = Random.Range (1, 300);
		find_gem = 137;
		option_gem = Random.Range (0, 4);
		tipo_gema = getTextoGema (option_gem);

		if (collision.gameObject.name.Equals ("cuerpo_der1")) 
		{
			GameManager.score(500,(int)Codigo_dragon.Dragon_1_2);
			InitGame.activaIzqAtaca = true;
			disparo_curso = 0;
		}
		if (collision.gameObject.name.Equals ("cuerpo_der2")) 
		{
			GameManager.score(500,(int)Codigo_dragon.Dragon_2_2);
			InitGame.activaIzqAtaca = true;
			disparo_curso = 0;
		}
		if (collision.gameObject.name.Equals ("cuerpo_der3")) 
		{
			GameManager.score(500,(int)Codigo_dragon.Dragon_3_2);
			InitGame.activaIzqAtaca = true;
			disparo_curso = 0;
		}
		if (collision.gameObject.name.Equals ("cuerpo_izq1")) 
		{
			GameManager.score(500,(int)Codigo_dragon.Dragon_1_1);
			InitGame.activaDraAtaca = true;
			disparo_curso = 0;
		}
		if (collision.gameObject.name.Equals ("cuerpo_izq2")) 
		{
			GameManager.score(500,(int)Codigo_dragon.Dragon_2_1);
			InitGame.activaDraAtaca = true;
			disparo_curso = 0;
		}
		if (collision.gameObject.name.Equals ("cuerpo_izq3")) 
		{
			GameManager.score(500,(int)Codigo_dragon.Dragon_3_1);
			InitGame.activaDraAtaca = true;
			disparo_curso = 0;
		}
		if(lado == 1)
		{
			lado = 0;
			InitGame.activaIzqAtaca = true;
			disparo_curso = 0;
			if(find_gem == 137 && collision.gameObject.name.Equals ("Edge Colliders"))
			{
				find_gem = 1;
				if(Config_gemas.countJ1() == 2)
				{
					cp_find_gema3.gemaSel = option_gem;
					cp_find_gema3.seting = 1;
					Config_gemas.addGema1(new Gems(option_gem,tipo_gema));
				}
				if(Config_gemas.countJ1() == 1)
				{
					cp_find_gema2.gemaSel = option_gem;
					cp_find_gema2.seting = 1;
					Config_gemas.addGema1(new Gems(option_gem,tipo_gema));
				}
				if(Config_gemas.countJ1() == 0)
				{
					cp_find_gema1.gemaSel = option_gem;
					cp_find_gema1.seting = 1;
					Config_gemas.addGema1(new Gems(option_gem,tipo_gema));
				}
			}
		}
		if(lado == 2)
		{
			lado = 0;
			InitGame.activaDraAtaca = true;
			disparo_curso = 0;
			if(find_gem == 167 && collision.gameObject.name.Equals ("Edge Colliders"))
			{
				find_gem = 1;
				if(Config_gemas.countJ2() == 2)
				{
					cp_find_gema6.gemaSel = option_gem;
					cp_find_gema6.seting = 1;
					Config_gemas.addGema2(new Gems(option_gem,tipo_gema));
				}
				if(Config_gemas.countJ2() == 1)
				{
					cp_find_gema5.gemaSel = option_gem;
					cp_find_gema5.seting = 1;
					Config_gemas.addGema2(new Gems(option_gem,tipo_gema));
				}
				if(Config_gemas.countJ2() == 0)
				{
					cp_find_gema4.gemaSel = option_gem;
					cp_find_gema4.seting = 1;
					Config_gemas.addGema2(new Gems(option_gem,tipo_gema));
				}
			}
		}

		Destroy(gameObject);
		disparo_curso = 1;
		
		if (Spawn != null)
		{
			if (collision.relativeVelocity.magnitude >= RelativeVelocityRequired)
			{
				var contact0 = collision.contacts[0];
				
				Instantiate(Spawn, contact0.point, transform.rotation);
			}
		}
	}

	protected string getTextoGema(int gema)
	{
		string resul = "";
		if((int)Gemas.Diamante == gema)
		{
			resul = "diamante";
		}
		if((int)Gemas.Caurzo == gema)
		{
			resul = "cuarzo";
		}
		if((int)Gemas.Rubi == gema)
		{
			resul = "rubi";
		}
		if((int)Gemas.Topacio == gema)
		{
			resul = "topacio";
		}
		return resul;
	}
}