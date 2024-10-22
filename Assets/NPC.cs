using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName; // NPC�� �̸�
    public ItemScript[] tradeItems; // ������ȯ ������ ������ �迭

    private NewPlayer player; // �÷��̾� ��Ʈ�ѷ� ����

    private void Start()
    {
        player = FindObjectOfType<NewPlayer>(); // �÷��̾� ��Ʈ�ѷ��� ã�� ����
    }

    private void Update()
    {
        // �÷��̾���� �Ÿ� üũ
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // �÷��̾���� �Ÿ��� 3������ ���, ��ȣ�ۿ� ����
        bool canTrade = distanceToPlayer <= 3f;

        if (canTrade)
        {
            // ��ȣ�ۿ� ������ ���, ���⿡ ������ �߰��Ͽ� ���ϴ� ������ ������ �� �ֽ��ϴ�.

            // ����: �÷��̾�� �ʿ��� �������� �Ǹ��ϴ� ���
            SellItemsToPlayer();

            // ����: �÷��̾�� �������� ��ȯ�ϴ� ���
            ExchangeItemsWithPlayer();
        }
    }

    private void SellItemsToPlayer()
    {
        // �÷��̾�� �������� �Ǹ��ϴ� ������ �����մϴ�.
        // ����: �÷��̾ �ʿ�� �ϴ� �������� Ȯ���ϰ�, �ش� �������� �Ǹ��մϴ�.
    }

    private void ExchangeItemsWithPlayer()
    {
        // �÷��̾�� �������� ��ȯ�ϴ� ������ �����մϴ�.
        // ����: �÷��̾ ������ �ִ� �����۰� NPC�� ������ �ִ� �������� ��ȯ�մϴ�.
    }
}
