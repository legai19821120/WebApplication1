﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNet
{
    public partial class _04practice1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /********************************************************
             * 宣告變數a為整數，值為42，宣告變數b為浮點數，值2.5，  *
             *將兩值分別做加、減、乘、除及取餘數之運算，並輸出其結果*
             ********************************************************/
            int a = 42;
            float b = 2.5f;
            Response.Write(a + "+" + b + "=" + (a + b));
            Response.Write("<br />");
            Response.Write(a + "-" + b + "=" + (a - b));
            Response.Write("<br />");
            Response.Write(a + "*" + b + "=" + a * b);
            Response.Write("<br />");
            Response.Write(a + "/" + b + "=" + a / b);
            Response.Write("<br />");
            Response.Write(a + "%" + b + "=" + a % b);
            Response.Write("<br />");
            /*****************************************
            * 撰寫一個將攝氏溫度轉換為華氏溫度的程式*
            * 攝氏溫度的值直接在程式中給定即可      *
            *(華氏＝攝氏 * 9 / 5 + 32)              *
            *****************************************/
            float c = 33.5f;
            Response.Write("攝氏" + c + "度等於華氏" + (c * 9 / 5 + 32) + "度");
        }
    }
}