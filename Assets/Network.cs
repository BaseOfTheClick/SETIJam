using UnityEngine;
using System;
using System.Net;
using System.Collections;

public class Network : MonoBehaviour {

    const string serverHost = "np.nixcode.us";
    const int serverPort = 31337;

	// Use this for initialization
	void Start () {
	    IPAddress[] addrs = Dns.Resolve(serverHost).AddressList;
        TcpClient client = null;
        Stream stream = null;
        StreamReader sr = null;
        StreamWriter sw = null;

        foreach(IPAddress addr in addrs)
        {
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

        }

        sw.WriteLine("GIMME");
        string response = sr.ReadLine();

        if(response == "green")
            // Make something green
        else if(response == "red")
            // Make something red

	}

	// Update is called once per frame
	void Update () {
	
	}
}
