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
using System.Threading;

using acadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using acadWin = Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;


namespace CAD2EXCEL
{
    public partial class Form_pl : Form
    {
        public DataGridViewCell currentCellenter;
        public bool coenter=false;
        //  public ObjectId Oid { get; set; }
        public Document acDoc;
     
        IntPtr acadHwnd = new IntPtr(acadApp.MainWindow.Handle.ToInt64());
        // public Document acDoc;
        //  List<RawMatl> lsitNCformats = new List<RawMatl>();
        public Form_pl()
        {
            InitializeComponent();
            timer1.Enabled = true;
            //this.Size = new Size(528, 393);
        }


        internal static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern bool SetForegroundWindow(IntPtr hWnd);
        }




    

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            // Lấy số hàng và số cột từ DataGridView
            int rowCount = dtb_gr1.Rows.Count;
            int columnCount = dtb_gr1.Columns.Count;

            // Tạo mảng 2 chiều
            string[,] data = new string[rowCount, columnCount];

            // Lặp qua từng hàng và cột để lấy dữ liệu từ DataGridView
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    // Lấy giá trị từ DataGridView và gán vào mảng 2 chiều
                    data[row, col] = dtb_gr1.Rows[row].Cells[col].Value.ToString();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(cb_addmaster.Checked==true)
            {
                if(cb_crno.Checked==true)
                {
                    for(int j=1; j < dtb_gr1.RowCount; j++)
                    {
                       
                        if (comboBoxno.SelectedIndex == 1 && dtb_gr1.Rows[0].Cells[0].Value!=null)
                        {
                            dtb_gr1.Rows[j].Cells[0].Value = dtb_gr1.Rows[0].Cells[0].Value.ToString() + (nm_no.Value - 1 + j);
                        }
                        else
                        {
                            dtb_gr1.Rows[j].Cells[0].Value = comboBoxno.Text.Replace("None", "").Replace("Master+???","") + (nm_no.Value - 1 + j);
                        }
                    }
                }
                //-----------------------------------------------------------------------
                if (cb_crname.Checked == true)
                {
                    for (int j = 1; j < dtb_gr1.RowCount; j++)
                    {
                        if (comboBoxname.SelectedIndex == 1&& dtb_gr1.Rows[0].Cells[1].Value!= null)
                        {
                            
                            dtb_gr1.Rows[j].Cells[1].Value = dtb_gr1.Rows[0].Cells[1].Value.ToString() + "-" + (nm_name.Value - 1 + j);
                        }
                        else
                        {
                            dtb_gr1.Rows[j].Cells[1].Value = comboBoxname.Text.Replace("None", "").Replace("Master+???", "") + (nm_name.Value - 1 + j);
                        }
                    }
                }

            }
            else
            {
                if (cb_crno.Checked == true)
                {
                    for (int j = 0; j < dtb_gr1.RowCount; j++)
                    {
                        dtb_gr1.Rows[j].Cells[0].Value = comboBoxno.Text.Replace("None", "").Replace("Master+???", "") + (nm_no.Value  + j);
                    }
                }
                //------------------------------------------------------------------------------------------
                if (cb_crname.Checked == true)
                {
                    for (int j = 0; j < dtb_gr1.RowCount; j++)
                    {
                        
                            dtb_gr1.Rows[j].Cells[1].Value = comboBoxname.Text.Replace("None", "").Replace("Master+???", "") + (nm_name.Value  + j);
                       
                    }
                }

            }
            if (!string.IsNullOrEmpty(tb_sl.Text))
            { double x;
                try
                {
                    for (int j = 0; j < dtb_gr1.RowCount; j++)
                {
                    if (dtb_gr1.Rows[j].Cells[7].Value!=null&& double.TryParse(dtb_gr1.Rows[j].Cells[7].Value.ToString(),out x))
                    {
                       
                            dtb_gr1.Rows[j].Cells[8].Value =x* double.Parse(tb_sl.Text);
                       
                    }
                    }
                }
                catch { MessageBox.Show("Nhập sai định dạng ô số lượng"); }
            }
          
            if (cb_msten.Checked==true)
            {
                for (int j = 0; j < dtb_gr1.RowCount; j++)
                {
                    dtb_gr1.Rows[j].Cells[2].Value = dtb_gr1.Rows[j].Cells[1].Value;
                }
            }

            st_1.Text = "Row "+ (dtb_gr1.RowCount - 1);
        }

        private void Form_pl_Load(object sender, EventArgs e)
        {
            /*List<string> srhard = Serialnumber.GetHardDriveSerialNumber();
            if (Serialnumber.GetBiosSerialNumber()!= "FKMKTN3"&& !srhard.Contains("WD-WCC6Y3UJF8AS")&& !srhard.Contains("S64B_NJ0T_2264_85H"))
            {
                vbButton1.Enabled = false;
                dtb_gr1.Enabled = false;

                MessageBox.Show("Bạn đã cài trên máy không phải của Hòa PTSP\n" +"Liên hệ Hòa PTSP Vippro để biết thêm thông tin\n"+ srhard[0]);
            }*/
            /*double timecheck = 20240126;
            if (!CHECKTIME.CHECKLICENSE(timecheck))
            {
               
                vbButton1.Enabled = false;
               
                MessageBox.Show("Giấy phép đã hết hạn");

            }
            else if(CHECKTIME.date(timecheck)<3&& CHECKTIME.date(timecheck) >0)
            { MessageBox.Show("Bạn còn " + CHECKTIME.date(20240125)+ " ngày hạn sử dụng Plugin Cad2excel"); }*/
            //----------------------------------------------------------------------------------------------------------------------------
            this.StartPosition = FormStartPosition.Manual; // Đặt vị trí Form ở giữa màn hình
                                                                 
            //nm_row.Enabled = false;      
            if (cb_addmaster.Checked==true)
            {
                
               
                DataGridViewRow newRow = new DataGridViewRow();
                dtb_gr1.Rows.Add(newRow);
                dtb_gr1.Rows[0].Cells[0].Value = "A";
            }
            dtb_gr1.Rows[0].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
            comboBoxname.SelectedIndex = 1;
            comboBoxno.SelectedIndex = 0;
        }

        private void cb_addmaster_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_addmaster.Checked==false&&dtb_gr1.RowCount>1)
            {
                dtb_gr1.Rows.RemoveAt(0);
                return;
            }
            // Tạo một hàng mới
            DataGridViewRow newRow = new DataGridViewRow();

            // Xác định chỉ số của hàng mới (ví dụ: hàng đầu tiên)
            int rowIndex = 0;

            
                // Chèn hàng mới vào vị trí hàng đầu tiên
                dtb_gr1.Rows.Insert(rowIndex, newRow);
                dtb_gr1.Rows[0].Cells[0].Value = "A";
            dtb_gr1.Rows[0].DefaultCellStyle.BackColor = Color.PaleGoldenrod; // Thiết lập màu nền cho hàng đầu tiên
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
        public AutoCompleteStringCollection AutoCompleteLoad(string[] path)
        {
            AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
            mycoll.AddRange(path);
            return mycoll;
        }

        private void dtb_gr1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
            int column = dtb_gr1.CurrentCell.ColumnIndex;
            string headerText = dtb_gr1.Columns[column].HeaderText;

            if (headerText.Equals("Vật liệu"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = AutoCompleteLoad(ReadLinesFromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Material.txt").ToArray());
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (headerText.Equals("Ghi chú"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = AutoCompleteLoad(ReadLinesFromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\chuthich.txt").ToArray());
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            } else if (headerText.Equals("Tên"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = AutoCompleteLoad(ReadLinesFromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Name.txt").ToArray());
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (headerText.Equals("Màu sơn"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = AutoCompleteLoad(ReadLinesFromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\mauson.txt").ToArray());
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (headerText.Equals("Đơn vị"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = AutoCompleteLoad(ReadLinesFromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\donvi.txt").ToArray());
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (headerText.Equals("Quy cách"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteCustomSource = AutoCompleteLoad(ReadLinesFromFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\quycach.txt").ToArray());
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }

            else
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.None;
                }
            }
        
    }
        //-------------------------------------------------------------------------------------------------------------------------
    
        //-------------------------------------------------------------------------------------------------------------------------
        private static void InsertBlock(string blockPath, string blockName, Point3d pointResult, List<string> valuetable, double scale)
        {
            var doc = acadApp.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;
          //  PromptPointResult pointResult = ed.GetPoint("Chọn vị trí để chèn Block Reference: ");
            using (DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument())
            {
                using (var tr = db.TransactionManager.StartTransaction())
                {
                    var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                    ObjectId btrId = bt.Has(blockName) ?
                        bt[blockName] :
                        ImportBlock(db, blockName, blockPath);
                    if (btrId.IsNull)
                    {
                        ed.WriteMessage($"\nBlock '{blockName}' not found.");
                        return;
                    }
                    // btrId.
                    var cSpace = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                    var br = new BlockReference(pointResult, btrId);
                    br.ScaleFactors = new Scale3d(scale, scale, scale);
                    cSpace.AppendEntity(br);
                    tr.AddNewlyCreatedDBObject(br, true);

                    // add attribute references to the block reference
                    var btr = (BlockTableRecord)tr.GetObject(btrId, OpenMode.ForRead);
                    var attInfos = new Dictionary<string, TextInfo>();
                    if (btr.HasAttributeDefinitions)
                    {
                        int i = 0;
                       
                        foreach (ObjectId id in btr)
                        {
                            if (id.ObjectClass.DxfName == "ATTDEF")
                            {
                                var attDef = (AttributeDefinition)tr.GetObject(id, OpenMode.ForRead);
                                attInfos[attDef.Tag] = new TextInfo(
                                    attDef.Position,
                                    attDef.AlignmentPoint,
                                    attDef.Justify != AttachmentPoint.BaseLeft,
                                    attDef.Rotation);
                                var attRef = new AttributeReference();
                              //  MessageBox.Show(valuetable.Count.ToString());
                                attRef.SetAttributeFromBlock(attDef, br.BlockTransform);
                                if (i < 12)
                                { attRef.TextString = valuetable[i]; }
                                //else
                                //{ attRef.TextString = "-"; }

                                if(i==2||i==3||i==5|| i == 6 || i == 8 || i == 9)
                                {
                                    attRef.Visible = false;
                                }
                              
                                br.AttributeCollection.AppendAttribute(attRef);
                                tr.AddNewlyCreatedDBObject(attRef, true);
                              ed.WriteMessage("\n" + attDef.Tag + "-" + attDef.Position + attDef.TextString);
                                i++;

                            }
                        }
                    }
              
                    tr.Commit();
                }
            }
        }

        private static ObjectId ImportBlock(Database destDb, string blockName, string sourceFileName)
        {
            if (System.IO.File.Exists(sourceFileName))
            {
                using (var sourceDb = new Database(false, true))
                {
                    try
                    {
                        // Read the DWG into a side database
                        sourceDb.ReadDwgFile(sourceFileName, FileOpenMode.OpenForReadAndAllShare, true, "");

                        // Create a variable to store the block identifier
                        var id = ObjectId.Null;
                        using (var tr = new OpenCloseTransaction())
                        {
                            // Open the block table
                            var bt = (BlockTable)tr.GetObject(sourceDb.BlockTableId, OpenMode.ForRead, false);

                            // if the block table contains 'blockName', store it into the variable
                            if (bt.Has(blockName))
                                id = bt[blockName];
                        }
                        // if the variable is not null (i.e. the block was found)
                        if (!id.IsNull)
                        {
                            // Copy the block deinition from source to destination database
                            var blockIds = new ObjectIdCollection();
                            blockIds.Add(id);
                            var mapping = new IdMapping();
                            sourceDb.WblockCloneObjects(blockIds, destDb.BlockTableId, mapping, DuplicateRecordCloning.Replace, false);
                            // if the copy succeeded, return the ObjectId of the clone
                            if (mapping[id].IsCloned)
                                return mapping[id].Value;
                        }
                    }
                    catch (Autodesk.AutoCAD.Runtime.Exception ex)
                    {
                        var ed = acadApp.DocumentManager.MdiActiveDocument.Editor;
                        ed.WriteMessage("\nError during copy: " + ex.Message + "\n" + ex.StackTrace);
                    }
                }
            }
            return ObjectId.Null;
        }

        struct TextInfo
        {
            public Point3d Position { get; private set; }
            public Point3d Alignment { get; private set; }
            public bool IsAligned { get; private set; }
            public double Rotation { get; private set; }
            public TextInfo(Point3d position, Point3d alignment, bool aligned, double rotation)
            {
                Position = position;
                Alignment = alignment;
                IsAligned = aligned;
                Rotation = rotation;
            }
        }
        public static List<string>[] CreateArrayFromDataGridView(DataGridView dataGridView)
        {
            List<string>[] array = new List<string>[dataGridView.Rows.Count];

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                array[i] = new List<string>();

                string value1 = dataGridView.Rows[i].Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(value1))
                {
                    array[i].Add(value1);
                }
                else
                {
                    array[i].Add("-");
                }

                string value2 = dataGridView.Rows[i].Cells[1].Value?.ToString();
                if (!string.IsNullOrEmpty(value2))
                {
                    array[i].Add(value2);
                }
                else
                {
                    array[i].Add("-");
                }

                string value3 = dataGridView.Rows[i].Cells[2].Value?.ToString();
                if (!string.IsNullOrEmpty(value3))
                {
                    array[i].Add(value3);
                }
                else
                {
                    array[i].Add("-");
                }

                string value4 = dataGridView.Rows[i].Cells[3].Value?.ToString();
                if (!string.IsNullOrEmpty(value4))
                {
                    array[i].Add(value4);
                }
                else
                {
                    array[i].Add("-");
                }

                string value5 = dataGridView.Rows[i].Cells[4].Value?.ToString();
                if (!string.IsNullOrEmpty(value5))
                {
                    array[i].Add(value5);
                }
                else
                {
                    array[i].Add("-");
                }
                string value6 = dataGridView.Rows[i].Cells[5].Value?.ToString();
                if (!string.IsNullOrEmpty(value6))
                {
                    array[i].Add(value6);
                }
                else
                {
                    array[i].Add("-");
                }
                string value7 = dataGridView.Rows[i].Cells[6].Value?.ToString();
                if (!string.IsNullOrEmpty(value7))
                {
                    array[i].Add(value7);
                }
                else
                {
                    array[i].Add("-");
                }
                string value8 = dataGridView.Rows[i].Cells[7].Value?.ToString();
                if (!string.IsNullOrEmpty(value8))
                {
                    array[i].Add(value8);
                }
                else
                {
                    array[i].Add("-");
                }
                string value9 = dataGridView.Rows[i].Cells[8].Value?.ToString();
                if (!string.IsNullOrEmpty(value9))
                {
                    array[i].Add(value9);
                }
                else
                {
                    array[i].Add("-");
                }


                string value10 = dataGridView.Rows[i].Cells[9].Value?.ToString();
                if (!string.IsNullOrEmpty(value10))
                {
                    array[i].Add(value10);
                }
                else
                {
                    array[i].Add("-");
                }
              //  string value11 = dataGridView.Rows[i].Cells[3].Value?.ToString();
                if (!string.IsNullOrEmpty(value4))
                {
                    array[i].Add(value4);
                }
                else
                {
                    array[i].Add("-");
                }


              //  string value12 = dataGridView.Rows[i].Cells[9].Value?.ToString();
                if (!string.IsNullOrEmpty(value10))
                {
                    array[i].Add(value10);
                }
                else
                {
                    array[i].Add("-");
                }


            }

            return array;
        }
        private void vbButton1_Click_1(object sender, EventArgs e)
        {
                  NativeMethods.SetForegroundWindow(acadHwnd);
            var doc = acadApp.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;
            // int PP = dtb_gr1.RowCount;
            int p=1;
            //  dtb_gr1.Rows.RemoveAt(PP-1);
            PromptPointResult pointResult = ed.GetPoint("Chọn vị trí để chèn Block Reference: ");
            double x = pointResult.Value.X;
            double y = pointResult.Value.Y;

            double dDimScale = (double)Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("DIMSCALE");
            List<string>[] array = CreateArrayFromDataGridView(dtb_gr1);
            for (int j = 3; j < 10; j++)
            {
                if (array[array.Length-1][j]!="-")
                {
                    p = 0;
                }
            }
            for (int i = 0; i < dtb_gr1.RowCount - p; i++)
            {
                InsertBlock(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\THONGKE.dwg", "THONGKE", new Point3d(x, y + i * 5.5 * dDimScale, 0), array[i], dDimScale);

            }
        }



        private void dtb_gr1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
              
                DataGridViewCell currentCell = dtb_gr1.CurrentCell;
                DataGridViewCell nextCell = dtb_gr1.CurrentCell;
                int currentRowIndex = currentCell.RowIndex;
                int currentColumnIndex = currentCell.ColumnIndex;

                if (currentRowIndex < dtb_gr1.Rows.Count - 1)
                {
                    if (cb_crname.Checked && cb_crno.Checked)
                    {
                        if (cb_msten.Checked == true)
                        {
                            nextCell = dtb_gr1.Rows[currentRowIndex + 1].Cells[3];
                        }
                    else
                        { nextCell = dtb_gr1.Rows[currentRowIndex + 1].Cells[2]; }
                    }
                    else if(cb_crno.Checked)
                    {
                         nextCell = dtb_gr1.Rows[currentRowIndex + 1].Cells[1];
                    }
                    else
                    {
                         nextCell = dtb_gr1.Rows[currentRowIndex + 1].Cells[0];
                    }

                    dtb_gr1.CurrentCell = nextCell;
                  
                }



            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');

                int row = dtb_gr1.CurrentCell.RowIndex;
                int col = dtb_gr1.CurrentCell.ColumnIndex;

                foreach (string line in lines)
                {
                    if (line.Length == 0) continue;
                    string[] cells = line.Split('\t');
                    int tempCol = col;
                    foreach (string cell in cells)
                    {
                        if (row < dtb_gr1.RowCount && tempCol < dtb_gr1.ColumnCount)
                        {
                            dtb_gr1[tempCol, row].Value = cell;
                        }
                        tempCol++;
                    }
                    row++;
                }
            }

        }


        private void dtb_gr1_KeyUp(object sender, KeyEventArgs e)
        {
            DataGridViewCell currentCell = dtb_gr1.CurrentCell;
            DataGridViewCell nextCell = dtb_gr1.CurrentCell;
            if (e.KeyCode == Keys.Enter)
            {

                e.Handled = true;
                e.SuppressKeyPress = true;

               
               
                int currentRowIndex = currentCell.RowIndex;
                int currentColumnIndex = currentCell.ColumnIndex;

               
                    if (cb_crname.Checked && cb_crno.Checked)
                    {
                         if (cb_msten.Checked == true)
                        {
                        nextCell = dtb_gr1.Rows[currentRowIndex ].Cells[3];
                        }
                         else
                             { nextCell = dtb_gr1.Rows[currentRowIndex ].Cells[2]; }
                     }
                    else if (cb_crno.Checked)
                    {
                        nextCell = dtb_gr1.Rows[currentRowIndex ].Cells[1];
                    }
                    else
                    {
                        nextCell = dtb_gr1.Rows[currentRowIndex ].Cells[0];
                    }

                    dtb_gr1.CurrentCell = nextCell;

                
            }
        }

        private void dtb_gr1_SelectionChanged(object sender, EventArgs e)
        {
           /* object a = "";
          //  object firstCellValue = dtb_gr1.SelectedCells[0].Value;
            int i = 0;
            // Gán giá trị của ô đầu tiên cho tất cả các ô đã chọn
            foreach (DataGridViewCell cell in dtb_gr1.SelectedCells)
            { if (i != 0)
                {
                   a = cell.Value;
                }
                cell.Value = a;
                i++;
            }*/
        }

        private void dtb_gr1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //object a = "";
            object firstCellValue = dtb_gr1.SelectedCells[dtb_gr1.SelectedCells.Count - 1].Value;
            //  int i = 0;
            // Gán giá trị của ô đầu tiên cho tất cả các ô đã chọn
            foreach (DataGridViewCell cell in dtb_gr1.SelectedCells)
            {
                cell.Value = firstCellValue;
            }
        }

        private void dtb_gr1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }

        private void tb_sl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho ký tự không phải số được nhập vào TextBox
            }
        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            List<BlockReference> listbl = new List<BlockReference>();
            List<REF> listref2 = new List<REF>();
            int i = 0;

            //Lấy đối tượng Document hiện tại
            var doc = acadApp.DocumentManager.MdiActiveDocument;
            //Lấy đối tượng Database hiện tại
            var db = doc.Database;
            //Lấy đối tượng Editor hiện tại
            var ed = doc.Editor;

            if (CHECKTIME.CHECKLICENSE(20300125))
            {

                listbl = Form_export.SortBlockReferences(doc,db,ed);

                if (listbl.Any())
                {
                    foreach (BlockReference list in listbl)
                    {
                        REF p1 = new REF(list);
                        listref2.Add(p1);
                    }


                    //Tạo một bộ lọc để chỉ chọn các đối tượng có mã DXF là 0 và giá trị là MTEXT
                    do
                    {
                        var filter = new SelectionFilter(new TypedValue[]
                        {
                        new TypedValue((int)DxfCode.Start, "MTEXT")
                        });
                        //Sử dụng hàm GetSelection để chọn các đối tượng thỏa mãn bộ lọc
                        var result = ed.GetSelection(filter);
                        //Kiểm tra xem kết quả có thành công hay không
                        if (result.Status == PromptStatus.OK)
                        {
                            //Lấy tập hợp các đối tượng đã chọn
                            var ss = result.Value;

                            using (Transaction tr = db.TransactionManager.StartTransaction())
                            {


                                MText mtext = tr.GetObject(ss[0].ObjectId, OpenMode.ForWrite) as MText;
                                if (mtext != null)
                                {

                                    mtext.Contents = listref2[i].ten + "\n" + "SL: " + listref2[i].slbo + "\n" + "VL: " + listref2[i].vatlieu;
                                    mtext.Attachment = AttachmentPoint.MiddleCenter;

                                    // Ghi nhận thay đổi
                                    mtext.RecordGraphicsModified(true);
                                    i++;
                                }


                                tr.Commit();
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                    while (i < listref2.Count);

                    listref2.Clear();
                    listbl.Clear();
                }
                else { ed.WriteMessage("BlockReference không được chọn"); }
            }
            else { MessageBox.Show("Giấy phép đã hết hạn"); }
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
