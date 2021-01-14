using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Sys.DbUtilities;

namespace UI_Support
{
    public partial class EnrollmentForm : Form
    {
        // ���캯��
        private AppData Data;	// ����Ӧ�����ݶ���
        public EnrollmentForm(AppData data)
        {
            InitializeComponent();
			Data = data;                                        // ���ֶ����ݵ�����
            ExchangeData(true);                                 // ����Ĭ�Ͽ���ֵ�ĳ�ʼ������;
            Data.OnChange += delegate { ExchangeData(false); };	// �������ݸ����Ա��ֱ�ͬ��
        }

        // �򵥶Ի����ݽ�����DDX��ʵ�֡�

        public void ExchangeData(bool read)
        {
            if (read)
            {	// �ӱ��ؼ��ж�ȡֵ�����ݶ���

                Data.EnrolledFingersMask = EnrollmentControl.EnrolledFingerMask;
                Data.MaxEnrollFingerCount = EnrollmentControl.MaxEnrollFingerCount;
				Data.Update();
			}
            else
            {	// �����ݶ����ȡֵ������Ŀؼ�

                EnrollmentControl.EnrolledFingerMask = Data.EnrolledFingersMask;
                EnrollmentControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount;
            }
        }

        public void OnEnroll(Object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus Status)
        {
			if (Data.IsEventHandlerSucceeds)
			{
				Data.Templates[Finger-1] = Template;            // �洢��ָģ��

                ExchangeData(true);                             // ������������

                //����ָ��
                DbParameter[] param = new DbParameter[]
               {
                     new SqlParameter("@Doflag","Y"),
                     new SqlParameter("@User_Id",Data.ID),
                     new SqlParameter("@Fingers_Mask",Data.EnrolledFingersMask),
                     new SqlParameter("@Column","FINGERPRINT"+Finger),
                     new SqlParameter("@Value",Template.Bytes)
               };
                DataHelper.ExecStoredProcedure("up_Imos_Ta_Fingerprint_List", param);

            }
            else
				Status = DPFP.Gui.EventHandlerStatus.Failure;   // ǿ�ơ�ʧ�ܡ�״̬

        }

        public void OnDelete(Object Control, int Finger, ref DPFP.Gui.EventHandlerStatus Status)
        {
            if (Data.IsEventHandlerSucceeds) {
                Data.Templates[Finger-1] = null;                // �����ָģ��

                ExchangeData(true);                             // ������������

                //ɾ��ָ��
                DbParameter[] param = new DbParameter[]
               {
                     new SqlParameter("@Doflag","N"),
                     new SqlParameter("@User_Id",Data.ID),
                     new SqlParameter("@Fingers_Mask",Data.EnrolledFingersMask),
                     new SqlParameter("@Column","FINGERPRINT"+Finger),
                     new SqlParameter("@Value",Convert.ToByte("1"))
               };
                DataHelper.ExecStoredProcedure("up_Imos_Ta_Fingerprint_List", param);
            }
			else
				Status = DPFP.Gui.EventHandlerStatus.Failure;   // ǿ�ơ�ʧ�ܡ�״̬
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}