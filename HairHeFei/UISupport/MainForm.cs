using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Support
{

	// ������
    public partial class MainForm : Form
    {
        private AppData Data;					// ����Ӧ�÷�Χ������

        private EnrollmentForm Enroller;
        private VerificationForm Verifier;
        public string uloginname = "";
        public string ucname = "";
        public string upassword = "";
        public string userid = "0";
        public string userFingersMask = "0";
        public MainForm()
        {
            InitializeComponent();
	        Data = new AppData();                               // ����Ӧ�ó������ݶ���

            Data.OnChange += delegate { ExchangeData(false); }; // �������ݸ����Ա��ֱ�ͬ��

            Enroller = new EnrollmentForm(Data);
            Verifier = new VerificationForm(Data);
            ExchangeData(false);                                // �ÿؼ���Ĭ��ֵ�������
            
        }

        // �򵥶Ի����ݽ�����DDX��ʵ�֡�

        private void ExchangeData(bool read)
        {
            if (read)
            {	// �ӱ��ؼ��ж�ȡֵ�����ݶ���
                //Data.EnrolledFingersMask = Mask.Text.Length == 0 ? 0 : (int)Mask.Value;
                Data.EnrolledFingersMask = Convert.ToInt32(userFingersMask);
                Data.MaxEnrollFingerCount = MaxFingers.Text.Length == 0 ? 0 : (int)MaxFingers.Value;
                Data.IsEventHandlerSucceeds = IsSuccess.Checked;
                Data.ID = Convert.ToInt32(userid);
                Data.Update();
                txt_name.Text = ucname;
            }
            else
            {   // �����ݶ����ȡVALUE������ؼ�

                Mask.Value = Data.EnrolledFingersMask;
				MaxFingers.Value = Data.MaxEnrollFingerCount;
				IsSuccess.Checked = Data.IsEventHandlerSucceeds;
                IsFailure.Checked = !IsSuccess.Checked;
                IsFeatureSetMatched.Checked = Data.IsFeatureSetMatched;
                FalseAcceptRate.Text = Data.FalseAcceptRate.ToString();
				VerifyButton.Enabled = Data.EnrolledFingersMask > 0;
                
            }
        }

        private void EnrollButton_Click(object sender, EventArgs e)
        {
			ExchangeData(true);     // �������������ݶ��󴫵�ֵ

            Enroller.ShowDialog();	// ����ע��

        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
			ExchangeData(true);     // �������������ݶ��󴫵�ֵ

            Verifier.ShowDialog();	// ������֤

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}