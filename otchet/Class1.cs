using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace otchet
{
    public class Create
    {
        public Create()
        {
            Excel.Application app = new Excel.Application
            {
                Visible = true,

                SheetsInNewWorkbook = 1
            };

            Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);

            app.DisplayAlerts= false;

            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);

            sheet.Name = "Отчет";

            //Шапка
            sheet.get_Range("A1", "A2").Merge(Type.Missing);
            sheet.get_Range("A1", "A2").Value = "№";

            sheet.get_Range("B1", "B2").Merge(Type.Missing);
            sheet.get_Range("B1", "B2").Value2 = "ФИО";

            sheet.get_Range("C1", "C2").Merge(Type.Missing);
            sheet.get_Range("C1", "C2").Value2 = "Наименование должности";

            sheet.get_Range("D1", "D2").Merge(Type.Missing);
            sheet.get_Range("D1", "D2").Value2 = "Должностной оклад";

            sheet.Cells[2, 5] = "Январь";
            sheet.Cells[2, 6] = "Февраль";
            sheet.Cells[2, 7] = "Март";
            sheet.Cells[2, 8] = "Апрель";
            sheet.Cells[2, 9] = "Май";
            sheet.Cells[2, 10] = "Июнь";
            sheet.Cells[2, 11] = "Июль";
            sheet.Cells[2, 12] = "Август";
            sheet.Cells[2, 13] = "Сентябрь";
            sheet.Cells[2, 14] = "Октябрь";
            sheet.Cells[2, 15] = "Ноябрь";
            sheet.Cells[2, 16] = "Декабрь";

            Excel.Range range = sheet.get_Range("E1", "P1");
            range.Merge(Type.Missing);
            range.Value = "Колличество баллов";
            

            sheet.get_Range("Q1", "Q2").Merge(Type.Missing);
            sheet.get_Range("Q1", "Q2").Value2 = "Итого баллов";

            sheet.get_Range("R1", "R2").Merge(Type.Missing);
            sheet.get_Range("R1", "R2").Value2 = "Подпись сотрудника";

            sheet.get_Range("S1", "S2").Merge(Type.Missing);
            sheet.get_Range("S1", "S2").Value2 = "Примечание";

            //Форматирование текста шапки
            Excel.Range headRange = sheet.get_Range("A1", "S2");
            headRange.Orientation = 90;
            headRange.Font.Name = "Times New Roman";
            headRange.Font.Size = 12;
            headRange.WrapText= true;
            headRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            range.Orientation = 0;
            
            //расширение ячеек
            sheet.Rows[1].RowHeight = 17;
            sheet.Rows[2].RowHeight = 80;

            app.Application.ActiveWorkbook.SaveAs(@"C:\Users\Bbil\Desktop\мама\прога\Баллы\Баллы\bin\Debug\Отчет.xlsx", Type.Missing,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
              Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }
        
        
    }
   
}
