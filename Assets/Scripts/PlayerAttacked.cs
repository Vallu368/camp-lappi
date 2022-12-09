using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.PlayerLoop.PreLateUpdate;

public class PlayerAttacked : MonoBehaviour
{
    public bool beingAttacked;
    public GameObject spaceBar;
    private PlayerMotivation motivation;
    private ButtonMashing mash;
    private PlayerMovement playerMov;
    private MonsterMind monsterMind;
    private InventoryScript inv;
    private ActiveItem act;
    [HideInInspector] public Animator anim;
    public int playerWeapon; //0 no weapons 1 is stick, 2 is knife
    public float attackedTimer;
    private bool running;



    public int attacked;
    private int nextUpdate = 1;

    void Start()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
        monsterMind = GameObject.Find("Monster").GetComponent<MonsterMind>();
        spaceBar = GameObject.Find("SpaceBar").gameObject;
        spaceBar.SetActive(false);
        motivation = GameObject.Find("Player").GetComponent<PlayerMotivation>();
        mash = GameObject.Find("Player").GetComponent<ButtonMashing>();
        playerMov = GameObject.Find("Player").GetComponentInChildren<PlayerMovement>();
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();
        act = GameObject.Find("Player").GetComponentInChildren<ActiveItem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (inv.hasStick)
        {
            playerWeapon = 1;
        }
        if (inv.hasKnife)
        {
            playerWeapon = 2;
        }
        if (inv.hasKnife && inv.hasStick)
        {
            playerWeapon = 2;
        }
        if (playerWeapon == 0)
        {
            attackedTimer = 10f;    
        }
        if (playerWeapon == 1)
        {
            attackedTimer = 5f;
        }
        if (playerWeapon == 2)
        {
            attackedTimer = 3f;
        }
        if (Time.time >= nextUpdate)
        {
    
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
        if (beingAttacked)
        {
            playerMov.enabled = false;
            mash.StartButtonMash();
            StartCoroutine(SpaceBarFlash());
            playerMov.canMove = false;
            if (playerWeapon == 0)
            {
                inv.selectedItem = 0;
            }
            if (playerWeapon == 1)
            {
                inv.selectedItem = inv.stickIndex;
            }
            if (playerWeapon == 2)
            {
                inv.selectedItem = inv.knifeIndex;
            }
            act.ChangeHeldItem();
            anim.SetBool("Attacked", true);
            inv.disabled = true;
            monsterMind.suspicion = 100;
        }
        if (!beingAttacked)
        {
            playerMov.enabled = true;
            spaceBar.SetActive(false);
            mash.StopButtonMash();
            playerMov.canMove = true;
            inv.disabled = false;
            anim.SetBool("Attacked", false);

        }
        if (attacked >= attackedTimer)
        {
            beingAttacked = false;
            attacked = 0;
            monsterMind.suspicion = 0;
            Debug.Log("amongus");

        }
        if (mash.mashingFailed)
        {
            
            playerMov.enabled = true;
            beingAttacked = false;
            attacked = 0;
        }

        }
    public IEnumerator SpaceBarFlash()
    {
        if (!running)
        {
            if (beingAttacked)
            {
                running = true;
                spaceBar.SetActive(true);
                yield return new WaitForSeconds(0.3f);
                spaceBar.SetActive(false);
                yield return new WaitForSeconds(0.2f);
                running = false;
            }
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
