using UnityEngine;
using System.Collections;

[AddComponentMenu("Destructible 2D/D2D Drag To Shoot")]
public class Cabeza_izquierda_02 : MonoBehaviour {

	public GameObject Bullet;	
	public float Power = 3.0f;
	private Vector3 mouse_pos;
	public float AngleOffset;
	private Vector3 object_pos;
	public float AngleRandomness;	
	public SpriteRenderer Indicator;	
	private bool down;	
	private Vector3 startMousePosition;	
	public Transform SpawnPoint;
	public static bool turno = true;
	public AudioClip disparo;
	public Animator an;
	
	protected virtual void Update()
	{
		if (GameManager.getTurno(1) == true && GameManager.isLife((int)Codigo_dragon.Dragon_2_1) && D2D_ReplaceOnCollision.disparo_curso == 1) 
		{
			LetPlayer.turno = 2;
			CameraMov.turno = 2;

			mouse_pos = Input.mousePosition;
			object_pos = Camera.main.WorldToScreenPoint (SpawnPoint.transform.position);
			mouse_pos.x = mouse_pos.x - object_pos.x;
			mouse_pos.y = mouse_pos.y - object_pos.y;
			var angle2 = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
			if (angle2 < 50 && angle2 > -50) 
			{
				Vector3 rotationVector2 = new Vector3 (0, 0, angle2);
				transform.rotation = Quaternion.Euler (rotationVector2);
			}

			if (Input.GetMouseButton (0) == true && down == false && Time.timeScale == 1) {
					down = true;			
					//startMousePosition = Input.mousePosition;
				startMousePosition = SpawnPoint.transform.position;
			}

			if (Input.GetMouseButton (0) == false && down == true) 
			{
				down = false;
				if (angle2 < 50 && angle2 > -50) 
				{
					if (Camera.main != null && Bullet != null) 
					{		
						an.SetTrigger("ataque");
						var endMousePosition = Input.mousePosition;
						//var startPos = Camera.main.ScreenToWorldPoint (startMousePosition);
						var startPos = startMousePosition;
						var endPos = Camera.main.ScreenToWorldPoint (endMousePosition);
						var vec = (endPos - startPos) * Power;
						var angle = D2D_Helper.Atan2 (vec) * -Mathf.Rad2Deg + AngleOffset + Random.Range (-0.5f, 0.5f) * AngleRandomness;
						Vector3 rotationVector = new Vector3 (0, 0, angle2);
						SpawnPoint.transform.rotation = Quaternion.Euler (rotationVector);
						Vector3 xSp = SpawnPoint.transform.position;
						xSp.x = xSp.x + 0.5f;		
						var clone = D2D_Helper.CloneGameObject (Bullet, null, xSp, Quaternion.Euler (0.0f, 0.0f, angle2));
						var cloneRb2D = clone.GetComponent<Rigidbody2D> ();
						turno = false;
						audio.clip = disparo;
						audio.Play();
						if (cloneRb2D != null) 
						{
							cloneRb2D.velocity = (endPos - startPos) * Power;
							cloneRb2D.AddForce (new Vector2 (100, 50));
						}
						D2D_ReplaceOnCollision.lado = 1;
					}
				}
			}

			if (Indicator != null && angle2 < 50 && angle2 > -50) 
			{
				Indicator.enabled = down;
				if (Camera.main != null && down == true) 
				{
					var currentMousePosition = Input.mousePosition;
					var startPos = Camera.main.ScreenToWorldPoint (SpawnPoint.transform.position);
					var currentPos = Camera.main.ScreenToWorldPoint (currentMousePosition);
					var scale = Vector3.Distance (currentPos, startPos);
					Indicator.transform.position = SpawnPoint.transform.position;				
					Indicator.transform.localRotation = Quaternion.Euler (0.0f, 0.0f, angle2);
					if(scale/15 > 1)
					{
						scale = 15;
					}
					Indicator.transform.localScale = new Vector3 (scale / 15, scale / 15, scale / 15);
					LetPlayer.turno = 0;
				}
			}
		}
	}
}
