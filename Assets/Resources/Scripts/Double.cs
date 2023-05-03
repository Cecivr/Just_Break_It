using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double : MonoBehaviour
{
    [SerializeField]Collider2D[] collidersInChild;
    [SerializeField]bool enabledDone = false;
    SpriteRenderer image;
    GetBlocks list;
    Animator anim;
    PowerUps pU;
    public bool isPoweredUp;
    public bool onePowerUp;
    void Start()
    {
        collidersInChild = GetComponentsInChildren<Collider2D>();
        image = GetComponent<SpriteRenderer>();
        list = GameObject.Find("Core").GetComponent<GetBlocks>();
        pU = GameObject.Find("Core").GetComponent<PowerUps>();
        anim = GetComponent<Animator>();
        isPoweredUp = false;
        onePowerUp = true;
    }
    void Update()
    {
        if(collidersInChild[1] != enabled)
        {
            enabledDone = false;
        }
        if (collidersInChild[1].enabled == false && collidersInChild[2].enabled == false) 
        {
            list.blocks.Remove(gameObject);
            anim.SetBool("isDestroyed", true);
            if (isPoweredUp == true && onePowerUp)
            {
                StartCoroutine(Instantiate());
                onePowerUp = false;
            }
            Destroy(gameObject, 0.3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            if (enabledDone == false)
            {
                collidersInChild[1].enabled = false;
                enabledDone = true;
                anim.SetBool("isBroken", true);
                return;
            }
            if (enabledDone == true)
            {
                StartCoroutine(tiempo());
                return;
            }
        }
    }
    private IEnumerator tiempo()
    {
        yield return new WaitForSeconds(0.1f);
        collidersInChild[2].enabled = false;
    }
    private IEnumerator Instantiate()
    {
        GameObject power = Instantiate(pU.powerUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }
}
