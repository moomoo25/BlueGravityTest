using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InventoryController : MonoBehaviour
{
    private PlayerInput input = null;
    private CharacterMovement characterMovement = null;
    private InventoryManager inventoryManager = null;
    void Awake()
    {
        input = new PlayerInput();
    }
    public void SetUp(CharacterMovement characterMovement_, InventoryManager inventoryManager_)
    {
        characterMovement = characterMovement_;
        inventoryManager = inventoryManager_;
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Inventory.performed += OnInventoryPerformed;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Inventory.performed -= OnInventoryPerformed;
    }
    private void OnInventoryPerformed(InputAction.CallbackContext value)
    {
        if (GameManager.singleton.isShopOpen)
            return;
        characterMovement.canMove = !inventoryManager.EnableInventory();
    }
}
