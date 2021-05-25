using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemId = 0;
    public string itemName = "item";
    public string description = "Does New Things";
    public enum Type { Default = 0, Consumable, Weapon }
    public Type type = Type.Default;
    public Inventory inv;

    
    void Start()
    {
        inv = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            var radius = 10;
            var selected = Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2,
                    Camera.main.nearClipPlane)), out hit, radius);
            if (selected) 
            { 
                if (hit.collider.CompareTag("collectable"))
                {
                    inv.AddItem(this.itemName);
                    
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}