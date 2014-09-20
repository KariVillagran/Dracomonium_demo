using UnityEngine;
using System.Collections.Generic;

public enum D2D_SpriteColliderType
{
	None,
	Edge,
	Polygon,
	AutoPolygon
}

[ExecuteInEditMode]
[AddComponentMenu("Destructible 2D/D2D Destructible Sprite")]
[RequireComponent(typeof(SpriteRenderer))]
public class D2D_DestructibleSprite : D2D_Destructible
{
	public static List<D2D_DestructibleSprite> DestructibleSprites = new List<D2D_DestructibleSprite>();
	
	public Texture2D MainTex;
	
	public float PixelsToUnits = 100.0f;
	
	public Vector2 Pivot = new Vector2(0.5f, 0.5f);
	
	public Material SourceMaterial;
	
	[D2D_RangeAttribute(1.0f, 10.0f)]
	public float Sharpness = 1.0f;
	
	public D2D_SpriteColliderType ColliderType = D2D_SpriteColliderType.None;
	
	[SerializeField]
	private SpriteRenderer spriteRenderer;
	
	[SerializeField]
	private Sprite sprite;
	
	[SerializeField]
	private D2D_EdgeColliders edgeColliders;
	
	[SerializeField]
	private D2D_PolygonColliders polygonColliders;
	
	[SerializeField]
	private D2D_AutoPolygonCollider autoPolygonCollider;
	
	[SerializeField]
	private float expectedPixelsToUnits;
	
	[SerializeField]
	private Vector2 expectedPivot;
	
	[SerializeField]
	private Material clonedMaterial;
	
	public override Matrix4x4 WorldToPixelMatrix
	{
		get
		{
			if (AlphaTex != null && sprite != null)
			{
				var ratio = D2D_Helper.Divide(AlphaTex.width, AlphaTex.height, sprite.bounds.size.x, sprite.bounds.size.y); // Account for Pixels To Units setting
				var s     = D2D_Helper.ScalingMatrix(ratio.x, ratio.y, 1.0f);
				var t     = D2D_Helper.TranslationMatrix(-sprite.bounds.min); // Account for sprite pivot
				
				return s * t * transform.worldToLocalMatrix;
			}
			
			return transform.worldToLocalMatrix;
		}
	}
	
	public Vector2 WorldToPixelPoint(Vector3 point)
	{
		return LocalToPixelPoint(transform.InverseTransformPoint(point));
	}
	
	public Vector2 LocalToPixelPoint(Vector3 point)
	{
		if (sprite != null && AlphaTex != null)
		{
			var pixel = default(Vector2);
			
			pixel.x = Mathf.InverseLerp(sprite.bounds.min.x, sprite.bounds.max.x, point.x) * AlphaTex.width;
			pixel.y = Mathf.InverseLerp(sprite.bounds.min.y, sprite.bounds.max.y, point.y) * AlphaTex.height;
			
			return pixel;
		}
		
		return Vector2.zero;
	}
	
	[ContextMenu("Halve Alpha Tex And Split Min Pixels")]
	public void HalveAlphaTexAndSplitMinPixels()
	{
		if (AlphaTex != null)
		{
			HalveAlphaTex();
			
			SplitMinPixels = Mathf.Max(1, SplitMinPixels / 2);
		}
	}
	
	[ContextMenu("Blur Alpha Tex And Double Sharpness")]
	public void BlurAlphaTexAndDoubleSharpness()
	{
		if (AlphaTex != null)
		{
			BlurAlphaTex();
			
			Sharpness *= 2;
		}
	}
	
	// Used to fix possible sprite udating bug when changing Unity versions
	[ContextMenu("Force Destroy Sprite")]
	public void ForceDestroySprite()
	{
		DestroySprite();
	}
	
	public void RebuildColliders()
	{
		if (AlphaTex != null && AlphaTex.width > 0 && AlphaTex.height > 0)
		{
			RebuildColliders(0, AlphaTex.width, 0, AlphaTex.height);
		}
	}
	
	protected virtual void Awake()
	{
		if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
		
		// Copy texture from sprite?
		if (MainTex == null)
		{
			var sprite = spriteRenderer.sprite;
			
			if (sprite != null)
			{
				var texture = sprite.texture;
				
				if (texture != null)
				{
					MainTex       = texture;
					Pivot         = D2D_Helper.Divide(-sprite.bounds.min.x, -sprite.bounds.min.y, sprite.bounds.size.x, sprite.bounds.size.y);
					PixelsToUnits = D2D_Helper.Divide(texture.width, sprite.bounds.size.x);
					
					if (sprite.rect.x != 0 || sprite.rect.y != 0 || sprite.rect.width != texture.width || sprite.rect.height != texture.height)
					{
						Debug.LogWarning("The sprite '" + name + "' sent to D2D_DestructibleSprite is either trimmed, or is part of a multiple sprite collection. This is currently not supported.");
					}
				}
			}
		}
	}
	
	protected override void OnEnable()
	{
		base.OnEnable();
		
		DestructibleSprites.Add(this);
	}
	
	protected override void OnDisable()
	{
		base.OnDisable();
		
		DestructibleSprites.Remove(this);
	}
	
	protected virtual void Update()
	{
		// Copy alpha from main tex
		if (AlphaTex == null && MainTex != null)
		{
			ReplaceAlphaWith(MainTex);
		}
		
#if UNITY_EDITOR
		D2D_Helper.MakeTextureReadable(DensityTex);
#endif
		
		UpdateSprite();
		UpdateColliders();
	}
	
	protected override void OnDestroy()
	{
		base.OnDestroy();
		
		DestroyAutoPolygonCollider();
		DestroyPolygonColliders();
		DestroyEdgeColliders();
		DestroyMaterial();
		DestroySprite();
	}
	
	protected virtual void OnWillRenderObject()
	{
		if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
		
		UpdateSourceMaterial();
		
		DestroyMaterialIfSettingsDiffer();
		
		if (SourceMaterial != null)
		{
			// Clone new material?
			if (clonedMaterial == null)
			{
				clonedMaterial = D2D_Helper.Clone(SourceMaterial, false);
			}
			else
			{
				clonedMaterial.CopyPropertiesFromMaterial(SourceMaterial);
			}
			
			clonedMaterial.hideFlags = HideFlags.DontSave;
			
			clonedMaterial.SetTexture("_MainTex", MainTex);
			clonedMaterial.SetTexture("_AlphaTex", AlphaTex);
			clonedMaterial.SetFloat("_Sharpness", Sharpness);
			
			clonedMaterial.hideFlags = HideFlags.None;
		}
		
		if (spriteRenderer.sharedMaterial != clonedMaterial)
		{
			spriteRenderer.sharedMaterial = clonedMaterial;
		}
	}
	
	protected override void UpdateRect(int xMin, int xMax, int yMin, int yMax)
	{
		RebuildColliders(xMin, xMax, yMin, yMax);
	}
	
	protected override void OnDuplicate()
	{
		base.OnDuplicate();
		
		if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
		
		if (clonedMaterial == spriteRenderer.sharedMaterial)
		{
			clonedMaterial = D2D_Helper.Clone(clonedMaterial);
			
			spriteRenderer.sharedMaterial = clonedMaterial;
		}
	}
	
	private void UpdateSourceMaterial()
	{
		// Do we need to set a source material?
		if (SourceMaterial == null)
		{
			if (spriteRenderer.sharedMaterial != null)
			{
				SourceMaterial = spriteRenderer.sharedMaterial;
			}
			else
			{
				SourceMaterial = Resources.Load<Material>("Sprites-Default (Destructible 2D)");
			}
		}
		
		// Replace Sprites-Default with Sprites-Default (Destructible 2D)?
		if (SourceMaterial != null && SourceMaterial.HasProperty("_AlphaTex") == false)
		{
			if (SourceMaterial.name == "Sprites-Default")
			{
				SourceMaterial = Resources.Load<Material>("Sprites-Default (Destructible 2D)");
			}
		}
	}
	
	private void RebuildColliders(int xMin, int xMax, int yMin, int yMax)
	{
		switch (ColliderType)
		{
			case D2D_SpriteColliderType.Edge:
			{
				if (edgeColliders != null)
				{
					edgeColliders.RebuildColliders(AlphaTex, xMin, xMax, yMin, yMax);
				}
			}
			break;
			
			case D2D_SpriteColliderType.Polygon:
			{
				if (polygonColliders != null)
				{
					polygonColliders.RebuildColliders(AlphaTex, xMin, xMax, yMin, yMax);
				}
			}
			break;
			
			case D2D_SpriteColliderType.AutoPolygon:
			{
				if (autoPolygonCollider != null)
				{
					autoPolygonCollider.RebuildCollider(AlphaTex);
				}
			}
			break;
		}
	}
	
	private void UpdateSprite()
	{
		DestroySpriteIfSettingsDiffer();
		
		// Sprite needs remaking?
		if (sprite == null && MainTex != null)
		{
			sprite                = Sprite.Create(MainTex, new Rect(0, 0, MainTex.width, MainTex.height), Pivot, PixelsToUnits, 0, SpriteMeshType.FullRect);
			expectedPivot         = Pivot;
			expectedPixelsToUnits = PixelsToUnits;
		}
		
		if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
		
		spriteRenderer.sprite = sprite;
	}
	
	private void UpdateColliders()
	{
		if (ColliderType != D2D_SpriteColliderType.None)
		{
			var cellTransform = default(Transform);
			
			switch (ColliderType)
			{
				case D2D_SpriteColliderType.Edge:
				{
					DestroyAutoPolygonCollider();
					DestroyPolygonColliders();
					
					if (edgeColliders == null)
					{
						edgeColliders = D2D_Helper.CreateGameObject("Edge Colliders", transform).AddComponent<D2D_EdgeColliders>();
						edgeColliders.RebuildAllColliders(AlphaTex);
					}
					
					cellTransform = edgeColliders.transform;
				}
				break;
				
				case D2D_SpriteColliderType.Polygon:
				{
					DestroyAutoPolygonCollider();
					DestroyEdgeColliders();
					
					if (polygonColliders == null)
					{
						polygonColliders = D2D_Helper.CreateGameObject("Polygon Colliders", transform).AddComponent<D2D_PolygonColliders>();
						polygonColliders.RebuildAllColliders(AlphaTex);
					}
					
					cellTransform = polygonColliders.transform;
				}
				break;
				
				case D2D_SpriteColliderType.AutoPolygon:
				{
					DestroyPolygonColliders();
					DestroyEdgeColliders();
					
					if (autoPolygonCollider == null)
					{
						autoPolygonCollider = D2D_Helper.CreateGameObject("Auto Polygon Collider", transform).AddComponent<D2D_AutoPolygonCollider>();
						autoPolygonCollider.RebuildCollider(AlphaTex);
					}
					
					cellTransform = autoPolygonCollider.transform;
				}
				break;
			}
			
			if (cellTransform != null)
			{
				var cellScale  = Vector3.one;
				var cellOffset = Vector3.zero;
				
				if (sprite != null && MainTex != null && AlphaTex != null)
				{
					cellScale  = D2D_Helper.Reciprocal(PixelsToUnits) * D2D_Helper.Divide(MainTex.width, MainTex.height, AlphaTex.width, AlphaTex.height);
					cellOffset = sprite.bounds.min; cellOffset.z = 0.0f;
				}
				
				if (cellTransform.localPosition != cellOffset)
				{
					cellTransform.localPosition = cellOffset;
				}
				
				if (cellTransform.localScale != cellScale)
				{
					cellTransform.localScale = cellScale;
				}
			}
		}
		else
		{
			DestroyAutoPolygonCollider();
			DestroyPolygonColliders();
			DestroyEdgeColliders();
		}
	}
	
	private void DestroyMaterialIfSettingsDiffer()
	{
		if (clonedMaterial != null)
		{
			if (SourceMaterial == null)
			{
				DestroyMaterial(); return;
			}
			
			if (clonedMaterial.shader != SourceMaterial.shader)
			{
				DestroyMaterial(); return;
			}
		}
	}
	
	private void DestroySpriteIfSettingsDiffer()
	{
		if (sprite != null)
		{
			if (MainTex == null)
			{
				DestroySprite(); return;
			}
			
			if (sprite.texture != MainTex)
			{
				DestroySprite(); return;
			}
			
			if (expectedPixelsToUnits != PixelsToUnits)
			{
				DestroySprite(); return;
			}
			
			if (expectedPivot != Pivot)
			{
				DestroySprite(); return;
			}
		}
	}
	
	private void DestroyEdgeColliders()
	{
		if (edgeColliders != null)
		{
			D2D_Helper.Destroy(edgeColliders.gameObject);
			
			edgeColliders = null;
		}
	}
	
	private void DestroyPolygonColliders()
	{
		if (polygonColliders != null)
		{
			D2D_Helper.Destroy(polygonColliders.gameObject);
			
			polygonColliders = null;
		}
	}
	
	private void DestroyAutoPolygonCollider()
	{
		if (autoPolygonCollider != null)
		{
			D2D_Helper.Destroy(autoPolygonCollider.gameObject);
			
			autoPolygonCollider = null;
		}
	}
	
	private void DestroySprite()
	{
		D2D_Helper.Destroy(sprite);
		
		sprite = null;
	}
	
	private void DestroyMaterial()
	{
		D2D_Helper.Destroy(clonedMaterial);
		
		clonedMaterial = null;
	}
	
#if UNITY_EDITOR
	[UnityEditor.MenuItem("CONTEXT/SpriteRenderer/Make Destructible", true)]
	private static bool MakeDestructibleValidate(UnityEditor.MenuCommand mc)
	{
		if (mc != null && mc.context != null)
		{
			var spriteRenderer = mc.context as SpriteRenderer;
			
			if (spriteRenderer != null)
			{
				return spriteRenderer.GetComponent<D2D_DestructibleSprite>() == null;
			}
		}
		
		return false;
	}
	
	[UnityEditor.MenuItem("CONTEXT/SpriteRenderer/Make Destructible", false)]
	private static void MakeDestructible(UnityEditor.MenuCommand mc)
	{
		if (mc != null && mc.context != null)
		{
			var spriteRenderer = mc.context as SpriteRenderer;
			
			if (spriteRenderer != null)
			{
				D2D_Helper.GetOrAddComponent<D2D_DestructibleSprite>(spriteRenderer.gameObject);
			}
		}
	}
#endif
}