using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFlower : Collectable {
    public int itemID = 1;
    public GameObject projectPrefab; 

    protected override void OnCollect(GameObject target)
    {
        var equipBehaviour = target.GetComponent<Equip>();
        if (equipBehaviour != null)
        {
            equipBehaviour.currentItem = itemID;
        }

        var shootBehaviour = target.GetComponent<FireProjectile>();
        if (shootBehaviour != null)
        {
            shootBehaviour.projectilePrefab = projectPrefab;
        }
    }
}
