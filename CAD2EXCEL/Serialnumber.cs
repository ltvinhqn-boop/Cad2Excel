using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Management;
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
    class Serialnumber
    {



        public static string GetBiosSerialNumber()
        {
            string biosSerialNumber = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
                ManagementObjectCollection objectCollection = searcher.Get();
                foreach (ManagementObject obj in objectCollection)
                {
                    biosSerialNumber = obj["SerialNumber"].ToString();
                    break; // Lấy thông tin số seri BIOS đầu tiên tìm thấy
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy số seri BIOS: " + ex.Message);
            }

            return biosSerialNumber;
        }

        public static List<string> GetHardDriveSerialNumber()
        {
            List<string> hardDriveSerialNumber = new List<string>();
            string sr = string.Empty;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia");
                ManagementObjectCollection objectCollection = searcher.Get();
                foreach (ManagementObject obj in objectCollection)
                {
                    sr = obj["SerialNumber"].ToString();
                    hardDriveSerialNumber.Add(sr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy số seri ổ cứng: " + ex.Message);
            }

            return hardDriveSerialNumber;
        }

     
    }
}
