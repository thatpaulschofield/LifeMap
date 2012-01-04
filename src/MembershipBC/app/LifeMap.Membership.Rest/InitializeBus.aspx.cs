using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LifeMap.Membership.Rest
{
    public partial class InitializeBus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Global.InitializeBus();
        }
    }
}