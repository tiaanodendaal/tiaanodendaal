using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_Forms.DAL
{
    public class DAL_Titles
    {
        NadMedDataContext db = new NadMedDataContext();

        public List<Title> getAll()
        {
            List<Title> CL_List = new List<Title>();
            var CLList = from cli in db.Titles
                         orderby cli.TitleName
                         select cli;
            return CLList.ToList();
        }


        public bool Save(Title SaveTitle)
        {
            if (SaveTitle.TitleID == 0)
            {
                db.Titles.InsertOnSubmit(SaveTitle);
                db.SubmitChanges();
            }
            else
            {
                Title xmaster = (from cm in db.Titles
                                        where cm.TitleID == SaveTitle.TitleID
                                        select cm).FirstOrDefault();

                xmaster.TitleName = SaveTitle.TitleName;
                db.SubmitChanges();
            }
            return true;
        }
    }
}
