using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateController : MonoBehaviour
{
    [Header("카메라가 찍을 대상"), Space(0.5f)]
    public Transform target; // 카메라가 찍을 대상

    [Header("카메라 대상 타겟의 숄더뷰 위치"), Space(0.5f)]
    public Transform targetShoulder; // 카메라 대상 타겟의 숄더뷰 위치

    [Header("타겟이 바라보고 있는 대상"), Space(0.5f)]
    public Transform lookTarget; // 위의 타겟이 바라보고 있는 타겟

    public Vector3 quarterViewoffset = new Vector3(3, 5, -5);
    public Vector3 quarterViewrotationOffset = new Vector3(45, -30, 0);  // 각도 offset (Pitch, Yaw, Roll)

    //public Vector3 shoulderViewOffset = new Vector3(1, 1, 5);
    public Vector3 shoulderViewrotationOffset = new Vector3(0, 0, 0);  // 각도 offset (Pitch, Yaw, Roll)

    public float transitionSpeed = 2f;
    public float dragSpeed = 15f;
    public float rotationSpeed = 4f;

    public bool isDragging;

    public LayerMask layerMask;

    // 상태 객체 캐싱, 시점을 추가할 시 여기에 State로 선언하고 아래에서 new로 생성한 뒤 Switch함수를 추가해 쓰면 됨, 
    // 실질적인 카메라 시점 변환 구현은 아래 State들로 따로 추가하면 된다. 
    ICameraState quarterViewState;
    ICameraState shoulderViewState;
    ICameraState mapViewState;
    ICameraState currentState;

    //BattleManager owner;
    

    // Start is called before the first frame update
    void Start()
    {
        // 상태 객체를 한번만 생성해두고 재사용
        quarterViewState = new QuarterViewState();
        shoulderViewState = new ShoulderViewState();
        mapViewState = new MapViewState();
        currentState = quarterViewState; // 초기 상태 설정
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.UpdateState(this);

        // 이 아래 코드들 다 삭제 예정
        //if(owner.curState == BATTLESTATE.UNITSELECT)
        // 맵 둘러보기 상태 전환
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭(터치) 이벤트
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (((1 << hit.collider.gameObject.layer) & layerMask) != 0)
                {
                    isDragging = false;
                    //SetCamTarget(hit.collider.transform);
                    //owner.selectedTarget = this.target;
                    SwitchToQuaterView(hit.collider.transform);
                }
                else
                {
                    SwitchToMapView();
                }
            }
        }
    }

    /*public void SetLockOnTarget(Transform _lockOnTarget)
    {
        if (_lockOnTarget == null) return;
        shoulderViewrotationOffset = Vector3.zero;
        else enemyShoulderViewrotationOffset.y = 180f;

        Vector3 lockOnVec = _lockOnTarget.position - target.position;
        lookRot = Vector3.Dot(lockOnVec, target.transform.forward);
        if (playerPhase) shoulderViewrotationOffset.y -= lookRot;
        else enemyShoulderViewrotationOffset.y -= lookRot;

        Vector3 rightVec = Vector3.Cross(target.forward, Vector3.up); // 외적
        float dotRight = Vector3.Dot(rightVec, lockOnVec); // 내적

        if (dotRight > 0)
        {
            // 오른쪽에 있을 때
            shoulderViewrotationOffset.y -= Mathf.Abs(dotRight);

        }
        else
        {
            // 왼쪽에 있을 때
            shoulderViewrotationOffset.y += Mathf.Abs(dotRight);
        }

        Debug.Log(dotRight);

    }*/

    public void SetCamTarget(Transform _target)
    {
        this.target = _target;
    }

    void SetLookTarget(Transform _target)
    {
        this.lookTarget = _target;
    }

    public void SwitchToShoulderView(Transform shoulder)
    {
        this.transform.parent = shoulder;
        this.transform.localPosition= Vector3.zero;
        currentState = shoulderViewState;
    }

    public void SwitchToMapView()
    {
        this.transform.parent = null;
        currentState = mapViewState;
    }

    public void SwitchToQuaterView(Transform target)
    {
        SetCamTarget(target);
        this.transform.parent = null;
        currentState = quarterViewState;
    }

    
}
