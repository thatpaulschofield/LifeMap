using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LifeMap.Membership.Rest.Resources;
using OpenRasta.Codecs.WebForms;

namespace LifeMap.Membership.Rest.Views
{
    public partial class RegistrationsView : ResourceView<IList<Registration>>
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}