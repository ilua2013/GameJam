using UnityEngine;

[CreateAssetMenu(fileName = "new Class", menuName = "Class/Create new class", order = 51)]
public class ClassPlayer : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _healt;
    [SerializeField] private int _strength;
    [SerializeField] private int _agility;

    public string Name => _name;
    public int Healt => _healt;
    public int Strength => _strength;
    public int Agility => _agility;
}
