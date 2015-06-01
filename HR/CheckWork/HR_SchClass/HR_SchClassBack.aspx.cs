using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AgileFrame.Orm.PersistenceLayer.Model;
using AgileFrame.Orm.PersistenceLayer.BLL;
using AgileFrame.Orm.PersistenceLayer.BLL.Base;

public partial class HR_SchClassBack : AgileFrame.AppInOne.Common.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //���б�����ɾ����ť��ͨ��AJAXִ������ĺ�̨���룬ɾ��һ����¼
        if (Request["DelSchClassid"] != null)
        {
            int re = BLLTable<HR_SchClass>.Factory(conn).Delete(HR_SchClass.Attribute.SchClassid, Request["DelSchClassid"]);
            HR_Scheduling sdcond = new HR_Scheduling();
            sdcond.Top(500);
            sdcond.Where(" {0} = {1} ", HR_Scheduling.Attribute.SchClassid, Request["DelSchClassid"]);
            while (BLLTable<HR_Scheduling>.Factory(conn).Delete(sdcond) > 0)
            {
                continue;
            }
            if (re > 0)
            {
                Response.Write("1");//����������� ����0 ��ʾ�����ɹ���Ҳ����ֱ����� �ַ������ͻ��˽��������ַ�����Ϣ��Ϊ��ʾ
            }
            else
            {
                Response.Write("ɾ��ʧ�ܣ�");
            }
        }

        //���б��������ɾ����ť��ͨ��AJAXִ������ĺ�̨���룬ɾ��������¼
        if (Request["DelKeyIDS"] != null)
        {
            HR_SchClass cond = new HR_SchClass();
            cond.In(HR_SchClass.Attribute.SchClassid, Request["DelKeyIDS"]);
            int re = BLLTable<HR_SchClass>.Factory(conn).Delete(cond);
            HR_Scheduling sdcond = new HR_Scheduling();
            sdcond.Top(500);
            sdcond.In(HR_Scheduling.Attribute.SchClassid, Request["DelKeyIDS"]);
            while (BLLTable<HR_Scheduling>.Factory(conn).Delete(sdcond) > 0)
            {
                continue;
            }
            if (re > 0)
            {
                Response.Write("1");//����������� ����0 ��ʾ�����ɹ���Ҳ����ֱ����� �ַ������ͻ��˽��������ַ�����Ϣ��Ϊ��ʾ
            }
            else
            {
                Response.Write("ɾ��ʧ�ܣ�");
            }
        }

        //���û���ϸ��Ϣ�鿴�༭ҳ�棬�㱣��ʱ��ͨ��AJAXִ������ĺ�̨���룬ʵ�ֲ����ֶεĸ���
        if (Request["saveInfo"] != null)
        {
            HR_SchClass val = new HR_SchClass();
            val.SchClassid = int.Parse(Request["FieldKeyID"]);
            List<AttributeItem> lstCol = val.af_AttributeItemList;
            for (int i = 0; i < lstCol.Count; i++)
            {
                if (!string.IsNullOrEmpty(Request["txt" + lstCol[i].FieldName])) {
                    val.SetValue(lstCol[i].FieldName,Request["txt" + lstCol[i].FieldName]);
                }
            }

            BLLTable<HR_SchClass>.Factory(conn).Update(val, HR_SchClass.Attribute.SchClassid);
            Response.Write("�޸��û���Ϣ�ɹ�");

        }
        Response.End();
    }
}