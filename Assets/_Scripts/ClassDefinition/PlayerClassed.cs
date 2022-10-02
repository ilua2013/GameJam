using UnityEngine;

public class PlayerClassed : MonoBehaviour
{
    [SerializeField] private ClassDefinition _classDefinition;
    [SerializeField] private PlayerParameter _playerParameter;

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
        _playerParameter.Init(classPlayer.Name, classPlayer.Healt, classPlayer.Strength, classPlayer.Agility);
    }
}
