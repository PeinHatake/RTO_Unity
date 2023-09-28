using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EquipmentSlot : UI_ItemSlot
{
    public EquipmentType equipmentType;

    private void OnValidate() {
        gameObject.name = "Equipment Type - " + equipmentType.ToString() ;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        Inventory.instance.UnEquipItem(item.data as ItemData_Equipment);
        Inventory.instance.AddItem(item.data as ItemData_Equipment);
        CleanUpSlot();
    }
}
