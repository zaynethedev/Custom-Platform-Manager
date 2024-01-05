using System;
using System.Collections.Generic;
using System.Text;
using CustomPlatformManager;
using UnityEngine;
using TMPro;
using System.EnterpriseServices;
using System.ComponentModel;

namespace CustomPlatformManager.buttons
{
    internal class stickychange : GorillaPressableButton
    {
        public static stickyTextString = "Loose Platforms";
        public static stickychange Instance;
        public TMP_Text stickytext = Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Size/StickyValue")?.gameObject.GetComponent<TextMeshPro>();

        public override void Start()
        {
            Instance = this;
            stickytext.text = stickyTextString;
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

            switch (gameObjectName)
            {
                case "Sticky":
                    stickyTextString = "Sticky Platforms";
                    stickytext.text = stickyTextString;
                    Plugin.platOffset = new Vector3(0f, 0f, 0f);
                    break;
                case "Loose":
                    stickyTextString = "Loose Platforms";
                    stickytext.text = stickyTextString;
                    Plugin.platOffset = new Vector3(0f, -1f, 0f); //need to add the gorilla rigidbody's velocity vector to catch the hand when at high speeds, I don't have any docs on where to get that rn.
                    break;
            }
        }
    }
}