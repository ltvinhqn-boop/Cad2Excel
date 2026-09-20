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


using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using AcAp = Autodesk.AutoCAD.ApplicationServices.Application;
using OfficeOpenXml;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;


namespace CAD2EXCEL
{
    public partial class Form_export : Form
    {
        public List<REF> listref = new List<REF>();
        public List<BlockReference> listParts = new List<BlockReference>();
        IntPtr acadHwnd = new IntPtr(AcAp.MainWindow.Handle.ToInt64());
        public Form_export()
        {
            InitializeComponent();
        }
        internal static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern bool SetForegroundWindow(IntPtr hWnd);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Lấy liên kết từ sự kiện LinkClicked
            LinkLabel linkLabel = (LinkLabel)sender;
            string link = linkLabel.Text;

            // Mở trình duyệt web với liên kết đó
            Process.Start(link);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Title = "Chọn file Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_input.Text = openFileDialog.FileName;

            }
        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Chọn thư mục xuất file Excel";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tb_outputex.Text = folderBrowserDialog.SelectedPath;

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }


        static List<string> aa = new List<string> { "Đường dẫn input", "Đường dẫn output","Hàng bắt đầu", "STT", "Name", "Mat'L", "Q'ty", "Length", "Width", "Thick", "Od", "Id", "Remask" };
        static void SaveTextBoxValuesToFile(string filePath, TextBox[] textBoxes)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    int i = 0;
                    foreach (TextBox textBox in textBoxes)
                    {
                        if (textBox.Text == "")
                        {
                            MessageBox.Show("Nhập giá trị vào ô " + aa[i]);

                            continue; // Thoát khỏi phương thức ngay lập tức

                        }

                        string value = textBox.Text;
                        writer.WriteLine(value);
                        i++;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }


        }

        private void vbButton3_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show("Nhập vào rồi ");
            // Đường dẫn đến tệp tin txt để lưu giá trị từ TextBox
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\inout.txt";

            // Tạo một mảng chứa các TextBox cần lưu giá trị
            TextBox[] textBoxes = { tb_input, tb_outputex, tb_11, tb_1, tb_2, tb_3, tb_4, tb_5, tb_6, tb_7, tb_8, tb_9, tb_10 }; 

            // Gọi phương thức lưu giá trị từ TextBox vào tệp tin
            SaveTextBoxValuesToFile(filePath, textBoxes);
        }
        static List<string> ReadLinesFromFile(string filePath)
        {
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
        private void Form_export_Load(object sender, EventArgs e)
        {
          /*  List<string> srhard = Serialnumber.GetHardDriveSerialNumber();
            if (Serialnumber.GetBiosSerialNumber() != "FKMKTN3" && !srhard.Contains("WD-WCC6Y3UJF8AS") && !srhard.Contains("S64B_NJ0T_2264_85H"))
            {
                btn_ex.Enabled = false;
                btn_sel.Enabled = false;
                vbButton1.Enabled = false;
                vbButton2.Enabled = false;
                vbButton3.Enabled = false;

                MessageBox.Show("Bạn đã cài trên máy không phải của Hòa PTSP\n" + "Liên hệ Hòa PTSP Vippro để biết thêm thông tin");
            }*/
         /*   double timecheck = 20240126;
            if (!CHECKTIME.CHECKLICENSE(timecheck))
            {
                btn_ex.Enabled = false;
                btn_sel.Enabled = false;
                vbButton1.Enabled = false;
                vbButton2.Enabled = false;
                vbButton3.Enabled = false;
                MessageBox.Show("Giấy phép đã hết hạn");
                 
            }
            else if (CHECKTIME.date(timecheck) < 3 && CHECKTIME.date(timecheck) > 0)
            { MessageBox.Show("Bạn còn " + CHECKTIME.date(timecheck) + " ngày hạn sử dụng Plugin Cad2excel"); }*/
            //-----------------------------------------------------------------------------------------------------------------

            TextBox[] textBoxes1 = { tb_input, tb_outputex, tb_11, tb_1, tb_2, tb_3, tb_4, tb_5, tb_6, tb_7, tb_8, tb_9, tb_10 };
            List<string> lists = new List<string>();
            lists.AddRange(ReadLinesFromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\inout.txt").ToArray());
            int i = 0;
            foreach (string li in lists)
            {
                textBoxes1[i].Text = li;
                i++;
            }

        }
        //-----------------------------------------------------------------------------------------------------------
       

        private void btn_sel_Click(object sender, EventArgs e)
        {
            NativeMethods.SetForegroundWindow(acadHwnd);
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            listParts = SortBlockReferences(doc,db,ed);
           foreach (BlockReference list in listParts)
            {                 
                    REF p1 = new REF(list);
                 listref.Add(p1);
            }
                
                for (int i = 0; i < listref.Count; i++)
                {
                    var index = this.dataGridView1.Rows.Add(listref[i].stt, listref[i].ten, listref[i].maso, listref[i].quycach, listref[i].vatlieu, listref[i].mauson, listref[i].donvi, listref[i].slbo, listref[i].sldh, listref[i].ghichu);
                }
            
        }

        //------------------------------------------------------------------------------------------------------------
        public static List<AttributeReference> ExportAttributesToExcel()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            List<string> listref = new List<string>();
            List<BlockReference> blockRefs = SortBlockReferences(doc,db,ed);
            // List<BlockReference> blockRefs = new List<BlockReference>();
            List<AttributeDefinition> attributeDefs = new List<AttributeDefinition>();
            List<AttributeReference> attributeRefs = new List<AttributeReference>();
            // Lấy danh sách các đối tượng Block Reference và danh sách các Attribute Definition

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
               

                // Kiểm tra nếu có các Attribute Definition





                //  attributeRefs.Add(attributeRef);

                tr.Commit();

            }
            return attributeRefs;

        }
      
        //---------------------------------------------

        public static List<BlockReference> SortBlockReferences(Document doc, Database db, Editor editor)
        {
            //Document doc = AcAp.DocumentManager.MdiActiveDocument;
            //Database db = doc.Database;
            //Editor editor = doc.Editor;
            using (DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                List<BlockReference> sortedBlockReferences = new List<BlockReference>();
                PromptSelectionOptions pso = new PromptSelectionOptions();
                pso.MessageForAdding = "\nChọn block reference: ";

                pso.SingleOnly = false;
                pso.SinglePickInSpace = false;
                pso.AllowDuplicates = false;
                PromptSelectionResult selectionResult = editor.GetSelection(pso);
                if (selectionResult.Status == PromptStatus.OK)
                {
                    using (Transaction tr = db.TransactionManager.StartTransaction())
                    {
                        BlockTable blockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                        BlockTableRecord modelSpace = tr.GetObject(blockTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        SelectionSet selectionSet = selectionResult.Value;

                        // Tạo danh sách các Block Reference từ SelectionSet
                        List<BlockReference> blockReferences = new List<BlockReference>();
                        foreach (SelectedObject selectedObject in selectionSet)
                        {
                            if (selectedObject.ObjectId.ObjectClass.DxfName.Equals("INSERT"))
                            {
                                BlockReference blockReference = tr.GetObject(selectedObject.ObjectId, OpenMode.ForRead) as BlockReference;
                                if (blockReference.Name.Equals("THONGKE")) // Chỉ chọn BlockReference có tên THONGKE
                                {
                                    blockReferences.Add(blockReference);
                                }
                            }
                        }

                        // Sắp xếp các Block Reference theo quy luật
                        blockReferences.Sort(new BlockReferenceComparer());

                        // Thêm các Block Reference đã sắp xếp vào danh sách
                        sortedBlockReferences.AddRange(blockReferences);

                        tr.Commit();
                    }
                }

                return sortedBlockReferences;
            }
        }

        private void tb_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void tb_10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lb_sumrow.Text = (dataGridView1.RowCount-1).ToString();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lb_sumrow.Text = (dataGridView1.RowCount - 1).ToString();
        }

        private void tb_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu không phải là chữ cái hoặc số, hủy sự kiện nhập vào
                e.Handled = true;
            }
        }

        private void btn_ex_Click(object sender, EventArgs e)
        {
            NativeMethods.SetForegroundWindow(acadHwnd);
            List<string> listlocation = new List<string>();
              TextBox[] textBoxes1 = { tb_input, tb_outputex, tb_11, tb_1, tb_2, tb_3, tb_4, tb_5, tb_6, tb_7, tb_8, tb_9, tb_10 };
            foreach(TextBox textbox in textBoxes1)
            {
                listlocation.Add(textbox.Text);
            }
            ExcelExporter.ExportToExcel(dataGridView1, listlocation);

        }

        private void vbButton4_Click(object sender, EventArgs e)
        {
          /*  List<int> ss = new List<int> {1,2,7,9,11,13,15,17,19,21,23,25,26,29,28,31,32,34,35,37,38,40,41,43,44,46,47,49,50,53,54,55,57 };

                using (StreamWriter writer = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Name.txt", true))
            {
                for (int i = 1; i < 58; i++)
                {
                    bool isInList = ss.Contains(i);
                    if (!isInList)
                    {
                        string value = tb_input.Text + i;
                        writer.WriteLine(value);
                    }
                }
                // Ghi các giá trị khác hoặc thực hiện các thao tác bổ sung ở đây
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //------------------------------------------------------------------------------------------------------------------------
    }
    public class REF
    {
        public string stt { get; set; }
        public string  ten { get; set; }
        public string maso { get; set; }
        public string quycach { get; set; }
        public string vatlieu { get; set; }
        public string mauson { get; set; }
        public string donvi { get; set; }
        public string slbo { get; set; }
        public string sldh { get; set; }
        public string ghichu { get; set; }

        private static AttributeReference GetAttributeReference(BlockReference blockRef, AttributeDefinition attributeDef)
        {
            foreach (ObjectId attributeId in blockRef.AttributeCollection)
            {
                AttributeReference attributeRef = attributeId.GetObject(OpenMode.ForRead) as AttributeReference;
                if (attributeRef != null && attributeRef.Tag == attributeDef.Tag)
                {
                    return attributeRef;
                }
            }

            return null;
        }

        public REF(BlockReference blockRef)

        {
            Document doc = AcAp.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor editor = doc.Editor;
            using (DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {

                    
                   
                        int i = 1;

                        BlockTableRecord blockTableRecord = tr.GetObject(blockRef.BlockTableRecord, OpenMode.ForRead) as BlockTableRecord;
                        foreach (ObjectId objectId in blockTableRecord)
                        {
                            if (!objectId.IsValid || objectId.IsErased)
                                continue;

                            DBObject dbObject = tr.GetObject(objectId, OpenMode.ForRead);
                            if (dbObject is AttributeDefinition)
                            {
                                // attributeDefs.Add();
                                AttributeReference attributeRef = GetAttributeReference(blockRef, (AttributeDefinition)dbObject);
                                if (attributeRef != null)
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            this.stt = attributeRef.TextString;
                                            break;
                                        case 2:
                                            this.ten = attributeRef.TextString;
                                            break;
                                        case 3:
                                            this.maso = attributeRef.TextString;
                                            break;
                                        case 4:
                                            this.quycach = attributeRef.TextString;
                                            break;
                                        case 5:
                                        this.vatlieu = attributeRef.TextString;

                                        break;
                                        case 6:
                                            this.mauson = attributeRef.TextString;
                                            break;
                                    case 7:
                                        this.donvi = attributeRef.TextString;
                                        break;
                                    case 8:
                                        this.slbo = attributeRef.TextString;
                                        break;
                                    case 9:
                                        this.sldh = attributeRef.TextString;

                                        break;
                                    case 10:
                                        this.ghichu = attributeRef.TextString;
                                        break;
                                    default:
                                            // Xử lý khi giá trị không trùng với bất kỳ case nào
                                            break;
                                    }


                                }
                                i++;
                            }
                        }


                    tr.Commit();
                }
            }
      

        }
       
    }
    //---------------------------------------------------------------------------------------------------------------
    
    //---------------------------------------------------------------------------------------------------------------
}

