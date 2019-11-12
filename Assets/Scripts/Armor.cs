﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour, IArmor
{
    //[Inline]
    public IntReference currentHealth;
    public float currentDamageMult = 1f;
    // Usamos um Abstract SO aqui para podermos tratar vários tipos de implementação diferentes
    [Inline]
    public AbstractArmorData DefaultData;
    
    public int ApplyDamage(int damage)
    {
        currentHealth.Variable.Value -= Mathf.RoundToInt(damage * currentDamageMult);
        return currentHealth.Value;
    }

    private void Start() {
        currentHealth.Variable.Value = DefaultData.MaxHealth;
        var standardArmor = DefaultData as StandardArmorData;
        if (standardArmor)
            currentDamageMult = standardArmor.DamageMultiplier;
    }
}
