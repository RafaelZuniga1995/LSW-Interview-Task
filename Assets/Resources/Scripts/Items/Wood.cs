using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Wood : MonoBehaviour
{
    [SerializeField] public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Wood.OnCollisionEnter2D() | collision.name: " + collision.gameObject.name);

        if (collision.gameObject.name.Equals("WeaponTrigger") || true)
        {

            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.05f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.05f * hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }

    }

    private void OnMouseDown()
    {
        Vector3Int tilemapPos = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        Debug.Log("Wood.OnMouseDown()" + tilemap.GetTile(tilemap.WorldToCell(tilemapPos)).name);
        WidgetManager.singleton.getInventory().addToInventory(tilemap.GetTile(tilemap.WorldToCell(tilemapPos)).name);
        tilemap.SetTile(tilemap.WorldToCell(tilemapPos), null);


    }
}