using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Interactable : MonoBehaviour
{
    public GameObject sign;

    public virtual void Start()
    {
        sign.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
            sign.SetActive(true); 
            collision.GetComponent<Player>().TurnOnInteractPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sign.SetActive(false);
            collision.GetComponent<Player>().TurnOffInteractPanel();
        }
    }

    public virtual void Interact()
    {
        Debug.Log(gameObject.name + "상호작용함");
    }
}
