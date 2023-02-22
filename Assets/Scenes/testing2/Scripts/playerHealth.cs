using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
public int Maxhealth = 10;
public int currenthealth;

public healthbarscript healthbarscript;

void Start() {
    currenthealth = Maxhealth;
    healthbarscript.SetMaxHealth(Maxhealth);
}

void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
        TakeDamage(2);
    }
}

void TakeDamage(int damage) {
currenthealth -= damage;
healthbarscript.SetHealth(currenthealth);
}
}
