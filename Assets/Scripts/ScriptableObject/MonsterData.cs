using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data", menuName = "Monster/Data")]
public class MonsterData : ScriptableObject
{
    public float jumpHeight;
    public float speed;
    public float extraGravity;
}
