using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public class HGameManager : MonoBehaviour
	{
		private static HGameManager mInstance;

		public static HGameManager Instance
		{
			get
			{
				return mInstance;
			}
		}

		private void Awake()
		{
			mInstance = this;
		}

		public GameObject BaseBulletPrefab;
	}
}
