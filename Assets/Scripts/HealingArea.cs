using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This Script is attatched to a game object that has a collider that isTrigger. It requires the Hero game object to have tag "Hero".
public class HealingArea : MonoBehaviour
{
    private Hero hero;
    private bool heroInArea = false;
    private int healing = 1;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero")) {
            heroInArea = true;
            StartCoroutine(Heal());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            heroInArea = false;
            healing = 1;
        }
    }

    IEnumerator Heal() {
        while (heroInArea && hero.health < hero.MAX_HEALTH) {
            if (hero.health + healing > hero.MAX_HEALTH)
                hero.health = hero.MAX_HEALTH;
            else
                hero.health += healing;
            yield return new WaitForSeconds(3);
            healing *= 2;
        }
    }
}
