using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public class HBaseComponent : MonoBehaviour
	{
		public GameObject Owner
		{
			get { return gameObject; }
		}

		public T Component<T>() where T : HBaseComponent
		{
			if (Owner == null)
				return default(T);

			return Owner.GetComponent<T>();
		}

		public static T Get<T>(GameObject owner) where T : HBaseComponent
		{
			if (owner == null)
				return default(T);

			return owner.GetComponent<T>();
		}
		
		public static T Get<T>(int id) where T : HBaseComponent
		{
			GameObject owner = HAttrComponent.Get(id).Owner;
			if (owner == null)
				return default(T);

			return Get<T>(owner);
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
