using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.EventSystems;

public class UnitSpawner : NetworkBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private Transform spawnPos;


    #region Server

    [Command]
    private void CmdSpawnUnit()
    {
        GameObject UnitInstance = Instantiate(unitPrefab, spawnPos.position, spawnPos.rotation);

        NetworkServer.Spawn(UnitInstance, connectionToClient);
    }


    #endregion


    #region Client

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) { return; }
        if (!hasAuthority) { return; }

        CmdSpawnUnit();
    }


    #endregion
}
