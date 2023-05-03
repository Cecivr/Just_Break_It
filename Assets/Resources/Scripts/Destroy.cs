using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    GetBlocks list;
    Animator anim;
    PowerUps pU;
    public bool isPoweredUp;
    private void Start()
    {
        list = GameObject.Find("Core").GetComponent<GetBlocks>();
        anim = GetComponent<Animator>();
        pU = GameObject.Find("Core").GetComponent<PowerUps>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if(gameObject.tag == "OneSide")
            {
                StartCoroutine(tiempoOneSide());
            }
            if(gameObject.tag == "Normal")
            {
                StartCoroutine(tiempoNormal());
            }
        }
    }
    private IEnumerator tiempoNormal()
    {
        anim.SetBool("isDestroyed", true);
        list.blocks.Remove(gameObject);
        gameObject.GetComponent<Collider2D>().enabled = false;
        if(isPoweredUp == true)
        {
            GameObject power = Instantiate(pU.powerUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
    private IEnumerator tiempoOneSide()
    {
        anim.SetBool("isDestroyed", true);
        list.blocks.Remove(gameObject);
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponentInChildren<Collider2D>().enabled = false;
        if (isPoweredUp == true)
        {
            GameObject power = Instantiate(pU.powerUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
