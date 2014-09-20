using UnityEngine;

[AddComponentMenu("Destructible 2D/D2D Replace On Collision")]
public class D2D_ReplaceOnCollision : MonoBehaviour
{
	public float RelativeVelocityRequired;
	public GameObject Spawn;
	public static int lado = 0 ;
	public static int disparo_curso = 1;

	void Awake()
	{
		lado = 0;
		disparo_curso = 0;
	}
	
	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
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
		}
		if(lado == 2)
		{
			lado = 0;
			InitGame.activaDraAtaca = true;
			disparo_curso = 0;
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
}