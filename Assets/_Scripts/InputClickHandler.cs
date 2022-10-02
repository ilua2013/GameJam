using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class InputClickHandler : MonoBehaviour, IItemPicker
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private QuestPerform _questPerform;
    [SerializeField] private PlayerFighter _playerFighter;
    [SerializeField] private Inventory _inventory;

    private Coroutine _checkDistance;

    public event Action<Item> PickedUp;
    public event Action NewDo;
    public event Action ClickEnemy;
    public event Action ClickSpeaker;

    private void OnValidate()
    {
        _playerMover = FindObjectOfType<PlayerMover>();
        _inventory = FindObjectOfType<Inventory>();
        _playerFighter = FindObjectOfType<PlayerFighter>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            ShootRaycast();
    }

    private void ShootRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, 1, QueryTriggerInteraction.Ignore) == false)
            return;

        if (_checkDistance != null)
        {
            StopCoroutine(_checkDistance);

            _checkDistance = null;
        }

        if (hit.collider.TryGetComponent(out Item item))
        {
            _playerMover.MoveTo(item.transform.position);
            _checkDistance = StartCoroutine(CheckDistance(item.transform, _inventory.DistanceToAddItem, () => OnReachedItem(item)));
        }
        else if (hit.collider.TryGetComponent(out Speaker speaker))
        {
            _playerMover.MoveTo(speaker.transform.position);
            _checkDistance = StartCoroutine(CheckDistance(speaker.transform, _questPerform.DistanceToSpeak, () => Speak(speaker)));
        }
        else if(hit.transform.TryGetComponent(out EnemyFighter enemyFighter))
        {
            _playerMover.MoveTo(enemyFighter.transform.position);
            _checkDistance = StartCoroutine(CheckDistance(enemyFighter.transform, _playerFighter.DistanceAttack, () => Fight(enemyFighter)));
            ClickEnemy?.Invoke();
            print("ClickTOFight");
            return;
        }
        else
        {
            _playerMover.MoveTo(hit.point);
        }

        NewDo?.Invoke();
    }

    private IEnumerator CheckDistance(Transform target, float distance, Action onComplete = null)
    {
        while (Vector3.Distance(transform.position, target.position) > distance)
            yield return null;

        onComplete?.Invoke();

        _checkDistance = null;
    }

    private void OnReachedItem(Item item)
    {
        PickedUp?.Invoke(item);
    }

    private void Speak(Speaker speak)
    {
        _playerMover.StopMove();
        ClickSpeaker?.Invoke();
        speak.StartSpeak();
        print("Speak");
    }

    private void Fight(EnemyFighter enemyFighter)
    {
        _playerFighter.StartFight(enemyFighter);
        _playerMover.StopMove();
        NewDo += StopFight;
        print("StartFight");
    }

    private void StopFight()
    {
        NewDo -= StopFight;
        _playerFighter.StopFight();
    }
}
