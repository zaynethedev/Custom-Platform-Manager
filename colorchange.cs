using System;
using System.Collections.Generic;
using System.Text;
using CubeSummoner;
using UnityEngine;
using TMPro;
using System.EnterpriseServices;
using Steamworks;
using System.ComponentModel;

namespace CubeSummoner.buttons
{
    internal class colorchange : GorillaPressableButton
    {
        public float rValue;
        public float gValue;
        public float bValue;
        public static colorchange Instance;

        public override void Start()
        {
            Instance = this;
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            gameObject.layer = 18;
            onPressButton = new UnityEngine.Events.UnityEvent();
            onPressButton.AddListener(new UnityEngine.Events.UnityAction(ButtonActivation));
        }

public override void ButtonActivation()
{
    isOn = !isOn;
    string gameObjectName = gameObject.name;
    string name = gameObjectName[0] + "Value" + gameObjectName[1];
    var parent = Plugin.Instance.CustomPlatformManager.transform.Find($"Computer/Color/{gameObjectName[0]}Values");
    foreach (Transform child in parent)
    {
        bool shouldBeActive = child.name == name;
        child.gameObject.SetActive(shouldBeActive);
    }
    switch (name[0])
    {
        case 'R':
            rValue = int.Parse(gameObjectName[1].ToString()) * 255 / 4f;
            break;
        case 'G':
            gValue = int.Parse(gameObjectName[1].ToString()) * 255 / 4f;
            break;
        case 'B':
            bValue = int.Parse(gameObjectName[1].ToString()) * 255 / 4f;
            break;
    }

}
