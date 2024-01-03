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
        public static string shape = "Square";
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
            SphereL SphereL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            SphereR SphereR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Destroy(Plugin.Instance.SphereL.GetComponent<BoxCollider>());
            Destroy(Plugin.Instance.SphereR.GetComponent<BoxCollider>());
            Plugin.Instance.SphereR.AddComponent<MeshCollider>();
            Plugin.Instance.SphereL.AddComponent<MeshCollider>();
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
                    Plugin.Instance.CustomPlatL.transform.position = new Vector3(0, 0, 0);
                    Plugin.Instance.CustomPlatR.transform.position = new Vector3(0, 0, 0);
                    Plugin.Instance.CustomPlatL = SphereL;
                    Plugin.Instance.CustomPlatR = SphereR;
                    break;

                case "Square":
                    shape = "Cube";
                    shapetext.text = shape;
                    Plugin.Instance.CustomPlatL.transform.position = new Vector3(0, 0, 0);
                    Plugin.Instance.CustomPlatR.transform.position = new Vector3(0, 0, 0);
                    Plugin.Instance.CustomPlatL = Plugin.Instance.CubeL;
                    Plugin.Instance.CustomPlatR = Plugin.Instance.CubeR;
                    break;

                case "Triangle":
                    shape = "Soon!";
                    shapetext.text = shape;
                    Plugin.Instance.CustomPlatL.transform.position = new Vector3(0, 0, 0);
                    Plugin.Instance.CustomPlatR.transform.position = new Vector3(0, 0, 0);
                    Plugin.Instance.CustomPlatL = Plugin.Instance.CubeL;
                    Plugin.Instance.CustomPlatR = Plugin.Instance.CubeR;
                    break;
            }
        }
    }
}
