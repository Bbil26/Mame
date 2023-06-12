using Excel = Microsoft.Office.Interop.Excel;
using System;
using Логика;
using System.Collections.ObjectModel;

namespace otchet
{
    public class Create
    {
        public Create(ObservableCollection<TeloPeople> listPeoples, int countOtchet)
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
            sheet.Columns[17].ColumnWidth = 7;
            sheet.Columns[19].ColumnWidth = 19;
            sheet.Columns[1].ColumnWidth = 3;
            sheet.Columns[2].ColumnWidth = 10;
            sheet.Columns[3].ColumnWidth = 12;
            for (int i = 5; i <= 16; i++)
                sheet.Columns[i].ColumnWidth = 5;

            int count = listPeoples.Count;

            for (int i = 0; i < count; i++)
            {
                sheet.Cells[i+3, 1].Value = i + 1;
            }

            int xTemp = 3;
            string lineOtpusk = "";
            double sumScore;
            
            if (countOtchet == 6)
            {
                foreach (var item in listPeoples)
                {
                    foreach (var i in item._Otpusk)
                        lineOtpusk += i + "\t";

                    sumScore = 50 * 6 - (item._Jan + item._Feb + item._Mar + item._Apr +
                        item._May + item._June);

                    sheet.Cells[xTemp, 2] = item._Name;
                    sheet.Cells[xTemp, 3] = item._Job;
                    sheet.Cells[xTemp, 4] = item._Oklad;
                    sheet.Cells[xTemp, 5].Value = string.Format("{0:F2}", 50 - item._Jan);
                    sheet.Cells[xTemp, 6].Value = string.Format("{0:F2}", 50 - item._Feb);
                    sheet.Cells[xTemp, 7].Value = string.Format("{0:F2}", 50 - item._Mar);
                    sheet.Cells[xTemp, 8].Value = string.Format("{0:F2}", 50 - item._Apr);
                    sheet.Cells[xTemp, 9].Value = string.Format("{0:F2}", 50 - item._May);
                    sheet.Cells[xTemp, 10].Value = string.Format("{0:F2}", 50 - item._June);

                    sheet.Cells[xTemp, 17] = string.Format("{0:F2}", sumScore);
                    sheet.Cells[xTemp, 19] = lineOtpusk;
                    xTemp++;
                }
            }
            
            else if(countOtchet == 9 )
            {
                foreach (var item in listPeoples)
                {
                    foreach (var i in item._Otpusk)
                        lineOtpusk += i + "\t";

                    sumScore = 50 * 9 - (item._Jan + item._Feb + item._Mar + item._Apr +
                        item._May + item._June + item._July + item._Aug +
                        item._Sep);

                    sheet.Cells[xTemp, 2] = item._Name;
                    sheet.Cells[xTemp, 3] = item._Job;
                    sheet.Cells[xTemp, 4] = item._Oklad;
                    sheet.Cells[xTemp, 5].Value = string.Format("{0:F2}", 50 - item._Jan);
                    sheet.Cells[xTemp, 6].Value = string.Format("{0:F2}", 50 - item._Feb);
                    sheet.Cells[xTemp, 7].Value = string.Format("{0:F2}", 50 - item._Mar);
                    sheet.Cells[xTemp, 8].Value = string.Format("{0:F2}", 50 - item._Apr);
                    sheet.Cells[xTemp, 9].Value = string.Format("{0:F2}", 50 - item._May);
                    sheet.Cells[xTemp, 10].Value = string.Format("{0:F2}", 50 - item._June);
                    sheet.Cells[xTemp, 11].Value = string.Format("{0:F2}", 50 - item._July);
                    sheet.Cells[xTemp, 12].Value = string.Format("{0:F2}", 50 - item._Aug);
                    sheet.Cells[xTemp, 13].Value = string.Format("{0:F2}", 50 - item._Sep);
                    sheet.Cells[xTemp, 17] = string.Format("{0:F2}", sumScore);
                    sheet.Cells[xTemp, 19] = lineOtpusk;
                    xTemp++;
                }
            }
            
            else
            {
                foreach (var item in listPeoples)
                {
                    foreach (var i in item._Otpusk)
                        lineOtpusk += i + "\t";

                    sumScore = 50 * 12 - (item._Jan + item._Feb + item._Mar + item._Apr +
                        item._May + item._June + item._July + item._Aug +
                        item._Sep + item._Okt + item._Nov + item._Dec);

                    sheet.Cells[xTemp, 2] = item._Name;
                    sheet.Cells[xTemp, 3] = item._Job;
                    sheet.Cells[xTemp, 4] = item._Oklad;
                    sheet.Cells[xTemp, 5].Value = string.Format("{0:F2}", 50 - item._Jan);
                    sheet.Cells[xTemp, 6].Value = string.Format("{0:F2}", 50 - item._Feb);
                    sheet.Cells[xTemp, 7].Value = string.Format("{0:F2}", 50 - item._Mar);
                    sheet.Cells[xTemp, 8].Value = string.Format("{0:F2}", 50 - item._Apr);
                    sheet.Cells[xTemp, 9].Value = string.Format("{0:F2}", 50 - item._May);
                    sheet.Cells[xTemp, 10].Value = string.Format("{0:F2}", 50 - item._June);
                    sheet.Cells[xTemp, 11].Value = string.Format("{0:F2}", 50 - item._July);
                    sheet.Cells[xTemp, 12].Value = string.Format("{0:F2}", 50 - item._Aug);
                    sheet.Cells[xTemp, 13].Value = string.Format("{0:F2}", 50 - item._Sep);
                    sheet.Cells[xTemp, 14].Value = string.Format("{0:F2}", 50 - item._Okt);
                    sheet.Cells[xTemp, 15].Value = string.Format("{0:F2}", 50 - item._Nov);
                    sheet.Cells[xTemp, 16].Value = string.Format("{0:F2}", 50 - item._Dec);
                    sheet.Cells[xTemp, 17] = string.Format("{0:F2}", sumScore);
                    sheet.Cells[xTemp, 19] = lineOtpusk;
                    xTemp++;
                }
            }
            
            
            if(count> 0)
            {
                Excel.Range bodyRange = sheet.get_Range("A3", $"S{count + 2}");
                Excel.Range subBodyRange = sheet.get_Range("C3", $"C{count + 2}");
                Excel.Range descriptionRange = sheet.get_Range("S3", $"S{count + 2}");
                bodyRange.Font.Size = 11;
                subBodyRange.Font.Size = 10;
                descriptionRange.Font.Size = 10;
                bodyRange.Font.Name = "Times New Roman";
                bodyRange.WrapText = true;
                bodyRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                bodyRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                headRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                headRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
                bodyRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                bodyRange.Borders.Weight = Excel.XlBorderWeight.xlThin;
            } 


        }
    }
   
}
