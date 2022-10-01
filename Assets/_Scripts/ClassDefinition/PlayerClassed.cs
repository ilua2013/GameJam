using UnityEngine;

public class PlayerClassed : MonoBehaviour
{
    [SerializeField] private ClassDefinition _classDefinition;

    private string _name;
    private int _healt;
    private int _strength;
    private int _agility;

    public string NameClass => _name;
    public int MaxHelt => _healt;
    public int MaxStrength => _strength;
    public int MaxAgility => _agility;   

    private void OnEnable()
    {
        _classDefinition.ClassSelected += InitClass;
    }

    private void OnDisable()
    {
        _classDefinition.ClassSelected -= InitClass;
    }

    private void InitClass(ClassPlayer classPlayer)
    {
        _name = classPlayer.Name;
        _healt = classPlayer.Healt;
        _strength = classPlayer.Strength;
        _agility = classPlayer.Agility;       
    }
}
