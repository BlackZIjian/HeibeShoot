using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public enum BulletType
	{
		Mm9,
		Mm556,
		Wm300,
		None
	}
	public class HBaseBullet : MonoBehaviour
	{
		private GameObject mOwner;

		public GameObject Owner
		{
			get { return mOwner; }
		}

		public static HBaseBullet Create(GameObject prefab,Vector3 pos,Quaternion rot)
		{
			GameObject obj = Instantiate(prefab,pos,rot);
			HBaseBullet bullet = obj.AddComponent<HBaseBullet>();
			bullet.mOwner = obj;
			return bullet;
		}

		private void OnCollisionEnter(Collision other)
		{
			
		}
	}
}
