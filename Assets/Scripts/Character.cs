using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public abstract class Character : MonoBehaviour {
    public Image icon;
    public float Range;
    public int Life;
    public int Mana;
    public int Level;
    public float attackSpeed=2;
    private float attackTime = 0;
    private GameObject PlayerManager;
    // Update is called once per frame
    void Start()
    {
        PlayerManager = gameObject.transform.parent.gameObject;

    }
    void Update () {
        Action();
        Attack();
	}

    private void Attack()
    {
        if (PlayerManager.GetComponent<PlayerManager>().hasEnemy())
        {
            print((PlayerManager.GetComponent<PlayerManager>().getEnemyPosition() - transform.position).magnitude < Range);
            if ((PlayerManager.GetComponent<PlayerManager>().getEnemyPosition() - transform.position).magnitude < Range)
            {
                if ((attackTime += Time.deltaTime) >= attackSpeed)
                {
                    attackTime = 0;
                    print("attack");
                }
            }
        }
    }

    void Action()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ActionW();
        }else if (Input.GetKeyDown(KeyCode.Q))
        {
            ActionQ();
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            ActionE();
        }else if (Input.GetKeyDown(KeyCode.R))
        {
            Ultimate();
        }
    }
    public void isPassive()
    {
        Debug.Log("Can't use Passive as Active Attack");
    }
    public abstract void ActionQ();
    public abstract void ActionW();
    public abstract void ActionE();
    public abstract void Ultimate();

}
