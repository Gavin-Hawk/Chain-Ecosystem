﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Animal_Behavior : MonoBehaviour
{
    //behavior
    public bool herbavor;
    public double lifeTime;
    public double hunger;
    public double thirst;
    public double health;
    public double fear;
    private int priorityMove;
    private bool priorityCheck;
    // 1 = bunny, 2 = bird, 3 = cat, 4 = squirrle
    public int type;
    //life time
    public double lifeTimeWhole;
    public double lifeTimeHalf;
    private float lifeTimeNumber;
    private bool wholeLife = false;
    private float lifeCounter;
    private bool foundFood = false;
    //movement hunger = 1, thirst = 2, fear = 3
    private int priorityBehavior;
    public float speed = 1f;
    private Transform target;
    public Rigidbody rb;
    public Transform transform;
    //self
    public GameObject self;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimeNumber = Random.Range(1f, 2f);
        lifeCounter = 0.0f;
        hunger = 0.0;
        thirst = 0.0;
        fear = 0.0;
        priorityCheck = true;
        if (type == 1)
        {
            health = 20;
        }
        else if (type == 2)
        {
            health = 15;
        }
        else if (health == 3)
        {
            health = 30;
        }
        else if (type == 4)
        {
            health = 10;
        }
        if (lifeTimeNumber == 1)
        {
            wholeLife = true;
        }
    }
    // Update is called once per frame
    void Update()
    {


        countingVariables();

        if (!foundFood) {
            target = findTarget();
        }
        else
        {
            if (target != null)
            {
                transform.LookAt(target);
                Vector3 direction = (target.position - transform.position).normalized;
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
            }
        }

        if (lifeCounter >= 400)
        {
            Destroy(self);
        }
        if (thirst >= 300)
        {
            Destroy(self);
        }
        if (hunger >= 100)
        {
            Destroy(self);
        }
    }
    void countingVariables()
    {
        hunger += 0.1;
        thirst += 0.12;
        lifeCounter += Time.deltaTime;
    }

    public Transform findTarget()
    {
        GameObject[] candidates;
        if (herbavor)
        {
            if (thirst >= hunger)
            {
                candidates = GameObject.FindGameObjectsWithTag("water");
                float minDistance = Mathf.Infinity;
                Transform closest;
                if (candidates.Length == 0)
                    return null;
                closest = candidates[0].transform;
                for (int i = 1; i < candidates.Length; ++i)
                {
                    float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;
                    if (distance < minDistance)
                    {
                        closest = candidates[i].transform;
                        minDistance = distance;
                    }
                }
                foundFood = true;
                return closest;

            }
            else
            {
                candidates = GameObject.FindGameObjectsWithTag("plant");
                float minDistance = Mathf.Infinity;
                Transform closest;
                if (candidates.Length == 0)
                    return null;
                closest = candidates[0].transform;
                for (int i = 1; i < candidates.Length; ++i)
                {
                    float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;
                    if (distance < minDistance)
                    {
                        closest = candidates[i].transform;
                        minDistance = distance;
                    }
                }
                foundFood = true;
                return closest;

            }
        }
        else
        {
            if (thirst >= hunger)
            {
                candidates = GameObject.FindGameObjectsWithTag("water");
                float minDistance = Mathf.Infinity;
                Transform closest;
                if (candidates.Length == 0)
                    return null;
                closest = candidates[0].transform;
                for (int i = 1; i < candidates.Length; ++i)
                {
                    float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;
                    if (distance < minDistance)
                    {
                        closest = candidates[i].transform;
                        minDistance = distance;
                    }
                }
                foundFood = true;
                return closest;

            }
            else
            {
                candidates = GameObject.FindGameObjectsWithTag("bunny");
                float minDistance = Mathf.Infinity;
                Transform closest;
                if (candidates.Length == 0)
                    return null;
                closest = candidates[0].transform;
                for (int i = 1; i < candidates.Length; ++i)
                {
                    float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;
                    if (distance < minDistance)
                    {
                        closest = candidates[i].transform;
                        minDistance = distance;
                    }
                }
                foundFood = true;
                return closest;

            }
        }
            return null;
        }

        
    

    void OnCollisionEnter(Collision collision)
    {
        if (herbavor) {
            switch (collision.gameObject.tag)
            {
                case "plant":
                    Destroy(collision.collider.gameObject);
                    hunger = 0;
                    foundFood = false;
                    break;
                case "water":
                    thirst = 0;
                    foundFood = false;
                    break;
            }
        }else
        {
            switch (collision.gameObject.tag)
            {

                case "water":
                    thirst = 0;
                    foundFood = false;
                    break;
                case "bunny":
                        Destroy(collision.collider.gameObject);
                        hunger = 0;
                        foundFood = false;
                    
                    break;
            }
        }
    }
}

