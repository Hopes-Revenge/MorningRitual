using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
    Grid grid;
    List<GameObject> blocks = new List<GameObject>();
    Sprite[] grassSprites;
    public void OnEnable()
    {
        grid = (Grid)target;
        grassSprites = grid.grassSprites;
        SceneView.onSceneGUIDelegate = GridUpdate;
    }
    void GridUpdate(SceneView sceneview)
    {
        Event e = Event.current;

        Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
        Vector3 mousePos = r.origin;

        if (e.isKey && e.character == 'a')
        {
            GameObject obj;
            Object prefab = PrefabUtility.GetPrefabParent(Selection.activeObject);

            if (prefab)
            {
                Undo.IncrementCurrentGroup();
                obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                blocks.Add(obj);
                Vector3 aligned = new Vector3(Mathf.Floor(mousePos.x / grid.width) * grid.width + grid.width / 2.0f,
                                  Mathf.Floor(mousePos.y / grid.height) * grid.height + grid.height / 2.0f, 0.0f);

                int blockOrientation = 0;
                for (int i = blocks.Count - 1; i >= 0; i--)
                {
                    if (blocks[i] == null || blocks[i].transform.position == aligned)
                    {
                        DestroyImmediate(blocks[i]);
                        blocks.RemoveAt(i);
                    }
                    Debug.Log("aligned=" + aligned + " Block Position=" + blocks[i].transform.position);
                }
                obj.transform.position = aligned;
                obj.transform.SetParent(GameObject.Find("Grid").transform);
                if (obj.tag == "Grass")
                {
                    for (int i = blocks.Count - 1; i >= 0; i--)
                    {
                        blockOrientation = 15;
                        Vector3 up = new Vector3(blocks[i].transform.position.x, blocks[i].transform.position.y + 1.0f, 0.0f);
                        Vector3 down = new Vector3(blocks[i].transform.position.x, blocks[i].transform.position.y - 1.0f, 0.0f);
                        Vector3 left = new Vector3(blocks[i].transform.position.x - 1.0f, blocks[i].transform.position.y, 0.0f);
                        Vector3 right = new Vector3(blocks[i].transform.position.x + 1.0f, blocks[i].transform.position.y, 0.0f);
                        for (int j = blocks.Count - 1; j >= 0; j--)
                        {
                            if (blocks[j].transform.position == up) blockOrientation -= 1;
                            if (blocks[j].transform.position == down) blockOrientation -= 2;
                            if (blocks[j].transform.position == left) blockOrientation -= 4;
                            if (blocks[j].transform.position == right) blockOrientation -= 8;
                        }
                        blocks[i].GetComponent<SpriteRenderer>().sprite = grassSprites[blockOrientation];
                    }
                }
                Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
            }
        }
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
