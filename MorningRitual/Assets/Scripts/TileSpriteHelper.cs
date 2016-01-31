using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class TileSpriteHelper : MonoBehaviour {

    [Header("Configure")]
    public float tileScale = 1.0f;

    private SpriteRenderer render;
    private MaterialPropertyBlock block;

	// Use this for initialization
	void Start () {
        render = GetComponent<SpriteRenderer>();
        block = new MaterialPropertyBlock();
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
