using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace Attrib
{
    public class Coordinates
    {
        public int x;
        public int y;
    };

    // Need to find a starting level that's good for this game!
    class Aspect
    {
        uint level;
        const uint max = 100;
    };

    class Resources
    {
        Aspect economy;
        Aspect politics;
        Aspect research;
    };

    public class Planet
    {
        public Coordinates co;
        uint _radius;
        Resources re;
        string name;
        uint _age;

        public Planet(Coordinates coords, string pname)
        {
            co = coords;
            name = pname;
        }

    };
};

namespace Net
{
    public class Connector
    {
        TcpClient client = null;
        NetworkStream stream = null;
        string serverHost = string.Empty;
        int serverPort;
        Byte[] chunk = null;

        public Connector(string host, int port)
        {
            if(!connect(host, port))
            {
                Console.WriteLine("Net::Connector(host, port) unable "
                    + "to connect to " + host + ":" + port);
            }
        }

        public bool connect(string host = null, int port = 0)
        {
            if(host != null)
            {
                serverHost = host;
                serverPort = port;
            }

            if(serverHost == null)
                return false;

            client = new TcpClient(serverHost, serverPort);
            stream = client.GetStream();

            return true;
        }

        public string readChunk(int size)
        {
            chunk = new Byte[size];
            Int32 bytes = stream.Read(chunk, 0, size - 1);
            if(bytes <= 0)
                return "";

            string temp = System.Text.Encoding.ASCII.GetString(chunk);
            return temp;
        }

        public void write(string text)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
            stream.Write(data, 0, data.Length);
        } 
        
        public void close()
        {
            stream.Close();
            client.Close();
        }

    };
};

class MainClass
{
    const string serverHost = "localhost";
    const int serverPort = 31337;

    // Use this for initialization
    public static void Main (string[] args)
    {
        Net.Connector socket = new Net.Connector(serverHost, serverPort);

        socket.write("GIMME\n");
        string response = socket.readChunk(512);

        Console.WriteLine(response);
        socket.close();
    }
};
