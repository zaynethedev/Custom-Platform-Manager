using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;
using CubeSummoner.buttons;
using System.ComponentModel;
using TMPro;
using System.Threading.Tasks;

namespace CubeSummoner
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
		public static Plugin Instance;

		void Start()
		{
			var bundle = LoadAssetBundle("CubeSummoner.model");
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
			CustomPlatformManager.transform.position = new Vector3(-65.76f, 12.19f, -81.49f);
			CustomPlatformManager.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			CustomPlatL.name = "CustomPlatL";
			CustomPlatR.name = "CustomPlatR";
			CustomPlatR.transform.localScale = new Vector3(0.25f, 0.04f, 0.25f);
			CustomPlatL.transform.localScale = new Vector3(0.25f, 0.04f, 0.25f);
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
			Instantiate(CustomPlatL);
			Instantiate(CustomPlatR);
			CustomPlatL.AddComponent<GorillaSurfaceOverride>();
			CustomPlatR.AddComponent<GorillaSurfaceOverride>();
			CustomPlatformManager = Instantiate(CustomPlatformManager);
			Debug.Log("Platform Manager was instantiated");
		}

		void Prepare()
		{
			Debug.Log("Prepare() method called");
			// Get a reference to the Color transform ONCE
			var colorTransform = CustomPlatformManager.transform.Find("Computer/Color");
			// Loop through all children of the Color transform
			foreach (Transform child in colorTransform.gameObject.GetComponentsInChildren<Transform>())
			{
				Debug.Log($"childname: {child.name}");
				if (child.parent.name.EndsWith("Values"))
				{
					// Only run this code if the parent of the current child is "RValues", "GValues" or "BValues"
					// If the child name ends with 0, it should be active, otherwise, inactive
					bool shouldBeActive = child.name.EndsWith("0");
					// set the child's active state to the bool we just calculated
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
						CustomPlatR.transform.eulerAngles = new Vector3(GorillaLocomotion.Player.Instance.rightControllerTransform.eulerAngles.x, GorillaLocomotion.Player.Instance.rightControllerTransform.eulerAngles.y, GorillaLocomotion.Player.Instance.rightControllerTransform.eulerAngles.z);
						CustomPlatR.transform.position = new Vector3(GorillaLocomotion.Player.Instance.rightControllerTransform.position.x, GorillaLocomotion.Player.Instance.rightControllerTransform.position.y, GorillaLocomotion.Player.Instance.rightControllerTransform.position.z);
						platSetR = true;
					}
				}
				else
				{
					platSetR = false;
					CustomPlatR.transform.position = new Vector3(0, 0, 0);
					CustomPlatR.transform.eulerAngles = new Vector3(0, 0, 0);
				}
				//left controller
				if (ControllerInputPoller.instance.leftControllerGripFloat >= 0.5f)
				{
					if (platSetL == false)
					{
						CustomPlatL.transform.eulerAngles = new Vector3(GorillaLocomotion.Player.Instance.leftControllerTransform.eulerAngles.x, GorillaLocomotion.Player.Instance.leftControllerTransform.eulerAngles.y, GorillaLocomotion.Player.Instance.leftControllerTransform.eulerAngles.z);
						CustomPlatL.transform.position = new Vector3(GorillaLocomotion.Player.Instance.leftControllerTransform.position.x, GorillaLocomotion.Player.Instance.leftControllerTransform.position.y, GorillaLocomotion.Player.Instance.leftControllerTransform.position.z);
						platSetL = true;
					}
				}
				else
				{
					platSetL = false;
					CustomPlatL.transform.position = new Vector3(0, 0, 0);
					CustomPlatL.transform.eulerAngles = new Vector3(0, 0, 0);
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
			inRoom = true;
		}

		/* This attribute tells Utilla to call this method when a modded room is left */
		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			/* Deactivate your mod here */
			/* This code will run regardless of if the mod is enabled*/

			inRoom = false;
		}
	}
}
