using System.Text.Json;

namespace Lab6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Event e = new Event(1, "Calgary");

			// Console.WriteLine(e.EventNumber);
			// Console.WriteLine(e.Location);

			string JSONfileName = "events.json";
			string encoded = JsonSerializer.Serialize(e);
			File.WriteAllText(JSONfileName, encoded);

			string fileContent = File.ReadAllText(JSONfileName);
			Event decoded = JsonSerializer.Deserialize<Event>(fileContent);

			Console.WriteLine(decoded.EventNumber);
			Console.WriteLine(decoded.Location);

			Console.WriteLine("Tech Competition");

			string HackathonFileName = "hackathon.txt";
			ReadFromFile(HackathonFileName);
		}

		static void ReadFromFile(string fileName) 
		{
			Console.WriteLine("In Word: Hackathon");
			using(StreamWriter sw = new StreamWriter(fileName))
			{
				sw.Write("Hackathon");
			}

			using (StreamReader sr = new StreamReader(fileName))
			{
				sr.BaseStream.Seek(0, SeekOrigin.Begin);
				Console.WriteLine("The First Character is: \"{0}\"", (char)sr.Read());

				sr.DiscardBufferedData();
				sr.BaseStream.Seek(4, SeekOrigin.Begin);
				Console.WriteLine("The Middle Character is: \"{0}\"", (char)sr.Read());

				sr.DiscardBufferedData();
				sr.BaseStream.Seek(8, SeekOrigin.Begin);
				Console.WriteLine("The Last Character is: \"{0}\"", (char)sr.Read());
			}
		}
	}
}