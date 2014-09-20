using UnityEngine;

[AddComponentMenu("Destructible 2D/D2D Drag To Shoot")]
public class D2D_DragToShoot : MonoBehaviour
{
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

	protected virtual void Update()
	{
		if (Input.GetMouseButton(0) == true && down == false && Time.timeScale == 1)
		{
			down = true;			
			startMousePosition = Input.mousePosition;
		}

		mouse_pos = Input.mousePosition;
		object_pos = Camera.main.WorldToScreenPoint(SpawnPoint.transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		var angle2 = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;

		if (Input.GetMouseButton(0) == false && down == true)
		{
			down = false;
			if (angle2 < 50 && angle2 > -50) 
			{
				if (Camera.main != null && Bullet != null)
				{

						var endMousePosition = Input.mousePosition;
						var startPos         = Camera.main.ScreenToWorldPoint(startMousePosition);
						var endPos           = Camera.main.ScreenToWorldPoint(endMousePosition);
						var vec              = (endPos - startPos) * Power;
						var angle            = D2D_Helper.Atan2(vec) * -Mathf.Rad2Deg + AngleOffset + Random.Range(-0.5f, 0.5f) * AngleRandomness;
						Vector3 rotationVector  = new Vector3 (0, 0, angle2);
						SpawnPoint.transform.rotation = Quaternion.Euler (rotationVector);
						var clone            = D2D_Helper.CloneGameObject(Bullet, null, SpawnPoint.transform.position, Quaternion.Euler(0.0f, 0.0f, angle2));
						var cloneRb2D        = clone.GetComponent<Rigidbody2D>();

						if (cloneRb2D != null)
						{
							cloneRb2D.velocity = (endPos - startPos) * Power;
							cloneRb2D.AddForce(new Vector2(100,50));
						}
				}
			}
		}

		if (Indicator != null && angle2 < 50 && angle2 > -50)
		{
			Indicator.enabled = down;
			if (Camera.main != null && down == true)
			{
				var currentMousePosition = Input.mousePosition;
				var startPos         	 = Camera.main.ScreenToWorldPoint(SpawnPoint.transform.position);
				var currentPos           = Camera.main.ScreenToWorldPoint(currentMousePosition);
				var scale                = Vector3.Distance(currentPos, startPos);
				Debug.Log(scale);
				Indicator.transform.position = SpawnPoint.transform.position;				
				Indicator.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle2);
				Indicator.transform.localScale    = new Vector3(scale/15, scale/15, scale/15);
			}
		}
	}
}