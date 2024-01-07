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
    internal class sizechange : GorillaPressableButton
    {
        public static sizechange Instance;
        public static string sizetextstring = "1";
        public TMP_Text sizetext = Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Size/SizeValue")?.gameObject.GetComponent<TextMeshPro>();

        public override void Start()
        {
            Instance = this;
            sizetext.text = sizetextstring;
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
                case "Size0":
                    sizetextstring = "1";
                    sizetext.text = sizetextstring;
                    Plugin.globalSize = new Vector3(0.04f, 0.25f, 0.25f);
                    break;
                case "Size1":
                    sizetextstring = "2";
                    sizetext.text = sizetextstring;
                    Plugin.globalSize = new Vector3(0.48f, 0.03f, 0.3f);
                    break;
                case "Size2":
                    sizetextstring = "3";
                    sizetext.text = sizetextstring;
                    Plugin.globalSize = new Vector3(0.0576f, 0.36f, 0.36f);
                    break;
                case "Size3":
                    sizetextstring = "4";
                    sizetext.text = sizetextstring;
                    Plugin.globalSize = new Vector3(0.06912f, 0.432f, 0.432f);
                    break;
                case "Size4":
                    sizetextstring = "5";
                    sizetext.text = sizetextstring;
                    Plugin.globalSize = new Vector3(0.08f, 0.5f, 0.5f);
                    break;
                case "Size5":
                    sizetextstring = "6";
                    sizetext.text = sizetextstring;
                    Plugin.globalSize = new Vector3(0.1f, 0.6f, 0.6f);
                    break;
            }
        }
    }
}
