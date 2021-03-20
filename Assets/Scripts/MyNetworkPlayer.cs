using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class MyNetworkPlayer : NetworkBehaviour
{

    [SerializeField] private TMP_Text displaynameText = null;
    [SerializeField] private Renderer displayColorRenderer = null;

    [SyncVar(hook = nameof(HandleDisplayNameUpdated))]
    [SerializeField]
    private string displayName = "Missing Name";

    [SyncVar(hook = nameof(HandleDisplayColorUpdated))]
    [SerializeField]
    private Color displayColor = Color.black;

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [Server]
    public void SetDisplayColor(Color newDisplayColor) 
    {
        displayColor = newDisplayColor;
    }

    private void HandleDisplayNameUpdated(string oldName, string newName)
    {
        displaynameText.text = newName;
    }
    private void HandleDisplayColorUpdated(Color oldColor, Color newColor) 
    {
        displayColorRenderer.material.SetColor("_Color", newColor);
    }

    
}
