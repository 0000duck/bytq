//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Jirisoft , Ltd. 
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.Remoting;

namespace DotNet.WinForm.LogOn
{
    using DotNet.Model;
    using DotNet.Utilities;
    using DotNet.Service;
    using DotNet.WinForm.Utilities;

    /// <summary>
    /// FrmLogOnSelect
    /// 
    /// �޸ļ�¼
    /// 
    ///		2008.03.21 �汾��1.3 JiRiGaLa �û������벻�ܼ�¼�Ĵ�����иĽ���
    ///		2007.09.17 �汾��1.2 JiRiGaLa �����ϰ� ESC ��ť�˲����Ĵ���������
    ///		2007.08.05 �汾��1.1 JiRiGaLa �û�����¼��������ʾ��Ϣ��ʾ��Ĭ�������¼������
    ///		2007.06.12 �汾��1.0 JiRiGaLa �����ļ���
    ///		
    /// �汾��1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.09.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmLogOnSelect : BaseForm
    {
        public DataTable DTStaff = new DataTable(BaseStaffTable.TableName);    // ְԱ�б�
        
        private int AllowLogOnCount     = 3;    // ��������¼���� 
        private int LogOnCount          = 0;    // �ѵ�¼����

        public FrmLogOnSelect()
        {
            InitializeComponent();
        }

        #region private void SetHelp()
        /// <summary>
        /// ���ð���
        /// </summary>
        private void SetHelp()
        {
            this.HelpButton = true;
        }
        #endregion

        #region public override void SetControlState() ���ð�ť״̬
        /// <summary>
        /// ���ð�ť״̬
        /// </summary>
        public override void SetControlState()
        {
            if (BaseSystemInfo.AllowNullPassword)
            {
                this.labPasswordReq.Visible = false;
            }
            if (BaseSystemInfo.LogOned)
            {
                this.CancelButton = this.btnCancel;
                this.btnCancel.Show();
                this.btnExit.Hide();
            }
            else
            {
                this.CancelButton = this.btnExit;
                this.btnExit.Show();
                this.btnCancel.Hide();
            }            
        }
        #endregion

        #region private void GetLogOnInfo() ��ȡ���еĵ�¼��Ϣ
        /// <summary>
        /// ��ȡ���еĵ�¼��Ϣ
        /// </summary>
        private void GetLogOnInfo()
        {
            if (BaseSystemInfo.RememberPassword)
            {
                // ��ȡע�����Ϣ
                try
                {
                    RegistryKey RegistryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName, false);
                    if (RegistryKey != null)
                    {
                        this.txtUserName.Text = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                        // this.cmbUserName.SelectedValue = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                        // this.txtPassword.Text  = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    }
                }
                catch
                {
                }
            }
        }
        #endregion

        /// <summary>
        /// ѡ�����࣬����ComboBox����ListBox�����
        /// </summary>
        public class ListItem
        {
            private string id = string.Empty;
            private string name = string.Empty;

            public ListItem(string sid, string sname)
            {
                id = sid;
                name = sname;
            }

            public override string ToString()
            {
                return this.name;
            }

            public string ID
            {
                get
                {
                    return this.id;
                }
                set
                {
                    this.id = value;
                }
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }
        }

        #region private void GetLogOnTo() ��ȡ�����ļ�ѡ��
        /// <summary>
        /// ��ȡ�����ļ�ѡ��
        /// </summary>
        private void GetLogOnTo()
        {
            Dictionary<String, String> loginTo = ConfigHelper.GetLogOnTo();
            foreach(KeyValuePair<String, String> keyValue in loginTo)
            {
                ListItem item = new ListItem(keyValue.Key, keyValue.Value);
                this.cmbLogOnTo.Items.Add(item);
            }
            this.cmbLogOnTo.ValueMember = "Id";
            this.cmbLogOnTo.DisplayMember = "Name";
            if (this.cmbLogOnTo.Items.Count > 0)
            {
                this.cmbLogOnTo.SelectedIndex = 0;
            }
        }
        #endregion

        private void SetLogOnTo(string loginTo)
        {
            if (!String.IsNullOrEmpty(loginTo))
            {
                for (int i = 0; i < this.cmbLogOnTo.Items.Count; i++)
                {
                    if (((ListItem)this.cmbLogOnTo.Items[i]).ID.Equals(loginTo))
                    {
                        this.cmbLogOnTo.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        #region private void FormOnLoad() ���ش���
        /// <summary>
        /// ���ش���
        /// </summary>
        private void FormOnLoad()
        {
            // ������귱æ״̬
            this.Cursor = Cursors.WaitCursor;

            // this.BackgroundImage = Image.FromFile(BaseSystemInfo.AppPath + @"\Resource\Images\LogOn.jpg");
            // ���������ʾ�����Ե������ٶȺܿ�
            // this.Refresh();

            // this.DTStaff = ServiceManager.Instance.UserService.Load(UserInfo);
            // ְԱ��Ҫ���û�������������
            // this.DTStaff.DefaultView.Sort = BUBaseStaff.FieldUserName;

            // ����û�������ǲ�ס������
            // foreach (DataRowView dataRowView in this.DTStaff.DefaultView)
            // {
            //     this.cmbUserName.Items.Add(dataRowView[BUBaseStaff.FieldUserName].ToString());
            // }

            // this.cmbUserName.DataSource = this.DTStaff.DefaultView;
            // this.cmbUserName.DisplayMember = BUBaseStaff.FieldUserName;
            // this.cmbUserName.ValueMember = BUBaseStaff.FieldId;

            this.GetLogOnTo();

            // Ĭ�Ͻ������û���������
            // this.ActiveControl = this.txtUserName;
            this.txtUserName.Focus();
            if (BaseSystemInfo.RememberPassword)
            {
                // ��ȡע�����Ϣ
                try
                {
                    RegistryKey RegistryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName, false);
                    if (RegistryKey != null)
                    {
                        this.txtUserName.Text = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                        this.SetLogOnTo((string)RegistryKey.GetValue(BaseConfiguration.CURRENT_LOGIN_TO));
                        // this.cmbUserName.SelectedValue = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                        // this.txtPassword.Text       = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    }
                }
                catch
                {
                }
            }
            // ��ǰ�����뽹��ͣ��������༭���ϣ��Ǻǲ���ĸĽ���
            if (this.txtUserName.Text.Length > 0)
            {
                this.ActiveControl = this.txtPassword;
                this.txtPassword.Focus();
            }
            // �����Թ��ʻ�����
            this.Localization(this);
            // ���ð���
            this.SetHelp();
            // ���ð�ť״̬
            this.SetControlState();
            // �������Ĭ��״̬
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void FrmLogOn_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // ������귱æ״̬
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // ���ش���
                    this.FormOnLoad();
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // �������Ĭ��״̬
                    this.Cursor = Cursors.Default;
                }
            }
        }

        #region private bool CheckInput() ����������Ч��
        /// <summary>
        /// ����������Ч��
        /// </summary>
        private bool CheckInput()
        {
            // �����¼�����Ѿ�����
            if (this.LogOnCount == this.AllowLogOnCount)
            {
                this.txtPassword.Clear();
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;
                return false;
            }
            // �Ƿ�û�������û���
            if (this.txtUserName.Text.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtUserName.Focus();
                return false;
            }
            if (!BaseSystemInfo.AllowNullPassword)
            {
                if (this.txtPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    return false;
                }
            }
            this.btnConfirm.Focus();
            return true;
        }
        #endregion

        #region private void CheckAllowLogOnCount() �����¼�����Ѿ�����
        /// <summary>
        /// �����¼�����Ѿ�����
        /// </summary>
        private void CheckAllowLogOnCount()
        {
            if (this.LogOnCount >= this.AllowLogOnCount)
            {
                this.txtPassword.Clear();
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;
                return;
            }
        }
        #endregion

        #region private bool LogOn()
        /// <summary>
        /// �û���¼
        /// </summary>
        /// <returns>�Ƿ�ɹ�</returns>
        private bool LogOn()
        {
            if (!BaseSystemInfo.LogOned && this.cmbLogOnTo.Enabled)
            {
                ConfigHelper.LogOnTo = ((ListItem)this.cmbLogOnTo.SelectedItem).ID;
                // ��ȡ�����ļ�
                ConfigHelper.GetConfig();
                if (BaseSystemInfo.RunMode == RunMode.Remoting)
                {
                    this.cmbLogOnTo.Enabled = false;
                    // this.Unregister();
                    RemotingConfiguration.Configure(ConfigHelper.FileName);
                }
            }

            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            BaseUserInfo userInfo = ServiceManager.Instance.LogOnService.UserLogOn(UserInfo, this.txtUserName.Text, this.txtPassword.Text, out statusCode, out statusMessage);
            // BaseUserInfo userInfo = ServiceManager.Instance.UserService.LogOnByUID(UserInfo, this.txtUserName.Text, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OK.ToString())
            {
                // ������
                if ((userInfo != null) && (userInfo.Id.Length > 0))
                {
                    this.LogOn(userInfo);
                    if (BaseSystemInfo.RememberPassword)
                    {
                        this.SaveLogOnInfo();
                    }

                    // �����ǵ�¼���ܲ���
                    if (this.Parent == null)
                    {
                        this.Hide();
                        if (!BaseSystemInfo.LogOned)
                        {
                            Form mainForm = CacheManager.Instance.GetForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.MainForm);
                            ((IBaseMainForm)mainForm).InitService();
                            ((IBaseMainForm)mainForm).InitForm();
                            mainForm.Show();
                        }
                    }
                    // �����ʾ�Ѿ���¼ϵͳ��
                    BaseSystemInfo.LogOned = true;
                    // ��¼�������㣬�������µ�¼
                    this.LogOnCount = 0;                        

                    // ����������������
                    if (this.Owner != null)
                    {
                        ((IBaseMainForm)this.Owner).InitService();
                        ((IBaseMainForm)this.Owner).InitForm();
                        ((IBaseMainForm)this.Owner).CheckMenu();                        
                        return true;
                    }
                    if (this.Parent != null)
                    {
                        // ���»�ȡ��¼״̬��Ϣ
                        ((IBaseMainForm)this.Parent.Parent).InitService();
                        ((IBaseMainForm)this.Parent.Parent).InitForm();
                        ((IBaseMainForm)this.Parent.Parent).CheckMenu();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPassword.Focus();
                this.txtPassword.SelectAll();
                return false;
            }
            return true;
        }
        #endregion	

        #region private void LogOn(BaseUserInfo userInfo) ְԱ��¼�������¼��Ϣ
        /// <summary>
        /// ����Ա��¼�������¼��Ϣ
        /// </summary>
        /// <param name="userInfo">����Աʵ��</param>
        private void LogOn(BaseUserInfo userInfo)
        {
            BaseSystemInfo.LogOn(userInfo);
        }
        #endregion

        #region private void SaveLogOnInfo() ����¼��Ϣ���浽ע�����
        /// <summary>
        /// ����¼��Ϣ���浽ע�����
        /// </summary>
        private void SaveLogOnInfo()
        {
            // ������귱æ״̬
            this.Cursor = Cursors.WaitCursor;
            if (BaseSystemInfo.RememberPassword)
            {
                try
                {
                    // Ĭ�ϵ���Ϣд��ע���,�Ǻ���Ҫ�Ľ�һ��
                    RegistryKey RegistryKey = Registry.LocalMachine.CreateSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName);
                    RegistryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, this.txtUserName.Text);
                    // RegistryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, this.cmbUserName.SelectedValue);
                    // RegistryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, this.cmbUserName.SelectedText);
                    RegistryKey.SetValue(BaseConfiguration.CURRENT_PASSWORD, this.txtPassword.Text);
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // �������Ĭ��״̬
                    this.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        private void txtPassword_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // ����������Ч��
                if (this.CheckInput())
                {
                    // �û���¼
                    this.LogOn();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // ��֤�û�����
            if (this.CheckInput())
            {
                // �Ѿ���¼���� ++
                this.LogOnCount ++;
                // �û���¼
                this.LogOn();
                // �����¼�����Ѿ�����
                this.CheckAllowLogOnCount();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}