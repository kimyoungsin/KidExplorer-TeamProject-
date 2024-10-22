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

    public float baseMovementSpeed = 5f; // �⺻ �̵� �ӵ�
    public float baseActionSpeed = 1f; // �⺻ �ൿ �ӵ�
    public float underweightSpeedMultiplier = 1.2f; // ü�� ���� �� �̵� �ӵ� ���� ����
    public float overweightSpeedMultiplier = 0.8f; // ü�� ���� �� �̵� �ӵ� ���� ����
    public GameObject inventoryUI; // �κ��丮 UI ������Ʈ
    public NPC[] npcs; // NPC �迭

    private float currentMovementSpeed; // ���� �̵� �ӵ�
    private float currentActionSpeed; // ���� �ൿ �ӵ�
    private int selectedTraitIndex = NoTraitIndex; // ���õ� Ư���� �ε���

    private void Start()
    {
        currentMovementSpeed = baseMovementSpeed; // ���� �� �⺻ �̵� �ӵ��� �ʱ�ȭ
        currentActionSpeed = baseActionSpeed; // ���� �� �⺻ �ൿ �ӵ��� �ʱ�ȭ
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
        // ��ȣ�ۿ� ������ ���⿡ ����
        // �ʿ��� ��� NPC���� ������ȯ�� ó���ϴ� �ڵ� �߰�

        // ����: NPC Ŭ������ ���õ� ������ ����Ͽ� �ʿ��� ������ ã�� ��ȯ ������ ����
        // ����: npcs �迭�� ��ȸ�ϸ� �÷��̾���� �Ÿ� ���� ����Ͽ� ������ȯ ������ ó��
    }

    private void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf); // �κ��丮 UI�� Ȱ��ȭ/��Ȱ��ȭ�� ���
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
            currentMovementSpeed *= underweightSpeedMultiplier; // ü�� ���� �� �̵� �ӵ� ����
            currentActionSpeed *= underweightSpeedMultiplier; // ü�� ���� �� �ൿ �ӵ� ����
        }
        else if (selectedTrait == Trait.Overweight)
        {
            currentMovementSpeed *= overweightSpeedMultiplier; // ü�� ���� �� �̵� �ӵ� ����
            currentActionSpeed *= overweightSpeedMultiplier; // ü�� ���� �� �ൿ �ӵ� ����
        }
    }
}