using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public CharacterInfo[] characters;

    public int charCount
    { get 
        { 
            return characters.Length; 
        }
    }

    public CharacterInfo GetCharInfo(int index)
    {
        return characters[index];
    }


}
