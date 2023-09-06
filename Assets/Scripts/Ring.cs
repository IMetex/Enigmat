using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Ring",menuName ="Magic/Ring")]
public class Ring : ScriptableObject
{
    public Spell1 leftClick;
    public Spell2 rightClick;
    //Spell2 rigtClick;
    public Sprite ringImage;
    public string ringName;
    public bool isActive;
    public List<GameObject> projectileList;

}
