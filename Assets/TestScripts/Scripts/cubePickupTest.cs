
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using System.Collections.Generic;

public class cubePickupTest : UdonSharpBehaviour
{

    public Material changeToMaterial;
    public Material changeFromMaterial;
    public Text updateText;
    public string eventToCall;

    public GameObject[] resetAllObjects;
    public MeshRenderer myMeshRenderer;

    public void Start()
    {
        callEventOverAllObjects();
    }

    public override void OnPickup()
    {
        myMeshRenderer.material = changeToMaterial;
        callEventOverAllObjects();
        updateText.text = "Pickup Text";
    }

    public override void OnDrop()
    {
        myMeshRenderer.material = changeFromMaterial;
        updateText.text = "dropped Text";
    }

    public void callEventOverAllObjects()
    {
        foreach(GameObject go in resetAllObjects)
        {
            UdonBehaviour eventCallBehavior = (UdonBehaviour)go.GetComponent(typeof(UdonBehaviour));
            eventCallBehavior.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, eventToCall);
        }
    }




    
}
