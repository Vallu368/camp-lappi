using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItem : MonoBehaviour
{
    public GameObject currentHeldItem;
    public InventoryScript inv;
    public Animator anim;
        
    void Start()
    {
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        anim = this.gameObject.GetComponentInParent<Animator>();
        ChangeHeldItem();
    }

    // Update is called once per frame
    void Update()
    {
        currentHeldItem = this.gameObject.transform.GetChild(0).gameObject;
        if (currentHeldItem.tag == "Compass")
        {
            anim.SetBool("CompassActive", true);
        }
        else
        {
            anim.SetBool("CompassActive", false);

        }
        if ((currentHeldItem.tag == "Item"))
        {
            anim.SetBool("OtherActive", true);

        }
        else
        {
            anim.SetBool("OtherActive", false);

        }
        if ((currentHeldItem.tag == "Weapon"))
        {
            anim.SetBool("WeaponActive", true);

        }
        else
        {
            anim.SetBool("WeaponActive", false);

        }

    }
    public void InstantiateObject(GameObject gameObject)
    {

        Instantiate(gameObject, transform);
    }
    public IEnumerator ChangeItem()
    {
        anim.SetBool("Reset", true);
        yield return new WaitForSeconds(0.1f);
        ChangeHeldItem();
        anim.SetBool("Reset", false);
        yield return null;
    }

    public void ChangeHeldItem() {
        anim.SetBool("Reset", true);
        Destroy(currentHeldItem);
        InstantiateObject(inv.items[inv.selectedItem].itemPrefab);
        

    }
}
