using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EntityGenerator
{
    public partial class GForm : Form
    {
        private string _strConn = null;
        private DbStyle _style = DbStyle.Mysql;

        public GForm(string strConn, DbStyle style)
        {
            this._strConn = strConn;
            this._style = style;
            InitializeComponent();
            startup();
        }

        private void GForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.tbPath.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = this.tbPath.Text;
            string ifpkg = this.tbinterface.Text;
            string clpkg = this.tbclass.Text;
            string dbname = this.tv.SelectedNode.Text;
            string drpkg = this.tbdrouter.Text;
            string sifpkg = tbsif.Text;
            string sclpkg = tbscl.Text;


            if (Directory.Exists(path + "\\service\\"))
                Directory.Delete(path + "\\service\\",true);
            if (Directory.Exists(path + "\\data\\"))
                Directory.Delete(path + "\\data\\",true);
            if (Directory.Exists(path + "\\drouter\\"))
                Directory.Delete(path + "\\drouter\\",true);
            Directory.CreateDirectory(path + "\\service\\");
            Directory.CreateDirectory(path + "\\data\\");
            Directory.CreateDirectory(path + "\\drouter\\");

            DataGridViewRowCollection rc = dgv.Rows;
            StringBuilder sbPersistence = new StringBuilder();
            sbPersistence.AppendLine("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>")
                .AppendLine("<AlbianObjects>");

            StringBuilder sbRouter = new StringBuilder();
            sbRouter.AppendLine("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>")
               .AppendLine("<AlbianObjects>");

            StringBuilder sbService = new StringBuilder();
            sbService.AppendLine("<?xml version=\"1.0\" encoding=\"utf - 8\" ?>")
               .AppendLine("    <Services>");

            foreach (DataGridViewRow r in rc)
            {
                DataGridViewCheckBoxCell c = (DataGridViewCheckBoxCell) r.Cells[0];
                string _selectValue = c.EditedFormattedValue.ToString();
                if (_selectValue == "True")
                {
                    DataGridViewTextBoxCell tc = (DataGridViewTextBoxCell)r.Cells[1];
                    DataGridViewTextBoxCell tc2 = (DataGridViewTextBoxCell)r.Cells[2];
                  
                    string tname = tc.EditedFormattedValue.ToString();
                    string defclassname = tc2.EditedFormattedValue.ToString();
                    string serviceId = "Yw" + defclassname + "Service";
                    string sclassname = defclassname + "Service";
                    string sifname = "I" + defclassname + "Service";

                    makeFile(path, ifpkg, clpkg, dbname, tname, defclassname, sbPersistence);

                    sbService.Append("      <Service Id=\"").Append(serviceId)
                        .Append("\" Interface=\"").Append(sifpkg).Append(".").Append(sifname)
                        .Append("\" Type=\"").Append(sclpkg).Append(".").Append(sclassname).AppendLine("\" />");
                        

                    string dr = defclassname + "DataRouter";
                    string ifname = "I" + defclassname;
                    sbRouter.AppendFormat("    <AlbianObject Interface = \"").Append(ifpkg).Append(".").Append(ifname)
                        .Append("\" Type = \"").Append(clpkg).Append(".").Append(defclassname)
                        .Append("\" Router=\"").Append(drpkg).Append(".").Append(dr)
                        .AppendLine("\">")
                        .AppendLine("       <WriterRouters Enable=\"true\">")
                        .AppendFormat("           <WriterRouter Name=\"{0}W\" StorageName=\"\" ", dr)
                        .AppendFormat("TableName=\"{0}\" Enable=\"true\"></WriterRouter>", tc.EditedFormattedValue.ToString()).AppendLine()
                        .AppendLine("       </WriterRouters>")
                         .AppendLine("       <ReaderRouters Enable=\"true\">")
                        .AppendFormat("           <ReaderRouter Name=\"{0}R\" StorageName=\"\" ", dr)
                        .AppendFormat("TableName=\"{0}\" Enable=\"true\"></ReaderRouter>", tc.EditedFormattedValue.ToString()).AppendLine()
                        .AppendLine("       </ReaderRouters>")
                        .AppendLine("   </AlbianObject>");

                    StringBuilder sbRouterCode = new StringBuilder();
                    sbRouterCode.Append("package ").Append(drpkg).AppendLine(";")
                        .AppendLine()
                        .AppendLine("import java.util.LinkedList;")
                        .AppendLine("import java.util.List;")
                        .AppendLine("import java.util.Map;")
                        .AppendLine()
                        .AppendLine("import org.albianj.persistence.object.FreeAlbianObjectDataRouter;")
                        .AppendLine("import org.albianj.persistence.object.IAlbianObject;")
                        .AppendLine("import org.albianj.persistence.object.IDataRouterAttribute;")
                        .AppendLine("import org.albianj.persistence.object.IFilterCondition;")
                        .AppendLine("import org.albianj.persistence.object.IOrderByCondition;")
                        .AppendLine("import org.albianj.persistence.object.IStorageAttribute;")
                        .Append("import ").Append(ifpkg).Append(".").Append(ifname).AppendLine(";")
                        .AppendLine()
                        .Append("public class ").Append(dr).AppendLine(" extends FreeAlbianObjectDataRouter { ")
                        .AppendLine("//如果需要数据路由算法，请执行override对应的方法")
                        .AppendLine("}");

                    StringBuilder sbServiceIf = new StringBuilder();
                    sbServiceIf.Append("package ").Append(sifpkg).AppendLine(";").AppendLine()
                        .AppendLine("import org.albianj.persistence.object.IAlbianObject;")
                        .AppendLine("import org.albianj.service.IAlbianService;")
                        .AppendLine()
                        .Append("public interface ").Append(sifname).Append(" extends IAlbianService {").AppendLine()
                        .AppendLine()
                         .Append("//请根据自己的需求，声明接口方法").AppendLine()
                        .Append("//不要修改自动生成的name，，如果需要修改，请同时修改service中的serviceid").AppendLine()
                        .Append("   final static String Name = \"").Append(serviceId).AppendLine("\";").AppendLine()
                        .AppendLine("}");

                    StringBuilder sbServiceClass = new StringBuilder();
                    sbServiceClass.Append("package ").Append(sclpkg).AppendLine(";").AppendLine()
                        .AppendLine("import org.albianj.service.FreeAlbianService;")
                        .AppendLine("import ").Append(sifpkg).Append(".").Append(sifname).AppendLine(";").AppendLine()
                        .Append("public class ").Append(sclassname).Append(" extends FreeAlbianService implements ").Append(sifname).AppendLine("{")
                        .AppendLine("//请自行实现业务接口中的方法")
                        .AppendLine("}");

                    string drpath = tbPath.Text + "\\drouter\\" + dr + ".java";
                    File.WriteAllText(drpath,sbRouterCode.ToString());
                    string sifpath = tbPath.Text + "\\service\\" + sifname + ".java";
                    string sclpath = tbPath.Text + "\\service\\" + sclassname + ".java";
                    File.WriteAllText(sifpath,sbServiceIf.ToString());
                    File.WriteAllText(sclpath, sbServiceClass.ToString());
                   
                }
                
            }

            sbPersistence.AppendLine("</AlbianObjects>");
            sbRouter.AppendLine("</AlbianObjects>");
            sbService.AppendLine("</Services>");
            string xmlpath = tbPath.Text + "\\" + "persisten.xml";
            File.WriteAllText(xmlpath, sbPersistence.ToString());
            File.WriteAllText(tbPath.Text + "\\drouter.xml", sbRouter.ToString());
            File.WriteAllText(tbPath.Text + "\\service.xml", sbService.ToString());

            MessageBox.Show("生成成功！");
        }

        private void startup()
        {

            switch (_style)
            {
                case DbStyle.Mysql:
                    string sSysDatabase = "information_schema";
                    string sconn = makeConnectString(sSysDatabase);
                    IDbConnection conn = null;
                    try
                    {
                        conn = new MySqlConnection(sconn);
                        conn.Open();
                        IDbCommand cmd = null;
                        try
                        {
                            cmd = new MySqlCommand(@"select * from schemata",(MySqlConnection) conn);
                            cmd.CommandType = CommandType.Text;
                            MySqlDataReader dr = null;
                            try
                            {
                                dr = ((MySqlCommand) cmd).ExecuteReader();
                                if(null != dr)
                                {
                                    while (dr.Read())
                                    {
                                        String schema = dr.GetString("schema_name");
                                        tv.Nodes.Add(schema);
                                    }
                                }

                            }
                            catch(Exception e2)
                            {

                            }
                            finally
                            {
                                if(null != dr)
                                {
                                    dr.Close();
                                }
                            }
                        }catch(Exception e1)
                        {

                        }
                        finally
                        {
                            if (null != cmd)
                                cmd.Dispose();
                        }

                    }catch(Exception e)
                    {

                    }
                    finally
                    {
                        if(null != conn)
                        {
                            conn.Close();
                        }
                    }

                   

                    break;
                case DbStyle.SqlServer:
                    break;
                case DbStyle.Oracle:
                    break;
                default:
                    break;
            }
        }

        private string makeConnectString(string dbName)
        {
            String sconn = this._strConn + ";Database=" + dbName;
            return sconn;
        //    Database = '数据库名'; Data Source = '数据库服务器地址'; User Id = '数据库用户名'; Password = '密码'; charset = 'utf8'; pooling = true "information_schema"
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (_style)
            {
                case DbStyle.Mysql:
                    string sSysDatabase = "information_schema";
                    string sconn = makeConnectString(sSysDatabase);
                    IDbConnection conn = null;
                    try
                    {
                        conn = new MySqlConnection(sconn);
                        conn.Open();
                        IDbCommand cmd = null;
                        try
                        {
                            cmd = new MySqlCommand(@"select * from tables where table_schema = '" + e.Node.Text +"'", (MySqlConnection)conn);
                            cmd.CommandType = CommandType.Text;
                            MySqlDataReader dr = null;
                            try
                            {
                                dr = ((MySqlCommand)cmd).ExecuteReader();
                                if (null != dr)
                                {
                                  //  dgv.ColumnCount = 3;
                                    dgv.AutoGenerateColumns = false;
                                    dgv.Columns.Clear();

                                    DataGridViewColumn cl = new DataGridViewTextBoxColumn();
                                    //DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                    //column.DataPropertyName = "Name";
                                    cl.Name = "表名";
                                    dgv.Columns.Add(cl);

                                    cl = new DataGridViewTextBoxColumn();
                                    //column.DataPropertyName = "Name";
                                    cl.Name = "类名";
                                    dgv.Columns.Add(cl);

                                    //dgv.Columns[0].Name = "选择";
                                    //dgv.Columns[1].Name = "表名";
                                    //dgv.Columns[2].Name = "类名";


                                    while (dr.Read())
                                    {
                                        String tbName = dr.GetString("table_name");
                                        DataGridViewRow row = new DataGridViewRow();
                                        //DataGridViewCheckBoxCell cbx = new DataGridViewCheckBoxCell();
                                        //row.Cells.Add(cbx);
                                        //cbx.
                                        DataGridViewTextBoxCell tbx = new DataGridViewTextBoxCell();
                                        row.Cells.Add(tbx);
                                        tbx.ReadOnly = true;
                                        tbx.Value = tbName;
                                        
                                        DataGridViewTextBoxCell tbx2 = new DataGridViewTextBoxCell();
                                        tbx2.Value = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tbName);
                                        row.Cells.Add(tbx2);
                                        dgv.Rows.Add(row);

                                    }
                                }
                                DataGridViewColumn column = new DataGridViewCheckBoxColumn();

                                column = new DataGridViewCheckBoxColumn();
                                column.Name = "选择";
                                dgv.Columns.Insert(0,column);
                            }
                            catch (Exception e2)
                            {
                                MessageBox.Show(e2.Message);
                            }
                            finally
                            {
                                if (null != dr)
                                {
                                    dr.Close();
                                }
                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }
                        finally
                        {
                            if (null != cmd)
                                cmd.Dispose();
                        }

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                    finally
                    {
                        if (null != conn)
                        {
                            conn.Close();
                        }
                    }



                    break;
                case DbStyle.SqlServer:
                    break;
                case DbStyle.Oracle:
                    break;
                default:
                    break;
            }
        }

        private void makeFile(string path,string ifpkg,string clpkg,string dbname,string tname,string defclassname,StringBuilder sbxml)
        {
            string sSysDatabase = "information_schema";
            string sconn = makeConnectString(sSysDatabase);
            IDbConnection conn = null;
            try
            {
                string ifname = "I" + defclassname;
                StringBuilder ifsb = new StringBuilder();
                ifsb.Append("package ").Append(ifpkg).AppendLine(";");
                ifsb.AppendLine();
                ifsb.AppendLine("import org.albianj.persistence.object.IAlbianObject;");
                ifsb.AppendLine();
                ifsb.Append("public interface ").Append(ifname).Append(" extends IAlbianObject { ").AppendLine();
                ifsb.AppendLine();

                StringBuilder clsb = new StringBuilder();
                clsb.Append("package ").Append(clpkg).AppendLine(";");
                clsb.AppendLine();
                clsb.AppendLine("import org.albianj.persistence.object.FreeAlbianObject;");
                clsb.Append("import ").Append(ifpkg).Append(".").Append(ifname).AppendLine(";");
                clsb.AppendLine();
                clsb.Append("public class ").Append(defclassname)
                    .Append(" extends FreeAlbianObject implements ").
                    Append(ifname).Append(" { ").AppendLine();
                clsb.AppendLine();

                sbxml.AppendFormat("    <AlbianObject Interface = \"").Append(ifpkg).Append(".").Append(ifname)
                    .Append("\" Type = \"").Append(clpkg).Append(".").Append(defclassname).AppendLine("\">")
                    .AppendLine("       <Cache Enable=\"false\" LifeTime=\"300\" Name=\"\"></Cache>")
                    .AppendLine("       <Members>");

               



                conn = new MySqlConnection(sconn);
                conn.Open();
                IDbCommand cmd = null;
                try
                {
                    cmd = new MySqlCommand(@"select * from columns where table_schema ='" + dbname +"' and table_name ='" + tname + "'", (MySqlConnection)conn);
                    cmd.CommandType = CommandType.Text;
                    MySqlDataReader dr = null;
                    try
                    {
                        dr = ((MySqlCommand)cmd).ExecuteReader();
                        if (null != dr)
                        {
                            while (dr.Read())
                            {
                                string column = dr.GetString("column_name");
                                string dtype = dr.GetString("data_type");
                                string ctype = dr.GetString("column_type");
                                string ckey = dr.GetString("column_key");
                                string arg = char.ToLower(column[0]) + column.Substring(1);

                                ifsb.Append("   public ").Append(dataTypeToJavaType(dtype, ctype))
                                    .Append(" get").Append(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(column))
                                    .Append("();").AppendLine()
                                    .Append("   public void set").Append(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(column))
                                   .Append("(").Append(dataTypeToJavaType(dtype, ctype)).Append(" ").Append(arg).Append(");")
                                   .AppendLine()
                                    .AppendLine();

                                clsb.Append("   private ").Append(dataTypeToJavaType(dtype, ctype))
                                    .Append(" _").Append(arg).Append(";").AppendLine()
                                    .Append("   public ").Append(dataTypeToJavaType(dtype, ctype))
                                   .Append(" get").Append(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(column))
                                   .Append("(){").AppendLine()
                                   .Append("        return this._").Append(arg).AppendLine(";")
                                   .AppendLine("    }")
                                .Append("   public void set").Append(Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(column))
                                   .Append("(").Append(dataTypeToJavaType(dtype, ctype)).Append(" ").Append(arg).AppendLine("){ ")
                                   .Append("        this._").Append(arg).Append(" = ").Append(arg).AppendLine(";")
                                   .AppendLine("    }")
                                .AppendLine();


                                if(ckey.ToUpper().Equals("PRI"))
                                {
                                    sbxml.AppendFormat("            <Member Name = \"{0}\" FieldName = \"{1}\"  PrimaryKey=\"true\"/>",
                                        Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(column),column
                                        ).AppendLine();
                                } else
                                {
                                    sbxml.AppendFormat("            <Member Name = \"{0}\" FieldName = \"{1}\"  />",
                                       Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(column), column
                                       ).AppendLine();
                                }
                                


                            }

                            ifsb.AppendLine("}");
                            clsb.AppendLine("}");
                            sbxml.AppendLine("      </Members>");
                            sbxml.AppendLine("  </AlbianObject>");
                          
                        }

                        string ifpath = path +"\\data\\"+ ifname + ".java";
                        string cpath = path + "\\data\\"+ defclassname + ".java";
                        File.WriteAllText(ifpath, ifsb.ToString());
                        File.WriteAllText(cpath, clsb.ToString());
                        

                    }
                    catch (Exception e2)
                    {

                    }
                    finally
                    {
                        if (null != dr)
                        {
                            dr.Close();
                        }
                    }
                }
                catch (Exception e1)
                {

                }
                finally
                {
                    if (null != cmd)
                        cmd.Dispose();
                }

               

            }
            catch (Exception e)
            {

            }
            finally
            {
                if (null != conn)
                {
                    conn.Close();
                }
            }
        }

        private string dataTypeToJavaType(string dtype,string columnType)
        {
            switch (dtype.Trim().ToLower()) {
                case "varchar":
                case "char":
                case "text":
                    {
                        return "String";
                    }
                case "blob":
                    {
                        return "byte[]";
                    }
                case "int":
                    {
                        if (columnType.Contains("unsigned"))
                        {
                            return "long";
                        }
                        return "int";
                    }
                case "tinyint":
                case "smallint":
                case "mediumint":
                    {
                        return "int";
                    }
                case "bit":
                    {
                        return "boolean";
                    }
                case "bigint":
                    {
                        return "java.math.BigInteger";
                    }
                case "float":
                    {
                        return "float";
                    }
                case "double":
                    {
                        return "double";
                    }
                case "decimal":
                    {
                        return "java.math.BigDecimal";
                    }
                case "date":
                    {
                        return "java.sql.Date";
                    }
                case "time":
                    {
                        return "java.sql.Time";
                    }
                case "datetime":
                case "timestamp":
                    {
                        return "java.sql.Timestamp";
                    }
                default:
                    {
                        return "String";
                    }
            }
        }






    }
        

  
}
