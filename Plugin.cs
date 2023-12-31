﻿using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;
using CustomPlatformManager.buttons;
using System.ComponentModel;
using TMPro;
using System.Threading.Tasks;
using Unity.Mathematics;
using Photon.Pun;

namespace CustomPlatformManager
{
	/// <summary
	/* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		bool platSetR;
		bool platSetL;
		internal GameObject CustomPlatR;
		internal Material CubeMaterialR;
		internal GameObject CustomPlatL;
		internal Material CubeMaterialL;
		internal GameObject CustomPlatformManager;
		internal GameObject CustomPlatformManagerRButtons;
		internal GameObject CustomPlatformManagerBButtons;
		internal GameObject CustomPlatformManagerGButtons;
		public TMP_Text CustomPlatformManagerVersionText;
		public GameObject CustomPlatformManagerRedTextObject;
		public GameObject CustomPlatformManagerBlueTextObject;
		public GameObject CustomPlatformManagerGreenTextObject;
		public UnityEngine.Component UnusedButtons1;
		public UnityEngine.Component UnusedButtons2;
		public Vector3 MenuPos = new Vector3(-65.2155f, 12.25f, -80.9355f);
		public Vector3 MenuRot = new Vector3(0f, 300f, 0f);
		public static Plugin Instance;
		public static Vector3 globalSize = new Vector3(0.04f, 0.25f, 0.25f);

		void Start()
		{
			var bundle = LoadAssetBundle("CustomPlatformManager.model");
			CustomPlatformManager = bundle.LoadAsset<GameObject>("CustomPlatformManagerMenu");
			var CustomPlatform = bundle.LoadAsset<GameObject>("CustomPlatformManagerMenu");
			CustomPlatformManagerRButtons = CustomPlatformManager.transform.Find("ColorButtons")?.gameObject.transform.Find("Red")?.gameObject;
			CustomPlatformManagerBButtons = CustomPlatformManager.transform.Find("ColorButtons")?.gameObject.transform.Find("Blue")?.gameObject;
			CustomPlatformManagerGButtons = CustomPlatformManager.transform.Find("ColorButtons")?.gameObject.transform.Find("Green")?.gameObject;
			CustomPlatformManagerVersionText = CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("VersionNumber")?.gameObject.GetComponent<TextMeshPro>();
			CustomPlatformManagerRedTextObject = CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("RValues")?.gameObject;
			CustomPlatformManagerBlueTextObject = CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("BValues")?.gameObject;
			CustomPlatformManagerGreenTextObject = CustomPlatformManager.transform.Find("Computer")?.gameObject.transform.Find("Color")?.gameObject.transform.Find("GValues")?.gameObject;
			Utilla.Events.GameInitialized += OnGameInitialized;
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			Prepare();
			Debug.Log(PluginInfo.Version);
			Instance = this;
			CustomPlatL = GameObject.CreatePrimitive(PrimitiveType.Cube);
			CustomPlatL.transform.position = new Vector3(0, 0, 0);
			CustomPlatR = GameObject.CreatePrimitive(PrimitiveType.Cube);
			CustomPlatR.transform.position = new Vector3(0, 0, 0);
			CustomPlatformManager.transform.position = MenuPos;
			CustomPlatformManager.transform.rotation = Quaternion.Euler(MenuRot);
			CustomPlatformManager.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			CustomPlatL.name = "CustomPlatL";
			CustomPlatR.name = "CustomPlatR";
			CustomPlatR.transform.localScale = globalSize;
			CustomPlatL.transform.localScale = globalSize;
			CubeMaterialR = new Material(Shader.Find("Universal Render Pipeline/Lit"));
			CubeMaterialL = new Material(Shader.Find("Universal Render Pipeline/Lit"));
			CustomPlatR.GetComponent<Renderer>().material = CubeMaterialR;
			CustomPlatL.GetComponent<Renderer>().material = CubeMaterialL;
			CubeMaterialL.color = new Color(0, 0, 0);
			CubeMaterialR.color = new Color(0, 0, 0);
			CustomPlatformManagerVersionText.text = "Custom Platform Manager v" + PluginInfo.Version;
			foreach (Transform child in CustomPlatformManager.transform)
			{
				child.gameObject.AddComponent<GorillaSurfaceOverride>();
			}
			foreach (Transform child in CustomPlatformManagerRButtons.transform)
			{
				child.gameObject.AddComponent<colorchange>();
			}
			foreach (Transform child in CustomPlatformManagerBButtons.transform)
			{
				child.gameObject.AddComponent<colorchange>();
			}
			foreach (Transform child in CustomPlatformManagerGButtons.transform)
			{
				child.gameObject.AddComponent<colorchange>();
			}
			foreach (Transform child in CustomPlatformManager.transform.Find("ShapeButtons")?.gameObject.transform)
			{
				child.gameObject.AddComponent<shapechange>();
			}
			foreach (Transform child in CustomPlatformManager.transform.Find("SizeButtons")?.gameObject.transform)
			{
				child.gameObject.AddComponent<sizechange>();
			}
			Instantiate(CustomPlatL);
			Instantiate(CustomPlatR);
			CustomPlatL.AddComponent<GorillaSurfaceOverride>();
			CustomPlatR.AddComponent<GorillaSurfaceOverride>();
			Destroy(CustomPlatL.GetComponent<BoxCollider>());
			Destroy(CustomPlatR.GetComponent<BoxCollider>());
			CustomPlatR.AddComponent<BoxCollider>();
			CustomPlatL.AddComponent<BoxCollider>();
			CustomPlatformManager.transform.Find("COLORS")?.gameObject.AddComponent<switchbutton>();
			CustomPlatformManager.transform.Find("SHAPE")?.gameObject.AddComponent<switchbutton>();
			CustomPlatformManager.transform.Find("SIZE")?.gameObject.AddComponent<switchbutton>();
			UnusedButtons1 = CustomPlatformManager.transform.Find("ShapeButtons/UnusedShapeButtons")?.gameObject.GetComponent<shapechange>();
			UnusedButtons2 = CustomPlatformManager.transform.Find("SizeButtons/UnusedButtonsSize")?.gameObject.GetComponent<sizechange>();
			Destroy(UnusedButtons1);
			Destroy(UnusedButtons2);
			CustomPlatformManager = Instantiate(CustomPlatformManager);
			Debug.Log("Platform Manager was instantiated");
		}

		void Prepare()
		{
			Debug.Log("Prepare() method called");
			var colorTransform = CustomPlatformManager.transform.Find("Computer/Color");
			foreach (Transform child in colorTransform.gameObject.GetComponentsInChildren<Transform>())
			{
				Debug.Log($"childname: {child.name}");
				if (child.parent.name.EndsWith("Values"))
				{
					bool shouldBeActive = child.name.EndsWith("0");
					child.gameObject.SetActive(shouldBeActive);
				}
			}
		}

		public AssetBundle LoadAssetBundle(string path)
		{
			Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
			AssetBundle bundle = AssetBundle.LoadFromStream(stream);
			stream.Close();
			return bundle;
		}
		void Update()
		{
			if (inRoom)
			{
				//right controller
				if (ControllerInputPoller.instance.rightControllerGripFloat >= 0.5f)
				{
					if (platSetR == false)
					{
						CustomPlatR.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
						CustomPlatR.transform.translate(platOffset);
						CustomPlatR.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
						platSetR = true;
						CustomPlatR.transform.localScale = globalSize;
						CustomPlatL.transform.localScale = globalSize;
						CustomPlatR.GetComponent<Renderer>().material = CubeMaterialR;
						CustomPlatL.GetComponent<Renderer>().material = CubeMaterialL;
					}
				}
				else
				{
					platSetR = false;
					CustomPlatR.transform.position = new Vector3(0, 0, 0);
					CustomPlatR.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
					CustomPlatR.transform.localScale = globalSize;
					CustomPlatL.transform.localScale = globalSize;
					CustomPlatR.GetComponent<Renderer>().material = CubeMaterialR;
					CustomPlatL.GetComponent<Renderer>().material = CubeMaterialL;
				}
				//left controller
				if (ControllerInputPoller.instance.leftControllerGripFloat >= 0.5f)
				{
					if (platSetL == false)
					{
						CustomPlatL.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
						CustomPlatL.transform.translate(platOffset);
						CustomPlatL.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
						platSetL = true;
						CustomPlatR.transform.localScale = globalSize;
						CustomPlatL.transform.localScale = globalSize;
						CustomPlatR.GetComponent<Renderer>().material = CubeMaterialR;
						CustomPlatL.GetComponent<Renderer>().material = CubeMaterialL;
					}
				}
				else
				{
					CustomPlatL.transform.position = new Vector3(0, 0, 0);
					platSetL = false;
					CustomPlatL.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
					CustomPlatR.transform.localScale = globalSize;
					CustomPlatL.transform.localScale = globalSize;
					CustomPlatR.GetComponent<Renderer>().material = CubeMaterialR;
					CustomPlatL.GetComponent<Renderer>().material = CubeMaterialL;
				}

				if (!inRoom)
				{
					CustomPlatL.transform.position = new Vector3(0, 0, 0);
					CustomPlatR.transform.position = new Vector3(0, 0, 0);
				}

			}
		}
		/* This attribute tells Utilla to call this method when a modded room is joined */
		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			/* Activate your mod here */
			/* This code will run regardless of if the mod is enabled*/
			/* Make sure all code is going to be here or else your mod will be considered a cheat.*/
			CustomPlatL.transform.position = new Vector3(0, 0, 0);
			CustomPlatR.transform.position = new Vector3(0, 0, 0);
			CustomPlatformManager.SetActive(true);
			inRoom = true;
		}

		/* This attribute tells Utilla to call this method when a modded room is left */
		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			/* Deactivate your mod here */
			/* This code will run regardless of if the mod is enabled*/
			CustomPlatL.transform.position = new Vector3(0, 0, 0);
			CustomPlatR.transform.position = new Vector3(0, 0, 0);
			CustomPlatformManager.SetActive(false);
			inRoom = false;
		}
	}
}