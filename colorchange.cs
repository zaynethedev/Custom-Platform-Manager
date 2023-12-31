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
            //red
            switch(gameObjectName)
            {
                case "R0":
                    rValue = 0f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue0")?.gameObject.SetActive(true);				
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue1")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue2")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue3")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue4")?.gameObject.SetActive(false);	
	 			    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue5")?.gameObject.SetActive(false);				
                    break;
                case "R1":
                    rValue = 51f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue0")?.gameObject.SetActive(false);				
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue1")?.gameObject.SetActive(true);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue2")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue3")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue4")?.gameObject.SetActive(false);	
	 			    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue5")?.gameObject.SetActive(false);				
                    break;
                case "R2":
                    rValue = 102f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue0")?.gameObject.SetActive(false);				
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue1")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue2")?.gameObject.SetActive(true);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue3")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue4")?.gameObject.SetActive(false);	
	 			    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue5")?.gameObject.SetActive(false);				
                    break;
                case "R3":
                    rValue = 153f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue0")?.gameObject.SetActive(false);				
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue1")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue2")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue3")?.gameObject.SetActive(true);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue4")?.gameObject.SetActive(false);	
	 			    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue5")?.gameObject.SetActive(false);				
                    break;
                case "R4":
                    rValue = 204f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue0")?.gameObject.SetActive(false);				
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue1")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue2")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue3")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue4")?.gameObject.SetActive(true);	
	 			    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue5")?.gameObject.SetActive(false);				
                    break;
                case "R5":
                    rValue = 255f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue0")?.gameObject.SetActive(false);				
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue1")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue2")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue3")?.gameObject.SetActive(false);	
				    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue4")?.gameObject.SetActive(false);	
	 			    Plugin.Instance.CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject.transform.Find("RValue5")?.gameObject.SetActive(true);				
                    break;
                // green
                case "G0":
                    gValue = 0f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "G1":
                    gValue = 51f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "G2":
                    gValue = 102f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "G3":
                    gValue = 153f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "G4":
                    gValue = 204f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "G5":
                    gValue = 255f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                // blue
                case "B0":
                    bValue = 0f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "B1":
                    bValue = 51f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "B2":
                    bValue = 102f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "B3":
                    bValue = 153f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "B4":
                    bValue = 204f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
                case "B5":
                    bValue = 255f;
                    Plugin.Instance.CubeMaterialL.color = new Color(rValue, gValue, bValue) / 255;
                    Plugin.Instance.CubeMaterialR.color = new Color(rValue, gValue, bValue) / 255;
                    break;
            }
        }
    }

}