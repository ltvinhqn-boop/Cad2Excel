using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Windows.ToolPalette;


using Autodesk.AutoCAD.Geometry;

using AcAp = Autodesk.AutoCAD.ApplicationServices.Application;
using OfficeOpenXml;
[assembly: CommandClass(typeof(CAD2EXCEL.Commands1))]

namespace CAD2EXCEL
{
    public class Commands1
    {
        public List<REF> listref2 = new List<REF>();
        public List<BlockReference> listbl = new List<BlockReference>();
        public Form_pl PL { get; set; }
        public Form_export Px { get; set; }

        //---------------------------------------------
                  
           
        //------------------------------------

        //--------------------------------------------
        [CommandMethod("C2E")]
        public void exportexcel()
        {

            this.Px = new Form_export();
            this.Px.FormClosing += Px_FormClosing;
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(this.Px);
        }

        private void Px_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)

        {
            this.Px = null;
        }


        //-----------------------------------------------
        [CommandMethod("C2P")]
        public void addpartlist()
        {
            
            this.PL = new Form_pl();
            this.PL.FormClosing += PL_FormClosing;
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(this.PL);
        }

        private void PL_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)

        {
            this.PL = null;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------
        [CommandMethod("RMT")]
        public void SelectMText()
        {
            int i = 0;

            //Lấy đối tượng Document hiện tại
            var doc = AcAp.DocumentManager.MdiActiveDocument;
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

                                    mtext.Contents = listref2[i].ten + "\n" + "SL: " + listref2[i].slbo + "\n" + "VL: " + listref2[i].vatlieu ;
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


        [CommandMethod("contact")]
        public void ccontact()
        {
            string link = "https://www.facebook.com/profile.php?id=61554727807311";
            // Mở trình duyệt web với liên kết đó
            Process.Start(link);
        }
        ///-------------------------------------------------------------------------------------------------------------------------
    // Lưu trạng thái củamenu vào tệp CUI

        //------------------------------------------------------------------------------------------------------------------------------------------
    }
    public class BlockReferenceComparer : IComparer<BlockReference>
    {
        public int Compare(BlockReference x, BlockReference y)
        {
            Point3d position1 = x.Position;
            Point3d position2 = y.Position;

            if (position1.X != position2.X)
            {
                return position1.X.CompareTo(position2.X);
            }
            else
            {
                return position1.Y.CompareTo(position2.Y);
            }
        }
    }

    //----------------------------------------------------------------------
   
   
}
