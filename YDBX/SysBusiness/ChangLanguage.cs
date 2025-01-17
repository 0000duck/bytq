using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Sys.Language
{
    public class ChangLanguage
    {
        #region SetAllLang
        /// <summary>
        /// 设置所有窗体的界面语言
        /// </summary>
        /// <param name="lang">language:zh-CN, en-US</param>
        public static void SetAllLang(string lang)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            Form frm = null;
            //string path = AssemblyName.GetAssemblyName("PMISServer").ToString();//项目的Assembly选项名称
            //Assembly asm = Assembly.Load("PMISServer");//程序集名
            //        object frmObj = asm.CreateInstance("Fastyou.BookShop.Win." + formName);//程序集+form的类名。
            string name = "MainForm"; //类的名字

            frm = (Form)Assembly.Load("PMISServer").CreateInstance(name);

            //Type formType = null;
            //formType = typeof(frm);

            if (frm != null)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager();
                resources.ApplyResources(frm, "$this");
                AppLang(frm, resources);
            }
        }
        #endregion

        #region SetLang
        /// <summary>
        /// 设置当前程序的界面语言
        /// </summary>
        /// <param name="lang">language:zh-CN, en-US</param>
        /// <param name="form">窗体实例</param>
        /// <param name="formType">窗体类型</param>
        public static void SetLang(string lang, Form form, Type formType)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            if (form != null)
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(formType);
                resources.ApplyResources(form, "$this");
                AppLang(form, resources);
            }
        }
        #endregion

        #region AppLang for control
        /// <summary>
        /// 遍历窗体所有控件，针对其设置当前界面语言
        /// </summary>
        /// <param name="control"></param>
        /// <param name="resources"></param>
        private static void AppLang(Control control, System.ComponentModel.ComponentResourceManager resources)
        {
            if (control is MenuStrip)
            {
                //将资源应用与对应的属性
                resources.ApplyResources(control, control.Name);
                MenuStrip ms = (MenuStrip)control;
                if (ms.Items.Count > 0)
                {
                    foreach (ToolStripMenuItem c in ms.Items)
                    {
                        //调用 遍历菜单 设置语言
                        AppLang(c, resources);
                    }
                }
            }

            foreach (Control c in control.Controls)
            {
                resources.ApplyResources(c, c.Name);
                AppLang(c, resources);
            }
        }
        #endregion

        #region AppLang for menuitem
        /// <summary>
        /// 遍历菜单
        /// </summary>
        /// <param name="item"></param>
        /// <param name="resources"></param>
        private static void AppLang(ToolStripMenuItem item, System.ComponentModel.ComponentResourceManager resources)
        {
            if (item is ToolStripMenuItem)
            {
                resources.ApplyResources(item, item.Name);
                ToolStripMenuItem tsmi = (ToolStripMenuItem)item;
                if (tsmi.DropDownItems.Count > 0)
                {
                    foreach (ToolStripMenuItem c in tsmi.DropDownItems)
                    {
                        //if (tsmi != ToolStripSeparator)
                        //{ }
                        AppLang(c, resources);
                    }
                }
            }
        }
        #endregion
    }
}
