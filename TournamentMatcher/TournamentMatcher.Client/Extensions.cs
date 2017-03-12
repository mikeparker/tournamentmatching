using System.Windows.Forms;

namespace TournamentMatcher.Client
{
    public static class Extensions
    {
        public static void SetNotColumnSortable(this DataGridView dataGridView)
        {
            foreach (DataGridViewTextBoxColumn column in dataGridView.Columns)
            {
                dataGridView.Columns[column.Name].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public static void SetColumnEditable(this DataGridView dataGridView, int columnNum)
        {
            foreach (DataGridViewColumn dc in dataGridView.Columns)
            {
                if (dc.Index.Equals(columnNum))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }
            }
        }

        public static void AutosizeColumns(this DataGridView dataGridView)
        {
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}