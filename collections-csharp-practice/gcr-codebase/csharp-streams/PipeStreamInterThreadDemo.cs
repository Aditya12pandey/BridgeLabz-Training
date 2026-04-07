using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

class PipeStreamInterThreadDemo
{
    static void Main()
    {
        try
        {
            //  Create pipe server (writer side)
            using (AnonymousPipeServerStream pipeServer =
                   new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            {
                //  Create pipe client (reader side)
                using (AnonymousPipeClientStream pipeClient =
                       new AnonymousPipeClientStream(PipeDirection.In, pipeServer.GetClientHandleAsString()))
                {
                    Thread writerThread = new Thread(() => Writer(pipeServer));
                    Thread readerThread = new Thread(() => Reader(pipeClient));

                    writerThread.Start();
                    readerThread.Start();

                    writerThread.Join();
                    readerThread.Join();
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("I/O Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.WriteLine("\n Program finished.");
    }

    static void Writer(AnonymousPipeServerStream pipeServer)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(pipeServer))
            {
                writer.AutoFlush = true; //  Important to prevent data loss

                for (int i = 1; i <= 5; i++)
                {
                    string message = "Message " + i;
                    writer.WriteLine(message);

                    Console.WriteLine("[Writer] Sent: " + message);

                    pipeServer.WaitForPipeDrain(); //  ensures reader gets data
                    Thread.Sleep(500);
                }

                writer.WriteLine("END");
                Console.WriteLine("[Writer] Sent: END");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("[Writer] I/O Error: " + ex.Message);
        }
    }

    static void Reader(AnonymousPipeClientStream pipeClient)
    {
        try
        {
            using (StreamReader reader = new StreamReader(pipeClient))
            {
                while (true)
                {
                    string data = reader.ReadLine();

                    if (data == null)
                        break;

                    Console.WriteLine("    [Reader] Received: " + data);

                    if (data == "END")
                        break;
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("[Reader] I/O Error: " + ex.Message);
        }
    }
}
