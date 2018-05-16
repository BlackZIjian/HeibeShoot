using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public class HCameraComponent : HBaseComponent
	{

		public Camera EyeCamera;

		private void Awake()
		{
			if (EyeCamera == null)
			{
				EyeCamera = Camera.main;
			}
		}

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}
