using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CAD2EXCEL
{
    class ExcelExporter
    {
        public static void ExportToExcel(DataGridView dataGridView, List<string> Locationcell )
        {
            try
            {
                if (Locationcell.Count != 13 )
                {
                    MessageBox.Show("vui lòng Cài đặt các thông số trong tab setting để xuất file excel ");

                }
                else
                {
                    
                    using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(Locationcell[0])))
                    {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                        // Ghi dữ liệu từ DataGridView vào Excel
                     
                          for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                          {
                            var cellRange = worksheet.Cells["A"+ (int.Parse(Locationcell[2])+i).ToString() + ":"+ "AW" + (int.Parse(Locationcell[2]) + i).ToString()];
                            
                            worksheet.InsertRow(int.Parse((Locationcell[2])) + i + 1, 1);
                            ExcelRow newRow = worksheet.Row(int.Parse((Locationcell[2])) + i + 1);
                            newRow.Height = 30;
                            // copy to destination A10:L10
                            var destination = worksheet.Cells["A" + (int.Parse(Locationcell[2]) +1+ i).ToString() + ":" + "AW" + (int.Parse(Locationcell[2]) +1+ i).ToString()];
                            cellRange.Copy(destination);
                          //  MessageBox.Show("A" + (Locationcell[2] + i) + ":" + "AW" + (Locationcell[2] + i));
                            for (int j = 0; j < 10; j++)
                            {
                                if ((string)dataGridView.Rows[i].Cells[j].Value == "-")
                                {
                                    worksheet.Cells[i + int.Parse(Locationcell[2]), ExcelColumnConverter.GetExcelColumnNumber(Locationcell[j + 3])].Value = "";
                                }
                                else
                                {
                                    worksheet.Cells[i + int.Parse(Locationcell[2]), ExcelColumnConverter.GetExcelColumnNumber(Locationcell[j + 3])].Value = dataGridView.Rows[i].Cells[j].Value;
                                }
                            }
                          }
                     
                        // Lưu file Excel
                        DateTime now = DateTime.Now;
                        string dateTimeString = now.ToString("yyyy MM dd HH mm ss").Replace(" ", "");
                         
                             string filePath = Path.Combine(Locationcell[1], dateTimeString+ ".xlsx");                                                                         // Lưu file Excel
                        excelPackage.SaveAs(filePath);
                    }

                    MessageBox.Show("Xuất file Excel thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message);
            }
        }
    }
    public class ExcelColumnConverter
    {
        public static int GetExcelColumnNumber(string columnLetter)
        {
            ExcelCellAddress cellAddress = new ExcelCellAddress(columnLetter + "1");
            return cellAddress.Column;
        }

        
    }
}
