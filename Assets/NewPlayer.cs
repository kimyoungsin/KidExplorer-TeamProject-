using UnityEngine;

public enum Trait
{
    Underweight,
    Overweight,
    NoTrait
}

public class NewPlayer : MonoBehaviour
{
    private const int TraitCount = 3;
    private const int NoTraitIndex = -1;

    public float baseMovementSpeed = 5f; // 기본 이동 속도
    public float baseActionSpeed = 1f; // 기본 행동 속도
    public float underweightSpeedMultiplier = 1.2f; // 체중 부족 시 이동 속도 증가 비율
    public float overweightSpeedMultiplier = 0.8f; // 체중 과다 시 이동 속도 감소 비율
    public GameObject inventoryUI; // 인벤토리 UI 오브젝트
    public NPC[] npcs; // NPC 배열

    private float currentMovementSpeed; // 현재 이동 속도
    private float currentActionSpeed; // 현재 행동 속도
    private int selectedTraitIndex = NoTraitIndex; // 선택된 특성의 인덱스

    private void Start()
    {
        currentMovementSpeed = baseMovementSpeed; // 시작 시 기본 이동 속도로 초기화
        currentActionSpeed = baseActionSpeed; // 시작 시 기본 행동 속도로 초기화
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * currentMovementSpeed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }

        if (selectedTraitIndex == NoTraitIndex)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedTraitIndex = 0;
                ApplyTrait(selectedTraitIndex);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedTraitIndex = 1;
                ApplyTrait(selectedTraitIndex);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedTraitIndex = 2;
                ApplyTrait(selectedTraitIndex);
            }
        }
    }

    private void Interact()
    {
        // 상호작용 로직을 여기에 구현
        // 필요한 경우 NPC와의 물물교환을 처리하는 코드 추가

        // 예시: NPC 클래스와 관련된 정보를 사용하여 필요한 물건을 찾고 교환 로직을 구현
        // 예시: npcs 배열을 순회하며 플레이어와의 거리 등을 고려하여 물물교환 로직을 처리
    }

    private void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf); // 인벤토리 UI의 활성화/비활성화를 토글
    }

    public void ApplyTrait(int traitIndex)
    {
        Trait selectedTrait;

        if (traitIndex >= 0 && traitIndex < TraitCount)
        {
            selectedTrait = (Trait)traitIndex;
        }
        else
        {
            selectedTrait = Trait.NoTrait;
        }

        if (selectedTrait == Trait.Underweight)
        {
            currentMovementSpeed *= underweightSpeedMultiplier; // 체중 부족 시 이동 속도 증가
            currentActionSpeed *= underweightSpeedMultiplier; // 체중 부족 시 행동 속도 증가
        }
        else if (selectedTrait == Trait.Overweight)
        {
            currentMovementSpeed *= overweightSpeedMultiplier; // 체중 과다 시 이동 속도 감소
            currentActionSpeed *= overweightSpeedMultiplier; // 체중 과다 시 행동 속도 감소
        }
    }
}