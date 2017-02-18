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
    }
}