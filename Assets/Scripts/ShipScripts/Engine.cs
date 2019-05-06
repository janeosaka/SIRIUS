﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : Interactable
{
    private readonly int maxFuel = 100;
    public int currentFuel { get; set; }
    public GameObject EnginePanel;

    public void SetEngine(GameObject p)
    {
        this.player = p;
    }

    public override void Interact()
    {
        isInteracting = !isInteracting;
        panelOpen = !panelOpen;
        EnginePanel.GetComponent<EngineScript>().ToggleEnginePanel(isInteracting);
        base.Interact();
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
            Interact();
        else if (!canInteract && panelOpen)
        {
            panelOpen = false;
            EnginePanel.GetComponent<Animator>().SetBool("isOpen", false);
        }
    }

    public void Refuel(int value)
    {
        currentFuel += value;
        Mathf.Clamp(currentFuel, 0, maxFuel);
    }

    public void Travel(int amount)
    {
        currentFuel -= amount;
        if (EnginePanel.gameObject.activeInHierarchy)
        {
            EnginePanel.GetComponent<EngineScript>().UpdateFuel();
        }
    }
}
