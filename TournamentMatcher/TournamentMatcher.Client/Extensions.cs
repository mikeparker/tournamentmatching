using System.Drawing;
using System.Windows.Forms;
using TournamentMatcher.GamePicking;

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

        public static void RefreshWithColours(this DataGridView dataGridView)
        {
            foreach (var obj in dataGridView.Rows)
            {
                var row = (DataGridViewRow)obj;
                var match = (Match)row.DataBoundItem;
                if (match.Team1.FinalScore == 21)
                {
                    row.Cells[0].Style.BackColor = Color.DarkSeaGreen;
                    row.Cells[1].Style.BackColor = Color.PaleVioletRed;
                }
                else if (match.Team2.FinalScore == 21)
                {
                    row.Cells[1].Style.BackColor = Color.DarkSeaGreen;
                    row.Cells[0].Style.BackColor = Color.PaleVioletRed;
                }
            }
        }

    }
}