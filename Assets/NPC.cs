using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName; // NPC의 이름
    public ItemScript[] tradeItems; // 물물교환 가능한 아이템 배열

    private NewPlayer player; // 플레이어 컨트롤러 참조

    private void Start()
    {
        player = FindObjectOfType<NewPlayer>(); // 플레이어 컨트롤러를 찾아 참조
    }

    private void Update()
    {
        // 플레이어와의 거리 체크
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // 플레이어와의 거리가 3이하인 경우, 상호작용 가능
        bool canTrade = distanceToPlayer <= 3f;

        if (canTrade)
        {
            // 상호작용 가능한 경우, 여기에 로직을 추가하여 원하는 동작을 수행할 수 있습니다.

            // 예시: 플레이어에게 필요한 아이템을 판매하는 경우
            SellItemsToPlayer();

            // 예시: 플레이어와 아이템을 교환하는 경우
            ExchangeItemsWithPlayer();
        }
    }

    private void SellItemsToPlayer()
    {
        // 플레이어에게 아이템을 판매하는 로직을 구현합니다.
        // 예시: 플레이어가 필요로 하는 아이템을 확인하고, 해당 아이템을 판매합니다.
    }

    private void ExchangeItemsWithPlayer()
    {
        // 플레이어와 아이템을 교환하는 로직을 구현합니다.
        // 예시: 플레이어가 가지고 있는 아이템과 NPC가 가지고 있는 아이템을 교환합니다.
    }
}
