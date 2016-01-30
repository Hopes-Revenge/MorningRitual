using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class TileSpriteHelper : MonoBehaviour {

    [Header("Configure")]
    public float tileScale = 1.0f;

    private SpriteRenderer render;
    private MaterialPropertyBlock block = new MaterialPropertyBlock();

	// Use this for initialization
	void Awake () {
        render = GetComponent<SpriteRenderer>();
        ApplyChanges();

    }
	
	// Update is called once per frame
	void Update () {
        ApplyChanges();
    }

    private void ApplyChanges()
    {
        if (render == null) return;
        if(block == null) block = new MaterialPropertyBlock();
        render.GetPropertyBlock(block);
        block.SetFloat("TileScale", 1.0f / tileScale);
        block.SetVector("ObjectSize", transform.localScale);
        render.SetPropertyBlock(block);
    }
}
