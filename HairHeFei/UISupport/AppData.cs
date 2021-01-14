using System;
using System.Collections.Generic;
using System.Text;

namespace UI_Support
{
	public delegate void OnChangeHandler();

    // Keeps application-wide data shared among forms and provides notifications about changes
    // Everywhere in this application a "document-view" model is used, and this class provides
    // a "document" part, whereas forms implement a "view" parts.
    // Each form interested in this data keeps a reference to it and synchronizes it with own 
    // controls using the OnChange() event and the Update() notificator method.
    // �ڱ��б���Ӧ�ó���Χ�ڵ����ݹ������ṩ�йظ��ĵ�֪ͨ
    //�����Ӧ�ó����е�ÿһ���ط���ʹ���ˡ��ĵ���ͼ��ģ�ͣ�������ṩ��һ�����ĵ������֣�����ʵ����һ������ͼ�����֡�
    //�Ը�������ص�ÿһ�����嶼���ֶ��������ã���ʹ��OnCube�����¼���UpDebug����NOTIFICCAR�����������Լ��Ŀؼ�ͬ����

    public class AppData
    {
		public const int MaxFingers = 10;
        // ��������
        public int EnrolledFingersMask = 0;
		public int MaxEnrollFingerCount = MaxFingers;
        public bool IsEventHandlerSucceeds = true;
        public bool IsFeatureSetMatched = false;
        public int FalseAcceptRate = 0;
		public DPFP.Template[] Templates = new DPFP.Template[MaxFingers];
        public string Name;
        public int ID;

        // ���ݸ���֪ͨ

        public void Update() { OnChange(); }        // ֻ����OnCube�����¼�

        public event OnChangeHandler OnChange;
	}
}
