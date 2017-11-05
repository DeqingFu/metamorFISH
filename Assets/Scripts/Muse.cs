using UnityEngine;
using System.Collections;
using System;
using SharpOSC;

/* This class is never instantiated, so everything is a static function */
public class Muse : MonoBehaviour {
	public UDPListener listener;

	/* muse information available to other scripts */
	public static int blinks = 0;
	public static int jaw = 0;
	public static int clenches = 0;
	public static int battery = 0;
	public int jaw_lim;
	public static float concentration = 0.0f;

	private static float[] acc_recent = { 0.0f, 0.0f, 0.0f };			// Most recently recorded acc data

	void Start() 
	{
		// Callback function for received OSC messages.
		HandleOscPacket callback = delegate(OscPacket packet)
		{
			var messageReceived = (OscMessage)packet;
			var addr = messageReceived.Address;
			if(addr == "/muse/acc") {
				//head position and accleration
				float[] acc_data = { 
					(float)messageReceived.Arguments[0],
					(float)messageReceived.Arguments[1],
					(float)messageReceived.Arguments[2]
				};
				CallbackAcc(acc_data);
			}

			else if(addr == "/muse/elements/blink") {
				blinks = (int)messageReceived.Arguments[0];
			}

			else if (addr == "/muse/elements/jaw_clench") {
				int clench = (int) messageReceived.Arguments[0];
				clenches += clench;
				if (clenches >= jaw_lim) {
					jaw++;
					clenches = 0;
				}
			}

			else if(addr == "/muse/elements/experimental/concentration"){
				concentration = (float)messageReceived.Arguments[0]; 
			}

			if(addr == "/muse/batt") {
				if (battery != (int)messageReceived.Arguments[0]) {
					battery = (int)messageReceived.Arguments[0];
				}
			}
		};

		// Create an OSC server.
		listener = new UDPListener(5000, callback);

	}

	void Update() 
	{
		if (blinks >= 2) {
			blinks = blinks - 2;
		}
		jaw = 0;
	}

	void OnApplicationQuit() 
	{
		listener.Close();
	}
		
	private static void CallbackAcc(float[] acc_data)
	{
		for (int i = 0; i < 3; i++)
			acc_recent[i] = acc_data[i];
	}

	public static float GetAccLeftRight()
	{
		return acc_recent[2];
	}
	public static float GetAccUpDown()
	{
		return acc_recent[1];
	}
}	