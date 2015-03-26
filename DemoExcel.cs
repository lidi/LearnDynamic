using System.ComponentModel;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace LearnDynamic
{
    class DynamicExcel
    {
        static void Main()
        {
            var app = new Application { Visible = true };
            app.Workbooks.Add();
            Worksheet worksheet = app.ActiveSheet;
            Range start = worksheet.Cells[1, 1];
            Range end = worksheet.Cells[1, 20];
            worksheet.Range[start, end].Value = Enumerable.Range(1, 20).ToArray();
        }
    }
}
