using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections;

public class Network : MonoBehaviour {

    const string serverHost = "np.nixcode.us";
    const int serverPort = 31337;

	// Use this for initialization
	void Start () {
        TcpClient client = null;
        Stream stream = null;
        StreamReader sr = null;
        StreamWriter sw = null;

        client = new TcpClient(serverHost, serverPort);
    	try {
        	stream = client.GetStream();
        	sr = new StreamReader(stream);
        	sw = new StreamWriter(stream);
        	sw.AutoFlush = true;
    	}
    	finally {
        	client.Close();
    	}

        sw.WriteLine("GIMME");
        string response = sr.ReadLine();

		GameObject cube = GameObject.Find("Cube");

        if (response == "green") {
			Color color = new Color(255, 255, 255, 1);
			cube.GetComponent<MeshRenderer>().material.color = color;
		}
		/*
        else if(response == "red")
            // Make something red
		*/
	}

	// Update is called once per frame
	void Update () {
	
	}
}
