using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

  public List<GameObject> customerPrefabs;
  public List<GameObject> shopItemPrefabs;
  public List<InventoryItem> currentShopItems;
  public List<GameObject> currentCustomers;
  public System.Random rando;

  public Transform shopInventory;
  public Transform customerLobby;

  public int maxCustomers = 12;

  public float customerInterval = 3.5f;
  public float nextCustomerAt;
  public float buyInterval = 1.0f;
  public float nextBuyAt;
  public int currentGold;
  //only buy items during the shift
  public bool canPurchase = false;

  public Text goldText;

  // Start is called before the first frame update
  void Start()
  {

    rando = new System.Random();
    nextBuyAt = 0.0f;
    nextCustomerAt = 0.0f;
    currentGold = 0;
    currentCustomers = new List<GameObject>();
    currentShopItems = new List<InventoryItem>();
  }

  void Update()
  {
    if (nextCustomerAt < Time.time && currentCustomers.Count <= maxCustomers)
    {
      addCustomer();
      nextCustomerAt = Time.time + customerInterval;
    }
    if (nextBuyAt < Time.time && canPurchase)
    {
      auction();
      nextBuyAt = Time.time + buyInterval;
    }
  }

  public void auction()
  {
    for (int i = 0; i < currentCustomers.Count; i++)
    {
      //only allow one purchase per "auction"
      if (buyItem())
      {
        //have a 30% chance that the customer will leave, decreasing the change of the next item being bought
        if (rando.Next(100) < 30)
        {
          removeCustomer();
        }
        break;
      }
    }

  }

  public void addCustomer()
  {
    currentCustomers.Add(customerPrefabs[rando.Next(customerPrefabs.Count)]);
    renderCustomers();
  }

  public void removeCustomer()
  {
    currentCustomers.RemoveAt(0);
    renderCustomers();
  }

  public void renderCustomers()
  {
    clearCustomers();
    foreach (GameObject prefab in currentCustomers)
    {
      Instantiate(prefab, customerLobby, false);
    }
  }

  public void clearCustomers()
  {
    foreach (Transform child in customerLobby)
    {
      GameObject.Destroy(child.gameObject);
    }
  }

  public bool buyItem()
  {
    if (currentShopItems.Count == 0)
    {
      return false;
    }

    int buyChance = rando.Next(100);
    if (buyChance < 20)
    {
      currentGold += currentShopItems[0].getGoldValue();
      removeItemFromShop();
      updateGoldText();
      return true;
    }
    return false;
  }

  public void pausePurchases()
  {
    canPurchase = false;
  }

  public void resumePurchases()
  {
    canPurchase = true;
  }

  public void addItemToShop(int goldValue)
  {
    currentShopItems.Add(new InventoryItem(shopItemPrefabs[rando.Next(shopItemPrefabs.Count)], goldValue));
    renderShopItems();
  }

  public void removeItemFromShop()
  {
    currentShopItems.RemoveAt(0);
    renderShopItems();
  }

  public void clearAllItemsFromShop()
  {
    currentShopItems.Clear();
    renderShopItems();
  }

  public void renderShopItems()
  {
    clearItems();
    foreach (InventoryItem shopItem in currentShopItems)
    {
      Instantiate(shopItem.getObjectPrefab(), shopInventory, false);
    }
  }

  private void clearItems()
  {
    foreach (Transform child in shopInventory)
    {
      GameObject.Destroy(child.gameObject);
    }
  }

  private void updateGoldText()
  {
    goldText.text = currentGold.ToString();
  }
}

public class InventoryItem
{

  public GameObject objectPrefab;
  public int goldValue;

  public InventoryItem(GameObject objectPrefab, int goldValue)
  {
    this.objectPrefab = objectPrefab;
    this.goldValue = goldValue;
  }

  public GameObject getObjectPrefab()
  {
    return objectPrefab;
  }

  public int getGoldValue()
  {
    return goldValue;
  }
}
