using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Heibe.Shooter
{
	public enum MessageId
	{
		HeroHealthUpdate,
		HeroDead,
		None,
	}

	public class Message
	{
		public object Content;
		
		public T Decode<T>() where T : Message
		{
			if (this is T)
			{
				return this as T;
			}

			return default(T);
		}
	}
	public class MessageManager
	{
		private static MessageManager mInstance;

		public static MessageManager Instance
		{
			get
			{
				if (mInstance == null)
				{
					mInstance = new MessageManager();
				}

				return mInstance;
			}
		}
		
		private readonly Message mEmptyMessage = new Message();

		private Dictionary<int, Action<Message>> mMessageDic;

		public void Initial()
		{
			if (mMessageDic != null)
			{
				mMessageDic.Clear();
			}
			
			mMessageDic = new Dictionary<int, Action<Message>>();
		}

		public void Register(MessageId id,Action<Message> callback)
		{
			int _id = (int) id;
			if (mMessageDic.ContainsKey(_id))
			{
				if (mMessageDic[_id] == null)
					mMessageDic[_id] = callback;
				else
					mMessageDic[_id] += callback;
			}
			else
			{
				mMessageDic.Add(_id,callback);
			}
		}

		public void UnRegister(MessageId id, Action<Message> callback)
		{
			int _id = (int) id;
			if (mMessageDic.ContainsKey(_id))
			{
				if (mMessageDic[_id] != null)
					mMessageDic[_id] -= callback;
			}
		}

		public void SendMessage(MessageId id, Message mes = null)
		{
			if (mes == null)
			{
				mes = mEmptyMessage;
			}
			int _id = (int) id;
			if (mMessageDic.ContainsKey(_id))
			{
				mMessageDic[_id].Invoke(mes);
			}
		}
	}
}
