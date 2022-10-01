using UnityEngine;

public class PlayerClassed : MonoBehaviour
{
    [SerializeField] private ClassDefinition _classDefinition;

    private string _name;
    private int _healt;
    private int _power;
    private int _agility;

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
        _power = classPlayer.Power;
        _agility = classPlayer.Agility;       
    }
}
