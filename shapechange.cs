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
    internal class shapechange : GorillaPressableButton
    {
        public static shapechange Instance;
        public static string shape = "Cube";
        public TMP_Text shapetext = Plugin.Instance.CustomPlatformManager.transform.Find("Computer/Shape/ShapeValue")?.gameObject.GetComponent<TextMeshPro>();

        public override void Start()
        {
            Instance = this;
            shapetext.text = shape;
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
                case "Circle":
                    shape = "Sphere";
                    shapetext.text = shape;
                    Destroy(Plugin.Instance.CustomPlatL);
                    Destroy(Plugin.Instance.CustomPlatR);
                    Plugin.Instance.CustomPlatL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Plugin.Instance.CustomPlatR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(Plugin.Instance.CustomPlatL.GetComponent<SphereCollider>());
                    Destroy(Plugin.Instance.CustomPlatR.GetComponent<SphereCollider>());
                    Plugin.Instance.CustomPlatR.AddComponent<BoxCollider>();
                    Plugin.Instance.CustomPlatL.AddComponent<BoxCollider>();
                    Plugin.Instance.CustomPlatL.AddComponent<GorillaSurfaceOverride>();
                    Plugin.Instance.CustomPlatL.AddComponent<GorillaSurfaceOverride>();
                    break;

                case "Square":
                    shape = "Cube";
                    shapetext.text = shape;
                    Destroy(Plugin.Instance.CustomPlatL);
                    Destroy(Plugin.Instance.CustomPlatR);
                    Plugin.Instance.CustomPlatL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Plugin.Instance.CustomPlatR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //Cube is created with box collider by default
                    Plugin.Instance.CustomPlatL.AddComponent<GorillaSurfaceOverride>();
                    Plugin.Instance.CustomPlatL.AddComponent<GorillaSurfaceOverride>();
                    break;

                case "Triangle":
                    shape = "Soon!";
                    shapetext.text = shape;
                    Destroy(Plugin.Instance.CustomPlatL);
                    Destroy(Plugin.Instance.CustomPlatR);
                    Plugin.Instance.CustomPlatL = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Plugin.Instance.CustomPlatR = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Plugin.Instance.CustomPlatL.AddComponent<GorillaSurfaceOverride>();
                    Plugin.Instance.CustomPlatL.AddComponent<GorillaSurfaceOverride>();
                    break;
            }
        }
    }
}
