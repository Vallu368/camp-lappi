using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject restart;
    public GameObject spawnPoint;
    public GameObject player;
    public PlayerAttacked attack;
    public PlayerMotivation motiv;
    public PlayerMovement move;
    public FadeToBlack fade;
    public ButtonMashing mash;
    public InventoryScript inv;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = this.gameObject;
        restart = GameObject.Find("Restart");
        player = GameObject.Find("Player");
        motiv = GameObject.Find("Player").GetComponentInChildren<PlayerMotivation>(); ;
        attack = GameObject.Find("Player").GetComponentInChildren<PlayerAttacked>();
        mash = GameObject.Find("Player").GetComponentInChildren<ButtonMashing>();
        move = GameObject.Find("Player").GetComponentInChildren<PlayerMovement>();
        fade = GameObject.Find("Canvas").GetComponent<FadeToBlack>();
        inv = GameObject.Find("Canvas").GetComponent<InventoryScript>();

    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.U))
        {
            MovePlayerToSpawn();
        }   
    }
    public void Continue()
    {
        StartCoroutine(ResetPlayer());
    }
    public void MovePlayerToSpawn()
    {
        player.transform.position = spawnPoint.transform.position;
        Debug.Log("moving player to " + spawnPoint.transform.position);
    }

    public IEnumerator ResetPlayer()
    {
        if (motiv.dead)
        {
            Debug.Log("yee");
            motiv.currentMotivation = 100;
            motiv.dead = false;
            restart.SetActive(false);
            Debug.Log("resetti spaghetti");
            yield return new WaitForSeconds(2f);
            MovePlayerToSpawn();
            StartCoroutine(fade.FadeOut(2f));
            inv.unlockCursor = false;
            move.canMove = true;
            mash.mashingFailed = false;
        }
        else Debug.Log("not dead cant reset");
    }
}


