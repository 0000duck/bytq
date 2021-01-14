using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI_Support
{
    public partial class VerificationForm : Form
    {
        private AppData Data;   // ����Ӧ�����ݶ���
        public VerificationForm(AppData data)
        {
            InitializeComponent();
			Data = data;
			Data.OnChange += delegate { ExchangeData(false); };     // �������ݸ����Ա���ͬ��

        }

        private void ExchangeData(bool read)
        {
        }

		public void OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus Status)
        {
			DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
			DPFP.Verification.Verification.Result res = new DPFP.Verification.Verification.Result();
            // �������������д洢��ģ����бȽϡ�

            foreach (DPFP.Template template in Data.Templates) {
                // �Ӵ洢�л�ȡģ�塣

                if (template != null) {
                    // �����������ض�ģ����бȽϡ�

                    ver.Verify(FeatureSet, template, ref res);
                    Data.IsFeatureSetMatched = res.Verified;
                    Data.FalseAcceptRate = res.FARAchieved;
                    if (res.Verified)
                        break; // �ɹ�
                }
            }
			if (!res.Verified)
				Status = DPFP.Gui.EventHandlerStatus.Failure;
			Data.Update();
        }



    }
}