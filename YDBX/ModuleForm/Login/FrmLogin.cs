//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Jirisoft , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DotNet.WinForm.LogOn
{
    using DotNet.Model;
    using DotNet.Service;
    using DotNet.Utilities;
    using DotNet.WinForm.Utilities;

    /// <summary>
    /// FrmLogOn
    /// �û���¼ϵͳ
    /// 
    /// �޸ļ�¼
    /// 
    ///		2010.10.17 �汾��2.1 JiRiGaLa ���������������Ҫ������ʾ��Ϣ���˳�����
    ///		2010.09.19 �汾��2.0 JiRiGaLa ���Ƽ�ס���빦�ܣ����밴���ܷ�ʽ���档
    ///		2010.02.26 �汾��1.6 JiRiGaLa ֻ���ڲ��û����ܵ�¼��
    ///		2009.01.19 �汾��1.5 JiRiGaLa SAP��¼��������
    ///		2009.01.19 �汾��1.4 JiRiGaLa ������Ϊ�û�����ʵ������������
    ///		2008.03.21 �汾��1.3 JiRiGaLa �û������벻�ܼ�¼�Ĵ�����иĽ���
    ///		2007.09.17 �汾��1.2 JiRiGaLa �����ϰ� ESC ��ť�˲����Ĵ���������
    ///		2007.08.05 �汾��1.1 JiRiGaLa �û�����¼��������ʾ��Ϣ��ʾ��Ĭ�������¼������
    ///		2007.06.12 �汾��1.0 JiRiGaLa �����ļ���
    ///		
    /// �汾��2.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.10.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmLogOn : BaseForm
    {
        /// <summary>
        /// �û��б�
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserTable.TableName);

        /// <summary>
        /// ��������¼����
        /// </summary>
        private int AllowLogOnCount = 3; 

        /// <summary>
        /// �ѵ�¼����
        /// </summary>
        private int LogOnCount = 0;
        
        public FrmLogOn()
        {
            InitializeComponent();
        }

        #region public override void SetHelp() ���ð���
        /// <summary>
        /// ���ð���
        /// </summary>
        public override void SetHelp()
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
            if (BaseSystemInfo.LogOned)
            {
                this.Text = AppMessage.MSGReLogOn;
            }
            // �Ƿ�������������
            this.btnRequestAnAccount.Visible = BaseSystemInfo.AllowUserRegister;
            // �Ƿ������������
            this.labPasswordReq.Visible = !BaseSystemInfo.AllowNullPassword;
            // �ѵ�¼�ˣ�����δ��¼״̬
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
            if (this.chkRememberPassword.Checked)
            {
                string userName = BaseSystemInfo.CurrentUserName;
                DataRowView dataRowView = null;
                for (int i = 0; i < this.cmbUser.Items.Count; i++)
                {
                    dataRowView = (DataRowView)this.cmbUser.Items[i];
                    if (dataRowView[BaseUserTable.FieldUserName].ToString().Equals(userName))
                    {
                        this.cmbUser.SelectedIndex = i;
                        break;
                    }
                }
                // ��������н��ܲ���
                string password = BaseSystemInfo.CurrentPassword;
                password = SecretUtil.Decrypt(password);
                this.txtPassword.Text = password;
                
                // д��ע�����Ϣ����������ǻ�������ȫ���⣬�����쳣��
                /*
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName, false);
                if (registryKey != null)
                {
                    // �����Ǳ����û����Ķ�ȡ�����û������н��ܲ���
                    string userName = (string)registryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                    userName = SecretUtil.Decrypt(userName);
                    DataRowView dataRowView = null;
                    for (int i = 0; i < this.cmbUser.Items.Count; i++)
                    {
                        dataRowView = (DataRowView)this.cmbUser.Items[i];
                        if (dataRowView[BaseUserTable.FieldUserName].ToString().Equals(userName))
                        {
                            this.cmbUser.SelectedIndex = i;
                            // this.cmbUser.SelectedItem = this.cmbUser.Items[i];
                            // this.cmbUser.SelectedValue = userName;
                            break;
                        }
                    }
                    // ��������н��ܲ���
                    string password = (string)registryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    password = SecretUtil.Decrypt(password);
                    this.txtPassword.Text = password;
                }
                */
            }
        }
        #endregion

        #region public override void FormOnLoad() ���ش���
        /// <summary>
        /// ���ش���
        /// </summary>
        public override void FormOnLoad()
        {
            // �����ǰ�ְԱ��¼
            // this.DTUser = ServiceManager.Instance.LogOnService.GetStaffDT(UserInfo);
            // �����ǰ��û���¼
            this.DTUser = ServiceManager.Instance.LogOnService.GetUserDT(UserInfo);
            
            // ְԱ��Ҫ���û�������������
            // this.DTUser.DefaultView.Sort = BaseUserTable.FieldSortCode;
            // ����û�������ǲ�ס������
            // foreach (DataRowView dataRowView in this.DTUser.DefaultView)
            // {
            //     this.cmbUser.Items.Add(dataRowView[BaseUserTable.FieldUserName].ToString());
            // }
            // ��ʾ�û���ʵ�����������û���
            this.cmbUser.DataSource = this.DTUser.DefaultView;
            this.cmbUser.DisplayMember = BaseUserTable.FieldRealName;
            this.cmbUser.ValueMember = BaseUserTable.FieldUserName;

            // ��������
            this.chkRememberPassword.Checked = BaseSystemInfo.RememberPassword; 
            // ��ȡ���еĵ�¼��Ϣ
            this.GetLogOnInfo();
            // Ĭ�Ͻ������û���������
            this.cmbUser.Focus();
            
            // ��ǰ�����뽹��ͣ��������༭���ϣ��Ǻǲ���ĸĽ���
            if (this.cmbUser.Text.Length > 0)
            {
                this.ActiveControl = this.txtPassword;
                this.txtPassword.Focus();
            }
            this.Localization(this);
        }
        #endregion

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.txtPassword.Clear();
                this.txtPassword.Focus();
            }
        }

        #region public override bool CheckInput() ����������Ч��
        /// <summary>
        /// ����������Ч��
        /// </summary>
        public override bool CheckInput()
        {
            // �Ƿ�û�������û���
            if (this.cmbUser.Text.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbUser.Focus();
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

        #region private bool CheckAllowLogOnCount() �����¼�����Ѿ�����
        /// <summary>
        /// �����¼�����Ѿ�����
        /// </summary>
        /// <returns>������������</returns>
        private bool CheckAllowLogOnCount()
        {
            if (this.LogOnCount >= this.AllowLogOnCount)
            {
                // �ؼ���������״̬
                this.txtPassword.Clear();
                this.cmbUser.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;

                // ������ʾ��Ϣ�������������ˣ��Ѿ�����N���ˡ�
			     MessageBox.Show(AppMessage.Format(AppMessage.MSG0211, this.AllowLogOnCount.ToString()), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				 return false;

            }
            return true;
        }
        #endregion

        #region private bool LogOn()
        /// <summary>
        /// �û���¼
        /// </summary>
        /// <returns>�Ƿ�ɹ�</returns>
        private bool LogOn()
        {
            // æ״̬
            this.Cursor = Cursors.WaitCursor;
            // �Ѿ���¼���� ++
            this.LogOnCount++;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            try
            {
                string userName = this.cmbUser.SelectedValue.ToString();
                BaseUserInfo userInfo = ServiceManager.Instance.LogOnService.UserLogOn(UserInfo, userName, this.txtPassword.Text, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OK.ToString())
                {
                    // ������
                    if ((userInfo != null) && (userInfo.Id.Length > 0))
                    {
                        // �û���¼�������¼��Ϣ
                        this.LogOn(userInfo);
                        // �����¼��Ϣ
                        this.SaveLogOnInfo(userInfo);                        
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
            }
            catch (Exception ex)
            {
                this.ProcessException(ex);
            }
            finally
            {
                // �Ѿ�æ����
                this.Cursor = Cursors.Default;
            }
            return true;
        }
        #endregion	

        #region private void LogOn(BaseUserInfo userInfo) ְԱ��¼�������¼��Ϣ
        /// <summary>
        /// ְԱ��¼�������¼��Ϣ
        /// </summary>
        /// <param name="userInfo">ְԱʵ��</param>
        private void LogOn(BaseUserInfo userInfo)
        {
            BaseSystemInfo.LogOn(userInfo);
        }
        #endregion

        #region private void SaveLogOnInfo(BaseUserInfo userInfo) ����¼��Ϣ���浽ע�����
        /// <summary>
        /// ����¼��Ϣ���浽ע����С�
        /// ���������û������룬�Ǿ�Ӧ��ɾ������
        /// </summary>
        /// <param name="userInfo">�ǵ�¼�û�</param>
        private void SaveLogOnInfo(BaseUserInfo userInfo)
        {
            BaseSystemInfo.RememberPassword = this.chkRememberPassword.Checked;
            if (this.chkRememberPassword.Checked)
            {
                BaseSystemInfo.CurrentUserName = userInfo.UserName;
                // BaseSystemInfo.CurrentUserName = SecretUtil.Encrypt(userInfo.UserName);
                BaseSystemInfo.CurrentPassword = SecretUtil.Encrypt(this.txtPassword.Text);
            }
            else
            {
                BaseSystemInfo.CurrentUserName = string.Empty;
                BaseSystemInfo.CurrentPassword = string.Empty;
            }
            ConfigHelper.SaveConfig();
            
            /*
            // д��ע�����ʱ���û��Ȩ�ޣ������쳣��Ϣ�ȣ����Կ���д��XML�ļ�
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseSystemInfo.SoftName);
            if (this.chkRememberPassword.Checked)
            {
                // Ĭ�ϵ���Ϣд��ע���,�Ǻ���Ҫ�Ľ�һ��
                registryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, SecretUtil.Encrypt(userInfo.UserName));
                registryKey.SetValue(BaseConfiguration.CURRENT_PASSWORD, SecretUtil.Encrypt(this.txtPassword.Text));
            }
            else
            {
                registryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, string.Empty);
                registryKey.SetValue(BaseConfiguration.CURRENT_PASSWORD, string.Empty);
            }
            */
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

        private void btnRequestAnAccount_Click(object sender, EventArgs e)
        {
            string assemblyName = "DotNet.WinForm.User";
            string formName = "FrmRequestAnAccount";
            Form frmRequestAnAccount = CacheManager.Instance.GetForm(assemblyName, formName);
            if (frmRequestAnAccount.ShowDialog() == DialogResult.OK)
            {
                // �����������˻��ɣ�����������һ������
                this.btnRequestAnAccount.Enabled = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // ��֤�û�����
            if (this.CheckInput())
            {
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
            // �˳�Ӧ�ó���
            Application.Exit();
        }
    }
}