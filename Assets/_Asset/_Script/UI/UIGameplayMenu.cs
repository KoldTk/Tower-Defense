using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIGameplayMenu : MonoBehaviour
{
    public Canvas gameplayUI;
    public RectTransform spawnMenu;

    private void Update()
    {
        WaypointClick();
    }
    private void WaypointClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Waypoint"))
            {
                GameManager.Instance.spawnAllyPos = hit.collider.transform.position;
                OpenSpawnMenu(Input.mousePosition);
            }else if (spawnMenu.gameObject.activeInHierarchy && !EventSystem.current.IsPointerOverGameObject())
            {
                spawnMenu.gameObject.SetActive(false);
            }    
        }
    }    
    private void OpenSpawnMenu(Vector2 screenPos)
    {
        spawnMenu.gameObject.SetActive(true);
    }
}
