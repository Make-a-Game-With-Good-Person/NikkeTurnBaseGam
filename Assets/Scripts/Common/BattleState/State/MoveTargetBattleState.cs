using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �̵������� �ݰ��� �����ִ� ����
/// <para>�䱸���� 1. ������ �̵��Ÿ�, ���� �ɷ�ġ�� ���� �� �� �ִ� Ÿ���� ������ ��</para>
/// <para>�䱸���� 2. �ڷΰ��� ��ư���� UnitSelectBattleState�� ����</para>
/// <para>�䱸���� 3. �̵� Ȯ�� ��ư���� MoveSequenceState�� ����</para>
/// </summary>
public class MoveTargetBattleState : BattleState
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