using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AgileFrame.Orm.PersistenceLayer.Model;
using AgileFrame.Orm.PersistenceLayer.BLL;
using AgileFrame.Orm.PersistenceLayer.BLL.Base;

public partial class WF_F_COLUMNBack : AgileFrame.AppInOne.Common.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //���б�����ɾ����ť��ͨ��AJAXִ������ĺ�̨���룬ɾ��һ����¼
        if (Request["DelCOLUMN_ID"] != null)
        {
            int re = BLLTable<TF_F_COLUMN>.Factory(conn).Delete(TF_F_COLUMN.Attribute.COLUMN_ID, Request["DelCOLUMN_ID"]);
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
            TF_F_COLUMN cond = new TF_F_COLUMN();
            cond.In(TF_F_COLUMN.Attribute.COLUMN_ID, Request["DelKeyIDS"]);
            int re = BLLTable<TF_F_COLUMN>.Factory(conn).Delete(cond);
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
            TF_F_COLUMN val = new TF_F_COLUMN();
            val.COLUMN_ID = int.Parse(Request["FieldKeyID"]);
            List<AttributeItem> lstCol = val.af_AttributeItemList;
            for (int i = 0; i < lstCol.Count; i++)
            {
                if (!string.IsNullOrEmpty(Request["txt" + lstCol[i].FieldName])) {
                    val.SetValue(lstCol[i].FieldName,Request["txt" + lstCol[i].FieldName]);
                }
            }

            BLLTable<TF_F_COLUMN>.Factory(conn).Update(val, TF_F_COLUMN.Attribute.COLUMN_ID);
            Response.Write("�޸��û���Ϣ�ɹ�");

        }
        if (Request["getColItems"] != null)
        {
            string colid=Request["colID"];
            List<TF_F_COLUMN_ITEM> lst = BLLTable<TF_F_COLUMN_ITEM>.Factory(conn).Select(TF_F_COLUMN_ITEM.Attribute.COLUMN_ID, colid);
            StringBuilder sb = new StringBuilder("[");
            if (lst != null) {
                lst.ForEach(col => {
                    if(sb.Length>3){
                        sb.Append(",");

                        sb.Append("{val:'"+col.VALUE+"',txt:'"+col.TEXT+"'}");
                    }
                
                });
            }
            sb.Append("]");
            Response.Write(sb.ToString());
        }

        Response.End();
    }
}