using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RTSNetworkManager : NetworkManager
{
    [SerializeField] private GameObject spawner;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        GameObject spawnerInstance = Instantiate(spawner, conn.identity.transform.position, conn.identity.transform.rotation);
        NetworkServer.Spawn(spawnerInstance, conn);

    }
}
