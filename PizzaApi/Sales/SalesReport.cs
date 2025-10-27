using System.Globalization;
using System.Text;

namespace WorkWithFilesApp.Sales
{
    public static class SalesReport
    {
        public static string BuildSalesSummary(string directoryPath)
        {
            var sb = new StringBuilder();
            decimal grandTotal = 0m;
            var detailLines = new List<string>();

            // Loop through all .txt files
            foreach (var file in Directory.EnumerateFiles(directoryPath, "*.txt"))
            {
                decimal fileTotal = 0m;

                foreach (var line in File.ReadLines(file))
                {
                    if (decimal.TryParse(
                        line,
                        NumberStyles.Currency | NumberStyles.Number,
                        CultureInfo.CurrentCulture,
                        out var value))
                    {
                        fileTotal += value;
                    }
                }

                grandTotal += fileTotal;
                detailLines.Add($"  {Path.GetFileName(file)}: {fileTotal:C}");
            }

            sb.AppendLine("Sales Summary");
            sb.AppendLine("----------------------------");
            sb.AppendLine($" Total Sales: {grandTotal:C}");
            sb.AppendLine();
            sb.AppendLine("Details:");
            foreach (var d in detailLines)
                sb.AppendLine(d);

            var reportPath = Path.Combine(directoryPath, "SalesSummary.txt");
            File.WriteAllText(reportPath, sb.ToString());
            return reportPath;
        }
    }
}
