using UnityEngine;

public class OutlineEffect : MonoBehaviour
{
    [SerializeField] private Color outlineColor = Color.black;  // 아웃라인 색상
    [SerializeField] private Vector2 offset = new Vector2(0.05f, 0.05f); // 오프셋 값
    [SerializeField] private Material outlineMaterial;  // 쉐이더 적용할 머티리얼

    private GameObject outlinesParent;  // 아웃라인 부모 오브젝트
    private GameObject[] outlines;  // 아웃라인 오브젝트들
    private SpriteRenderer[] outlineRenderers;  // 아웃라인의 렌더러들
    private Vector2 prevOffset;
    private Color prevColor;
    private bool isMouseOver = false;  // 마우스가 오버된 상태 추적

    void Start()
    {
        CreateOutlines();
        UpdateOutline();
        SavePreviousValues();
        SetOutlinesActive(false); // 게임 시작 시 아웃라인을 비활성화
    }

    void Update()
    {
        if (HasValuesChanged())  // 값이 변경될 때만 업데이트
        {
            UpdateOutline();
            SavePreviousValues();
        }

        if (isMouseOver && !PossessManager.Instance.isPossessing)  // 마우스가 오버된 상태에서만 업데이트
        {
            SetOutlinesActive(true);  // 마우스가 오버되었을 때 아웃라인 표시
        }
        else
        {
            SetOutlinesActive(false);  // 마우스가 벗어났을 때 아웃라인 숨김
        }

    }

    void CreateOutlines()
    {
        if (outlines != null) return;

        outlinesParent = new GameObject("OutlinesParent");
        outlinesParent.transform.parent = transform;  // 부모 설정
        outlinesParent.transform.localPosition = Vector3.zero;

        outlines = new GameObject[4];
        outlineRenderers = new SpriteRenderer[4];

        SpriteRenderer originalRenderer = GetComponent<SpriteRenderer>();
        if (originalRenderer == null) return;

        for (int i = 0; i < 4; i++)
        {
            outlines[i] = new GameObject("Outline_" + i);
            outlines[i].transform.parent = outlinesParent.transform;  // 부모를 outlinesParent로 설정
            outlines[i].transform.localPosition = Vector3.zero;

            outlineRenderers[i] = outlines[i].AddComponent<SpriteRenderer>();
            outlineRenderers[i].sprite = originalRenderer.sprite;
            outlineRenderers[i].sortingOrder = originalRenderer.sortingOrder - 1;
            outlineRenderers[i].material = new Material(outlineMaterial);
            outlineRenderers[i].enabled = true; // 초기에는 아웃라인 활성화
        }
    }

    void UpdateOutline()
    {
        if (outlines == null) return;

        // offset을 적용하여 4개의 아웃라인 위치를 계산
        Vector3[] outlinePositions = {
            new Vector3(offset.x, offset.y, 0),          // 오른쪽 위
            new Vector3(offset.x, -offset.y, 0),         // 오른쪽 아래
            new Vector3(-offset.x, offset.y, 0),         // 왼쪽 위
            new Vector3(-offset.x, -offset.y, 0)         // 왼쪽 아래
        };

        for (int i = 0; i < 4; i++)
        {
            outlines[i].transform.localPosition = outlinePositions[i];
            outlineRenderers[i].color = outlineColor;
            outlineRenderers[i].material.SetColor("_OutlineColor", outlineColor); // Material 색상 적용
        }
    }

    bool HasValuesChanged()
    {
        return offset != prevOffset || outlineColor != prevColor;
    }

    void SavePreviousValues()
    {
        prevOffset = offset;
        prevColor = outlineColor;
    }

    // 마우스가 오버됐을 때 아웃라인을 활성화
    void OnMouseOver()
    {
        isMouseOver = true;
    }

    // 마우스가 오버에서 벗어났을 때 아웃라인을 비활성화
    void OnMouseExit()
    {
        isMouseOver = false;
    }

    // outlinesParent의 활성화/비활성화 관리
    void SetOutlinesActive(bool active)
    {
        outlinesParent.SetActive(active);
    }
}
