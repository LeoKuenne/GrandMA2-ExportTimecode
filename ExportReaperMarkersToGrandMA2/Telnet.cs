using ExportReaperMarkersToGrandMA2;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class Telnet
{

    public Telnet()
	{
        //Console.Write("Host: ");
        string host = "192.168.178.24";
        //Console.Write("Port: ");
        int port;
        TcpClient socket = null;

        try
        {
            port = int.Parse("30000");
        }
        catch (Exception)
        {
            Console.WriteLine("Wrong parameter. Using 23 instead");
            port = 23;
        }


        try
        {
            socket = new TcpClient(host, port);
        }
        catch (SocketException)
        {
            Console.WriteLine("Unknown host - " + host + ". Quitting");
            Console.ReadKey();
            Environment.Exit(0);
        }

        NetworkStream stream = socket.GetStream();
        StreamReader input = new StreamReader(stream);
        StreamWriter output = new StreamWriter(stream);

        Exception ex = null;


        Thread t = new Thread(() =>
        {
            try
            {

            }
            catch (MA2CommandNotExecutedException e)
            {
                ex = e;
            }

        });

        t.Start();
        t.Join();







        if(ex != null)
        {

        }



        while (true)
        {
            output.Write(Console.ReadLine() + "\r\n");
            output.Flush();
        }
    }
}
