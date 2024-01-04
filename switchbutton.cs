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
    internal class switchbutton : GorillaPressableButton
    {
        public static switchbutton Instance;

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

            switch(gameObjectName)
            {
                case "COLORS":
                    Plugin.Instance.CustomPlatformManager.transform.Find("ColorButtons")?.gameObject.SetActive(true);
                    Plugin.Instance.CustomPlatformManager.transform.Find("ShapeButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("SizeButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("StickyButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Color")?.gameObject.SetActive(true);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Shape")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Size")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Sticky")?.gameObject.SetActive(false);
                    break;

                case "SHAPE":
                    Plugin.Instance.CustomPlatformManager.transform.Find("ColorButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("ShapeButtons")?.gameObject.SetActive(true);
                    Plugin.Instance.CustomPlatformManager.transform.Find("SizeButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("StickyButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Color")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Shape")?.gameObject.SetActive(true);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Size")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Sticky")?.gameObject.SetActive(false);
                    break;

                case "SIZE":
                    Plugin.Instance.CustomPlatformManager.transform.Find("ColorButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("ShapeButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("SizeButtons")?.gameObject.SetActive(true);
                    Plugin.Instance.CustomPlatformManager.transform.Find("StickyButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Color")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Shape")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Size")?.gameObject.SetActive(true);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Sticky")?.gameObject.SetActive(false);
                    break;
                case "STICKY":
                    Plugin.Instance.CustomPlatformManager.transform.Find("ColorButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("ShapeButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("SizeButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("StickyButtons")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Color")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Shape")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Size")?.gameObject.SetActive(false);
                    Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Sticky")?.gameObject.SetActive(true);
            }
        }
    }
}