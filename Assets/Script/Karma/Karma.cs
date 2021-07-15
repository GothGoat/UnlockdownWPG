using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Karma : ScriptableObject
{
    new public string name = "Karma";
    public Sprite icon = null;
    public bool isDefaultKarma = false;
}
