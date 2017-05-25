using UnityEngine;
using System.Collections;
using System;

public class PlayerManager : MonoBehaviour {
    public GameObject enemyClicked = null;
    bool outDown = true;
    public float outlineSpeed = 0.05f;
	void Update()
    {
        ClickEnemy();
        //  OutliningEnemy();
        followCharacter();
       
    }

    private void followCharacter()
    {
        
    }

    void ClickEnemy()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(1).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
            RaycastHit hit;
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                print("geklickt");
                if (hit.collider.gameObject.tag.Equals("Enemy"))
                {
                    if (enemyClicked != null)
                    {
                        enemyClicked.GetComponent<Renderer>().materials[1].SetColor("_OutlineColor", Color.black);
                    }
                    print("gegner angeklickt");
                    enemyClicked = hit.collider.gameObject;
                    enemyClicked.GetComponent<Renderer>().materials[1].SetColor("_OutlineColor", Color.red);
                }
                else 
                {
                    if (enemyClicked != null)
                    {

                        enemyClicked.GetComponent<Renderer>().materials[1].SetColor("_OutlineColor", Color.black);
                        enemyClicked = null;
                    }
                }
            }
        }
    }
    
    void OutliningEnemy()
    {
        if (enemyClicked != null)
        {
            float outline = enemyClicked.GetComponent<Renderer>().material.GetFloat("_Outline");
            if (outDown)
            {
                outline -= outlineSpeed;
            }
            else if (!outDown)
            {
                outline += outlineSpeed;
            }
            if (outline <= 5)
            {
                outDown = false;
            }
            else if (outline >= 10)
            {
                outDown = true;
            }
            enemyClicked.GetComponent<Renderer>().material.SetFloat("_Outline", outline);

        }
    }

    public bool hasEnemy()
    {
        return enemyClicked != null;
    }
    public Vector3 getEnemyPosition()
    {

        return enemyClicked.transform.position;
    }
    

}
