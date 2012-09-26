using UnityEngine;
using System.Collections;
using UnityEditor;

public static class RuneMaker {
    [MenuItem ("BUTTS BUTTS BUTTS/Make Rune")]
    static void MakeRune() {
        var r = ScriptableObject.CreateInstance<Spell>();
        AssetDatabase.CreateAsset(r, "Assets/_Data/Runes/___RUNE.asset");
    }
}
