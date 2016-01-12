using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.Google.Util
{
    public static class Utilities
    {
        public static int[,] ReadMatrixFromFile(string path)
        {
            int[,] matrix;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader reader = new StreamReader(fs))
            {
                string text = reader.ReadToEnd();
                string[] rows = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                matrix = new int[rows.Length, rows.Length];

                for (int r = 0; r < rows.Length; r++)
                {
                    string[] values = rows[r].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int v = 0; v < values.Length; v++)
                    {
                        int value = 0;
                        if (int.TryParse(values[v], out value))
                        {
                            matrix[r, v] = value;
                        }
                    }
                }
            }

            return matrix;
        }

        public static void ExportMatrixToCSVFile(int[,] matrix, string path)
        {
            using (var stream = File.Create(path))
            using (var writer = new StreamWriter(stream))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        writer.Write(matrix[i, j] + ",");
                    }
                    writer.WriteLine();
                }
            }
        }
    }

    public class AddressInfo
    {
        public int Id { get; set; }
        public string PostCode { get; set; }
        public int Duration { get; set; }
        public int Distance { get; set; }
    }

    public class PickupPlan
    {
        public List<int> PickUpPoints { get; set; }

        public int TotalDuration { get; set; }

        public PickupPlan(IEnumerable<int> pickupIds, int duration)
        {
            this.PickUpPoints = pickupIds.ToList();

            this.TotalDuration = duration;
        }
    }


}
