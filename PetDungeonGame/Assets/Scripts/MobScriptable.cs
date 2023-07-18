using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MobScriptable", menuName = "PetDungeonGame/MobScriptable", order = 0)]
public class MobScriptable : ScriptableObject {
    public new string name;
        
    public Sprite sprite;

    public int damage;
    public int maxHp;
}
