using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaList : MonoBehaviour
{

    #region Singleton 
    public static KarmaList instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Karma found!");
            return;
        }
        instance = this;    
    }
    #endregion

    public List<Karma> karmas = new List<Karma>();

    public void Add (Karma karma)
    {
        if (!karma.isDefaultKarma)
        { 
            karmas.Add(karma); 
        }
    }

    public void Remove (Karma karma)
    {
        karmas.Remove(karma);
    }
}
