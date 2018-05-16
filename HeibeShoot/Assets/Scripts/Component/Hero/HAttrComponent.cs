using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public class HealthUpdateMessage : Message
	{
		public int Id;
		public int NewHealth;
		public int OldHealth;
	}
	public class HAttrComponent : HBaseComponent
	{
		public void Awake()
		{
			mId = HAttrComponent.mIdCount;
			HAttrComponent.mIdCount++;
			
			if(mAttrComponentDic == null)
				mAttrComponentDic = new Dictionary<int, HAttrComponent>();

			if (mAttrComponentDic.ContainsKey(mId))
			{
				Debug.LogError("Entity Id 重复");
				Destroy(Owner);
			}
			else
			{
				mAttrComponentDic.Add(mId,this);
			}
		}
		
		private readonly HealthUpdateMessage mHealthUpdateMessage = new HealthUpdateMessage();
		private readonly Message mDeadMessage = new Message();

		private static int mIdCount;
		private static Dictionary<int, HAttrComponent> mAttrComponentDic;

		public static HAttrComponent Get(int id)
		{
			if (mAttrComponentDic == null)
				return null;

			if (!mAttrComponentDic.ContainsKey(id))
				return null;

			return mAttrComponentDic[id];
		}

		private int mMaxHealth;
		public int MaxHealth
		{
			get { return mMaxHealth; }
		}

		private int mId;
		public int Id
		{
			get { return mId; }
		}

		private int mHealth;
		public int Health
		{
			get { return mHealth; }
			set
			{
				if (mHealth >= mMaxHealth)
				{
					mHealth = mMaxHealth;
					return;
				}
				
				mHealthUpdateMessage.Id = mId;
				mHealthUpdateMessage.NewHealth = value;
				mHealthUpdateMessage.OldHealth = mHealth;
				MessageManager.Instance.SendMessage(MessageId.HeroHealthUpdate,mHealthUpdateMessage);
				
				mHealth = value;
				if (mHealth <= 0)
				{
					mHealth = 0;
					mDeadMessage.Content = mId;
					MessageManager.Instance.SendMessage(MessageId.HeroDead,mDeadMessage);
				}
			}
		}

		public bool IsAlive
		{
			get { return mHealth > 0; }
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
