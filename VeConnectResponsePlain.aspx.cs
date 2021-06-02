using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using VeConnectService;

public partial class VeConnectResponse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VeConnectService.ServiceClient objConnect = new VeConnectService.ServiceClient();
        string sResponse = "";
        
        try
        {
            string sInput = Request.QueryString.Get("INPUT");
            sInput = JsonCsharpUtiil.getEncryptString(sInput, "snowtint!@#$");
            sResponse = objConnect.VeConnectService(sInput);
            string decryptedResponse = JsonCsharpUtiil.getDecryptString(sResponse, "ditgm@1985$$");
            Response.Write(decryptedResponse);
	    //Response.Write(sResponse);

        }
        catch (Exception eee)
        {
            clsEvent.LogExceptionEvent(eee.Message+ " at : "+DateTime.Now.ToString());
            sResponse = "116";
        }
        
    }
}