using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityRegistrationSystem.Boundry
{
    abstract class TableList : DataGridView
    {
        protected DataTable table;

        public TableList()
        {
            //InitalizeTable();
        }

        protected void InitalizeTable()
        {
            this.table = new DataTable();
            this.AutoSize = true;
            this.BuildColumns();
            this.LoadData();
        }

        protected void LoadData()
        {
            this.BuildRows();
            this.DataSource = this.table;
            this.AutoResizeRows();
            this.AutoResizeColumns();
        }

        abstract protected void BuildColumns();

        abstract protected void BuildRows();
    }
}
