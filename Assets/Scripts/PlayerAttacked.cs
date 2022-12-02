using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.PlayerLoop.PreLateUpdate;

public class PlayerAttacked : MonoBehaviour
{
    public bool beingAttacked;
    private TextMeshProUGUI text;
    private PlayerMotivation motivation;
    private ButtonMashing mash;
    private PlayerMovement playerMov;
    private MonsterMind monsterMind;
    private InventoryScript inv;
    private ActiveItem act;
    private Animator anim;



    int attacked;
    private int nextUpdate = 1;

    void Start()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
        monsterMind = GameObject.Find("Monster").GetComponent<MonsterMind>();
        text = GameObject.Find("MashText").GetComponent<TextMeshProUGUI>();
        text.enabled = false;
        motivation = GameObject.Find("Player").GetComponent<PlayerMotivation>();
        mash = GameObject.Find("Player").GetComponent<ButtonMashing>();
        playerMov = GameObject.Find("Player").GetComponentInChildren<PlayerMovement>();
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        act = GameObject.Find("Player").GetComponentInChildren<ActiveItem>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextUpdate)
        {
    
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
        if (beingAttacked)
        {
            mash.StartButtonMash();
            text.enabled = true;
            playerMov.canMove = false;
            inv.selectedItem = 0;
            act.ChangeHeldItem();
            anim.SetBool("Attacked", true);
            inv.disabled = true;
        }
        if (!beingAttacked)
        {
            text.enabled = false;
            mash.StopButtonMash();
            playerMov.canMove = true;
            inv.disabled = false;
            anim.SetBool("Attacked", false);

        }
        if (attacked >= 5)
        {
            beingAttacked = false;
            attacked = 0;
            monsterMind.suspicion = 0;

        }
        if (mash.mashingFailed)
        {
            beingAttacked = false;
            attacked = 0;
        }

        }
    public void UpdateEverySecond()
    {
        if (beingAttacked)
        {
            attacked++;
            motivation.LowerMotivation(5);
        }
    }

}
