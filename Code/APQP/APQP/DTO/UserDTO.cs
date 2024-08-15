using APQP.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APQP.DTO
{
    public class UserDTO
    {
        public bool _loginUser(string userID, string pass, string _MoldType)
        {
            try
            {

                Constaint.MoldType = _MoldType;
                bool check = false;


                string _query = "SELECT a.USER_ID, a.SECTION_ID, a.FULLNAME ,a.ID_ACCESS, s.SECTION_SHORT_NAME FROM TBL_ACCOUNT a left join TBL_SECTION_MST s on a.SECTION_ID = s.SECTION_ID WHERE a.USER_ID = '" + userID + "' AND a.PASSWORD='" + Constaint._md5(pass) + "'";
                DataTable _data = DBUtils._getData(_query);
                if (_data.Rows.Count > 0 && _data != null)
                {
                    Constaint._userID = Convert.ToString(_data.Rows[0]["USER_ID"]);

                    Constaint._nameUser = Convert.ToString(_data.Rows[0]["FULLNAME"]);
                    Constaint._access = Convert.ToString(_data.Rows[0]["ID_ACCESS"]);
                    Constaint._sectionShort = Convert.ToString(_data.Rows[0]["SECTION_SHORT_NAME"]);
                    Constaint._password = Constaint._md5(pass);
                    //Constaint._sectionName = Convert.ToString(_data.Rows[0]["SECTION_NAME"]);
                    //Constaint._postisionID = Convert.ToString(_data.Rows[0]["POSTISION_ID"]);
                    //Constaint._postisionName = Convert.ToString(_data.Rows[0]["POSTISION_NAME"]);
                    //Constaint._factoryName = Convert.ToString(_data.Rows[0]["FACTORY_NAME"]);
                    //Constaint._sectionID = Convert.ToString(_data.Rows[0]["SECTION_ID"]);
                    //Constaint._sectionShort = Convert.ToString(_data.Rows[0]["SECTION_SHORT_NAME"]);
                    MessageBox.Show("Login successfull !" + "\n" + "Wellcome " + Constaint._userID + " : " + Constaint._nameUser + "!");
                    check = true;
                }
                return check;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
