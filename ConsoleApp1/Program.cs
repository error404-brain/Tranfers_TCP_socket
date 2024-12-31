using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

class FileSender
{
    static void Main(string[] args)
    {
        const string serverIp = "127.0.0.1"; 
        const int port = 9000;
        string filePath = @"G:\path_to_your_file.txt"; 

        try
        {
            using (TcpClient client = new TcpClient(serverIp, port))
            using (NetworkStream stream = client.GetStream())
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }

            Console.WriteLine("File sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}