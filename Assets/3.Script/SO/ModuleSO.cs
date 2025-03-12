using UnityEngine;

[CreateAssetMenu(fileName = "ModuleSO", menuName = "Scriptable Objects/ModuleSO")]
public class ModuleSO : ScriptableObject
{
    public int moduleId;
    public string moduleName;

    public string moduleExplain;

    public Sprite moduleImage;

}
