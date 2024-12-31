using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

class FileServer
{
    static void Main(string[] args)
    {
        const int port = 9000;
        string savePath = @"G:\hianhvinh.txt";


        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine("Server active...");

        using (TcpClient client = listener.AcceptTcpClient())
        {
            Console.WriteLine("Client connect!");
            using (NetworkStream stream = client.GetStream())
            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, bytesRead);
                }
            }
        }

        Console.WriteLine($"File da duoc gui thanh cong: {savePath}");
        listener.Stop();
    }
}
