using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ �����Ƽ�� ���� ��¥�� ������
/// <para>�䱸���� 1. �����ϰ� ���� GameEnd üũ(������ ���� �׾����� �Ʊ��� ���� �׾����� ��)</para>
/// <para>�䱸���� 2. ���� �Ʊ� ������ ���� �� �������� �ʾ����� UnitSelectBattleState�� ����</para>
/// <para>�䱸���� 3. �Ʊ� ������ ���� �������� ���� owner�� ������ ������ ��</para>
/// <para>�䱸���� 4. �̹� ������ Ability ��ư�� ��Ȱ��ȭ�� ��</para>
/// </summary>
public class PerformAbilityBattleState : BattleState
{
    #region Properties
    #region Private
    #endregion
    #region Protected
    #endregion
    #region public
    #endregion
    #region Events
    #endregion
    #endregion

    #region Constructor
    #endregion

    #region Methods
    #region Private
    #endregion
    #region Protected
    protected override void AddListeners()
    {
        base.AddListeners();
    }
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
    }
    #endregion
    #region Public
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(ProcessingState());
    }
    public override void Exit()
    {
        base.Exit();
    }
    #endregion
    #endregion

    #region EventHandlers
    #endregion

    #region Coroutines
    private IEnumerator ProcessingState()
    {
        yield return null;
    }
    #endregion

    #region MonoBehaviour
    #endregion
}