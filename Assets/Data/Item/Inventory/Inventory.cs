using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : TestMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    protected override void Start()
    {
        base.Start();
        /*this.AddItem(ItemCode.HeathPoint, 3);*/
    }

    public virtual bool AddItem(ItemCode itemCode, int addCout)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);

        int newCout = itemInventory.itemCout + addCout;
        if (newCout > itemInventory.maxStack) return false;

        itemInventory.itemCout = newCout;
        return true;
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }

    public virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;

        }

        return null;
    }
}
