﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class prueba : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String a = Request.QueryString["id"];
        this.Label1.Text = a;
    }
}